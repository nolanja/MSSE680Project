using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewCustomerIntegration.Services;
using NewCustomerIntegration.Domain.Models;

namespace NewCustomerIntegration.Services
{
    public class OrganizationService : INewCustomerOrganizationService
    {
         DBIntegrationContext customerDB = new DBIntegrationContext();

         public IList<string> GetOrganizationNames()
         {
             var organizations = from organization in customerDB.Organizations
                                 select organization.OrganizationName;

             return organizations.ToList();
         }

         public Organization OrganizationDetails(long id = 0)
         {
             return this.customerDB.Organizations.Find(id);
         }
             
        public void OrganizationCreate(Organization organization)
        {
            this.customerDB.Organizations.Add(organization);
            this.customerDB.SaveChanges();
        }

        public Organization OrganizationEdit(long id = 0)
        {
           return this.customerDB.Organizations.Find(id);
        }

        public void OrganizationEdit(Organization organization)
        {
            this.customerDB.Entry(organization).State = EntityState.Modified;
            this.customerDB.SaveChanges();
        }

        public Organization OrganizationDelete(long id = 0)
        {
            return this.customerDB.Organizations.Find(id);
        }

        public void OrganizationDeleteConfirmed(long id)
        {
            var organization = this.customerDB.Organizations.Find(id);
            this.customerDB.Organizations.Remove(organization);
            this.customerDB.SaveChanges();
        }

        public void OrganizationDispose(bool disposing)
        {
            this.customerDB.Dispose();
        }
    }
}