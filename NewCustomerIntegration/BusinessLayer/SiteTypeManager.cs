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

    public class SiteTypeManagement : Manager
    {
        public DBIntegrationContext context;

        public SiteTypeManagement()
        {
            this.context = new DBIntegrationContext();
        }

        public SiteTypeManagement(DBIntegrationContext dbContext)
        {
            this.context = dbContext;
        }
        public void ListSiteTypes()
        {
            try
            {
                INewCustomerSiteTypeService siteTypeSvc =
                    (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name, context);
                siteTypeSvc.GetSiteTypes();
            }
            catch (Exception e)
            {
                throw new Exception("Cannot get list of site types " + e.GetType().Name);
            }
        }

        public void SiteTypeDetails(long id)
        {
            try
            {
                INewCustomerSiteTypeService siteTypeSvc =
                    (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name, context);
                siteTypeSvc.SiteTypeDetails(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot get site types details " + e.GetType().Name);
            }
        }

        public void SiteTypeCreate(SiteType siteType)
        {
            try
            {
                INewCustomerSiteTypeService siteTypeSvc =
                    (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name, context);
                siteTypeSvc.SiteTypeCreate(siteType);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot create site type " + e.GetType().Name);
            }
        }

        public void SiteTypeEdit(long id)
        {
            try
            {
                INewCustomerSiteTypeService siteTypeSvc =
                    (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name, context);
                siteTypeSvc.SiteTypeEdit(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot Edit site type " + e.GetType().Name);
            }
        }

        public void SiteTypeEdit(SiteType siteType)
        {
            try
            {
                INewCustomerSiteTypeService siteTypeSvc =
                    (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name, context);
                siteTypeSvc.SiteTypeEdit(siteType);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot Edit site type " + e.GetType().Name);
            }
        }

        public void SiteTypeDelete(long id)
        {
            try
            {
                INewCustomerSiteTypeService siteTypeSvc =
                    (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name, context);
                siteTypeSvc.SiteTypeDelete(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot Delete site type " + e.GetType().Name);
            }
        }

        public void SiteTypeDeleteConfirmed(long id)
        {
            try
            {
                INewCustomerSiteTypeService siteTypeSvc =
                    (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name, context);
                siteTypeSvc.SiteTypeDeleteConfirmed(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot Confirm Delete site type " + e.GetType().Name);
            }
        }

        public void SiteTypeDispose(bool disposing)
        {
            try
            {
                INewCustomerSiteTypeService siteTypeSvc =
                    (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name, context);
                siteTypeSvc.SiteTypeDispose(disposing);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot Confirm Delete site type " + e.GetType().Name);
            }
        }
    }

}