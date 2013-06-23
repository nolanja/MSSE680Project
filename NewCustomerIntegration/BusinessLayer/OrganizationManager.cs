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
    public class OrganizationManagement : Manager
    {
        public DBIntegrationContext context;

        public OrganizationManagement()
        {
            this.context = new DBIntegrationContext();
        }

        public OrganizationManagement(DBIntegrationContext dbContext)
        {
            this.context = dbContext;
        }

        public void OrganizationListNames()
        {

            try
            {
                INewCustomerOrganizationService orgSvc =
                    (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name, context);
                orgSvc.GetOrganizationNames();
            }
            catch (Exception e)
            {
                throw new Exception("Cannot get list organization names " + e.GetType().Name);
            }
        }

        public void OrganizationDetails(long id)
        {

            try
            {
                INewCustomerOrganizationService orgSvc =
                    (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name, context);
                orgSvc.OrganizationDetails(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot get organization details " + e.GetType().Name);
            }
        }

        public void OrganizationCreate(Organization organization)
        {

            try
            {
                INewCustomerOrganizationService orgSvc =
                    (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name, context);
                orgSvc.OrganizationCreate(organization);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot create organization " + e.GetType().Name);
            }
        }

        public void OrganizationEdit(long id)
        {

            try
            {
                INewCustomerOrganizationService orgSvc =
                    (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name, context);
                orgSvc.OrganizationEdit(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot edit organization " + e.GetType().Name);
            }
        }

        public void OrganizationEdit(Organization organization)
        {

            try
            {
                INewCustomerOrganizationService orgSvc =
                    (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name, context);
                orgSvc.OrganizationEdit(organization);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot edit organization " + e.GetType().Name);
            }
        }

        public void OrganizationDelete(long id)
        {

            try
            {
                INewCustomerOrganizationService orgSvc =
                    (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name, context);
                orgSvc.OrganizationDelete(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot delete organization " + e.GetType().Name);
            }
        }

        public void OrganizationDeleteConfirmed(long id)
        {

            try
            {
                INewCustomerOrganizationService orgSvc =
                    (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name, context);
                orgSvc.OrganizationDeleteConfirmed(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot delete organization " + e.GetType().Name);
            }
        }

        public void OrganizationDispose(bool disposing)
        {

            try
            {
                INewCustomerOrganizationService orgSvc =
                    (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name, context);
                orgSvc.OrganizationDispose(disposing);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot dispose of organization " + e.GetType().Name);
            }
        }

    }
}