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
using NewCustomerIntegration.Factories;

namespace NewCustomerIntegration.Services
{
    public class OrganizationSvcMVCImpl : INewCustomerOrganizationService
    {
         DBIntegrationContext customerDB = new DBIntegrationContext();

         public void StoreOrganizations(Organization organization)
         {
             try
             {
                 FileStream fileStream = new FileStream
             ("Organizations.bin", FileMode.Create, FileAccess.Write);
                 IFormatter formatter = new BinaryFormatter();
             formatter.Serialize(fileStream, organization);
             fileStream.Close();
             }
             catch (IOException e)
             {
                 
                 throw new IOException("Unable to create file Organizations.bin " + e.GetType().Name);
             }

         }

         public ArrayList RetrieveOrganizations()
         {
             try
             {
                 FileStream fileStream = new FileStream
             ("Organizations.bin", FileMode.Open, FileAccess.Read);
                 IFormatter formatter = new BinaryFormatter();
                 ArrayList organizations = formatter.Deserialize(fileStream) as ArrayList;
                 fileStream.Close();
                 return organizations;
             }
             catch (FileNotFoundException e)
             {
                 
                 throw new FileNotFoundException("Unable to open Organizations.bin " + e.GetType().Name);
             }
         } 
        
        public IList<Organization> GetOrganizationNames()
         {
             var organizations = customerDB.Organizations;
             return organizations.ToList();
         }

         public Organization OrganizationDetails(long id)
         {
             try
             {
                 return this.customerDB.Organizations.Find(id);
             }
             catch (IOException e)
             {
                 throw new IOException("Unable to find Organization" + e.GetType().Name);
             }
             
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
                throw new IOException("unable to add organization to database" + e.GetType().Name);
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
                throw new IOException("unable to add organization to database" + e.GetType().Name);

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
                throw new IOException("unable to remove " + id.ToString() + " in organizations database "+ e.GetType().Name);

            }

            try
            {
                this.customerDB.SaveChanges();
            }
            catch
            {
                throw new IOException("unable to write customer file ");
            }
            
        }

        public void OrganizationDispose(bool disposing)
        {
            try
            {
                this.customerDB.Dispose();
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("unable to find file " + e.GetType().Name);
            }

        }

    }
}