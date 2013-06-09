using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
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
                container.RegisterType<INewCustomerAddressService, AddressService>()
                .RegisterType<IController, AddressController>("Address");
                container.RegisterType<INewCustomerOrganizationService, OrganizationService>()
                .RegisterType<IController, OrganizationController>("Organization");
                container.RegisterType<INewCustomerPersonService, PersonService>()
                .RegisterType<IController, PersonController>("Person");
                container.RegisterType<INewCustomerRuleService, RuleService>()
                .RegisterType<IController, RuleController>("Rule");
                container.RegisterType<INewCustomerSiteService, SiteService>()
                .RegisterType<IController, SiteController>("Site");
                container.RegisterType<INewCustomerSiteTypeService, SiteTypeService>()
                .RegisterType<IController, SiteTypeController>("SiteType");
                container.RegisterType<INewCustomerUserTypeService, UserTypeService>()
                .RegisterType<IController, UserTypeController>("UserType");
            var factory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}