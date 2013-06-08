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
    public class SiteService : INewCustomerSiteService
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public IList<Site> GetSites()
        {
            var sites = customerDB.Sites.Include(s => s.Organization).Include(s => s.SiteType);

            return sites.ToList();
        }

        public Site SiteDetails(long id)
        {
            return this.customerDB.Sites.Find(id);
        }

        public dynamic SiteCreateOrganizationIDKey()
        {
            var organizationID = new SelectList(customerDB.Organizations, "OrganizationId", "OrganizationCode");
            return organizationID;
        }

        public dynamic SiteCreateSiteTypeIDKey()
        {
            var siteTypeID = new SelectList(customerDB.SiteTypes, "SiteTypeId", "SiteTypeName");
            return siteTypeID;
        }

        public dynamic SiteWriteOrganizationIDKey(Site site)
        {
            var organizationID = new SelectList(customerDB.Organizations, "OrganizationId", "OrganizationCode", site.OrganizationId);
            return organizationID;
        }

        public dynamic SiteWriteSiteTypeIDKey(Site site)
        {
            var siteTypeID = new SelectList(customerDB.SiteTypes, "UserTypeId", "UserTypeName", site.SiteTypeId);
            return siteTypeID;
        }
        public void SiteCreate(Site site)
        {
            this.customerDB.Sites.Add(site);
            this.customerDB.SaveChanges();
        }

        public Site SiteEdit(long id)
        {
            return this.customerDB.Sites.Find(id);
        }

        public void SiteEdit(Site site)
        {
            this.customerDB.Entry(site).State = EntityState.Modified;
            this.customerDB.SaveChanges();
        }

        public Site SiteDelete(long id)
        {
            return this.customerDB.Sites.Find(id);
        }

        public void SiteDeleteConfirmed(long id)
        {
            var site = this.customerDB.Sites.Find(id);
            this.customerDB.Sites.Remove(site);
            this.customerDB.SaveChanges();
        }

        public void SiteDispose(bool disposing)
        {
            this.customerDB.Dispose();
        }
    }
}