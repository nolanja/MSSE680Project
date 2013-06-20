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
    public abstract class Manager
    {
        private NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();

        protected IService GetService(String name)
        {
            return factory.GetService(name);
        }
    }
}