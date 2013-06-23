using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewCustomerIntegration.Domain.Models;
using NewCustomerIntegration.Factories;
using NewCustomerIntegration.Services;
using NewCustomerIntegration.Models;

namespace NewCustomerIntegration.BusinessLayer
{

    public class SiteManagement : Manager
    {

        public DBIntegrationContext context;

        public SiteManagement()
        {
            this.context = new DBIntegrationContext();
        }

        public SiteManagement(DBIntegrationContext dbContext)
        {
            this.context = dbContext;
        }

        public void SiteCreate(Site site)
        {
            try
            {
                INewCustomerSiteService siteSvc =
                    (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name, context);
                siteSvc.SiteCreateOrganizationIDKey();
                siteSvc.SiteCreateSiteTypeIDKey();
                siteSvc.SiteCreate(site);
                siteSvc.SiteWriteOrganizationIDKey(site);
                siteSvc.SiteWriteSiteTypeIDKey(site);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot create site " + e.GetType().Name);
            }
        }

        public void SiteEdit(Site site)
        {
            try
            {
                INewCustomerSiteService siteSvc =
                    (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name, context);
                siteSvc.SiteCreateOrganizationIDKey();
                siteSvc.SiteCreateSiteTypeIDKey();
                siteSvc.SiteEdit(site);
                siteSvc.SiteWriteOrganizationIDKey(site);
                siteSvc.SiteWriteSiteTypeIDKey(site);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot Edit site " + e.GetType().Name);
            }
        }

        public void SiteList()
        {
            try
            {
                INewCustomerSiteService siteSvc =
                    (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name, context);
                siteSvc.GetSites();
            }
            catch (Exception e)
            {
                throw new Exception("Cannot List site " + e.GetType().Name);
            }
        }

        public void SiteDelete(long id)
        {
            try
            {
                INewCustomerSiteService siteSvc =
                    (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name, context);
                siteSvc.SiteDelete(id);

            }
            catch (Exception e)
            {
                throw new Exception("Cannot Delete site " + e.GetType().Name);
            }
        }

        public void SiteDeleteConfirm(long id)
        {
            try
            {
                INewCustomerSiteService siteSvc =
                    (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name, context);
                siteSvc.SiteDeleteConfirmed(id);

            }
            catch (Exception e)
            {
                throw new Exception("Cannot Confirm Deleted site " + e.GetType().Name);
            }
        }

        public void SiteDipose(bool disposing)
        {
            try
            {
                INewCustomerSiteService siteSvc =
                    (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name, context);
                siteSvc.SiteDispose(disposing);

            }
            catch (Exception e)
            {
                throw new Exception("Cannot Dispose site " + e.GetType().Name);
            }
        }

    }

}