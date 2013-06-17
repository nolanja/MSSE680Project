using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NewCustomerIntegration.Services;
using NewCustomerIntegration.Domain.Models;

namespace NewCustomerIntegration.Services
{
    public class OrganizationSvcMVCImpl : INewCustomerOrganizationService
    {
         DBIntegrationContext customerDB = new DBIntegrationContext();

         public void StoreOrganizations(Organization organization)
         {
             FileStream fileStream = new FileStream
                 ("Organizations.bin", FileMode.Create, FileAccess.Write);
             IFormatter formatter = new BinaryFormatter();
             formatter.Serialize(fileStream, organization);
             fileStream.Close();
         }

         public ArrayList RetrieveOrganizations()
         {
             FileStream fileStream = new FileStream
                 ("Organizations.bin", FileMode.Open, FileAccess.Read);
             IFormatter formatter = new BinaryFormatter();
             ArrayList organizations = formatter.Deserialize(fileStream) as ArrayList;
             fileStream.Close();
             return organizations;
         } 
        
        public IList<Organization> GetOrganizationNames()
         {
             var organizations = customerDB.Organizations;
             return organizations.ToList();
         }

         public Organization OrganizationDetails(long id)
         {
             return this.customerDB.Organizations.Find(id);
         }
             
        public void OrganizationCreate(Organization organization)
        {
            try
            {
                this.customerDB.Organizations.Add(organization);
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                Console.WriteLine("unable to add organization to database", e.GetType().Name);
            }
            
        }

        public Organization OrganizationEdit(long id)
        {
           return this.customerDB.Organizations.Find(id);
        }

        public void OrganizationEdit(Organization organization)
        {
            this.customerDB.Entry(organization).State = EntityState.Modified;
            try
            {
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                Console.WriteLine("unable to add organization to database", e.GetType().Name);

            }
        }

        public Organization OrganizationDelete(long id)
        {
            return this.customerDB.Organizations.Find(id);
        }

        public void OrganizationDeleteConfirmed(long id)
        {
            try
            {
                var organization = this.customerDB.Organizations.Find(id);
                this.customerDB.Organizations.Remove(organization);
            }
            catch (IOException e)
            {
                Console.WriteLine("unable to find " + id.ToString() + " in organizations database", e.GetType().Name);

            }         
            this.customerDB.SaveChanges();
        }

        public void OrganizationDispose(bool disposing)
        {
            this.customerDB.Dispose();
        }

        
        
    }
}