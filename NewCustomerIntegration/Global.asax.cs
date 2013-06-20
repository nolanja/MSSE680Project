using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using NewCustomerIntegration.Domain.Models;
using NewCustomerIntegration.Services;
using NewCustomerIntegration.Factories;
using NewCustomerIntegration.Controllers;

namespace NewCustomerIntegration
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            var container = new UnityContainer();
                container.RegisterType<INewCustomerAddressService, AddressSvcMVCImpl>();
                container.RegisterType<IController, AddressController>("Address");
                container.RegisterType<INewCustomerOrganizationService, OrganizationSvcMVCImpl>();
                container.RegisterType<IController, OrganizationController>("Organization");
                container.RegisterType<INewCustomerPersonService, PersonSvcMVCImpl>();
                container.RegisterType<IController, PersonController>("Person");
                container.RegisterType<INewCustomerRuleService, RuleSvcMVCImpl>();
                container.RegisterType<IController, RuleController>("Rule");
                container.RegisterType<INewCustomerSiteService, SiteSvcMVCImpl>();
                container.RegisterType<IController, SiteController>("Site");
                container.RegisterType<INewCustomerSiteTypeService, SiteTypeSvcMVCImpl>();
                container.RegisterType<IController, SiteTypeController>("SiteType");
                container.RegisterType<INewCustomerUserTypeService, UserTypeSvcMVCImpl>();
                container.RegisterType<IController, UserTypeController>("UserType");
            var factory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}