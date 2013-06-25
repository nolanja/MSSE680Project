using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using System.Web.Routing;
using System.Configuration;
using NewCustomerIntegration.Domain.Models;
using NewCustomerIntegration.Controllers;
using NewCustomerIntegration.Services;
using System.Collections.Specialized;
using System.Reflection;

namespace NewCustomerIntegration.Factories
{
    public class NewCustomerIntegrationFactory
    {
        private NewCustomerIntegrationFactory()
        {
        }

        private static NewCustomerIntegrationFactory factory = new NewCustomerIntegrationFactory();
        public static NewCustomerIntegrationFactory GetInstance()
        {
            return factory;
        }

        public IService GetService(String serviceName,params object[] args)
        {
            Type type;
            Object obj = null;

            try
            {
                type = Type.GetType(GetImplName(serviceName));
                obj = Activator.CreateInstance(type, args);
            }
            catch (Exception e)
            {
                throw new Exception("Exception occured: {0}", e);
            }
            return (IService) obj;
        }

        private string GetImplName(string serviceName)
        {
            NameValueCollection settings = ConfigurationManager.AppSettings;
            return settings.Get(serviceName);
        }
        
    }
}