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
    public class SiteTypeService : INewCustomerSiteTypeService
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public IList<SiteType> GetSiteTypes()
        {
            var sitetypes = customerDB.SiteTypes;

            return sitetypes.ToList();
        }

        public SiteType SiteTypeDetails(long id)
        {
            return this.customerDB.SiteTypes.Find(id);
        }

        public void SiteTypeCreate(SiteType sitetype)
        {
            this.customerDB.SiteTypes.Add(sitetype);
            this.customerDB.SaveChanges();
        }

        public SiteType SiteTypeEdit(long id)
        {
            return this.customerDB.SiteTypes.Find(id);
        }

        public void SiteTypeEdit(SiteType sitetype)
        {
            this.customerDB.Entry(sitetype).State = EntityState.Modified;
            this.customerDB.SaveChanges();
        }

        public SiteType SiteTypeDelete(long id)
        {
            return this.customerDB.SiteTypes.Find(id);
        }

        public void SiteTypeDeleteConfirmed(long id)
        {
            var sitetype = this.customerDB.SiteTypes.Find(id);
            this.customerDB.SiteTypes.Remove(sitetype);
            this.customerDB.SaveChanges();
        }

        public void SiteTypeDispose(bool disposing)
        {
            this.customerDB.Dispose();
        }
    }
}