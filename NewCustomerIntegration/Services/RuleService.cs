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
    public class RuleService : INewCustomerRuleService
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public IList<NewCustomerIntegration.Domain.Models.Rule> GetRules()
        {
            var rules = customerDB.Rules;

            return rules.ToList();
        }

        public NewCustomerIntegration.Domain.Models.Rule RuleDetails(long id)
        {
            return this.customerDB.Rules.Find(id);
        }

        public void RuleCreate(NewCustomerIntegration.Domain.Models.Rule rule)
        {
            this.customerDB.Rules.Add(rule);
            this.customerDB.SaveChanges();
        }

        public NewCustomerIntegration.Domain.Models.Rule RuleEdit(long id)
        {
            return this.customerDB.Rules.Find(id);
        }

        public void RuleEdit(NewCustomerIntegration.Domain.Models.Rule rule)
        {
            this.customerDB.Entry(rule).State = EntityState.Modified;
            this.customerDB.SaveChanges();
        }

        public NewCustomerIntegration.Domain.Models.Rule RuleDelete(long id)
        {
            return this.customerDB.Rules.Find(id);
        }

        public void RuleDeleteConfirmed(long id)
        {
            var rule = this.customerDB.Rules.Find(id);
            this.customerDB.Rules.Remove(rule);
            this.customerDB.SaveChanges();
        }

        public void RuleDispose(bool disposing)
        {
            this.customerDB.Dispose();
        }
    }
}