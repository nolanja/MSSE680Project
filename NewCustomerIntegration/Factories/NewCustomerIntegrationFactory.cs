using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using System.Web.Routing;
using NewCustomerIntegration.Domain.Models;
using NewCustomerIntegration.Controllers;
using NewCustomerIntegration.Services;

namespace NewCustomerIntegration.Factories
{
    public class NewCustomerIntegrationFactory
    {
        public INewCustomerAddressService GetAddressSvc()
        {
            return new AddressSvcMVCImpl();
        }

        public INewCustomerOrganizationService GetOrganizationSvc()
        {
            return new OrganizationSvcMVCImpl();
        }

        public INewCustomerPersonService GetPersonSvc()
        {
            return new PersonSvcMVCImpl();
        }

        public INewCustomerRuleService GetRuleSvc()
        {
            return new RuleSvcMVCImpl();
        }

        public INewCustomerSiteService GetSiteSvc()
        {
            return new SiteSvcMVCImpl();
        }

        public INewCustomerSiteTypeService GetSiteTypeSvc()
        {
            return new SiteTypeSvcMVCImpl();
        }

        public INewCustomerUserTypeService GetUserTypeSvc()
        {
            return new UserTypeSvcMVCImpl();
        }
    }
}