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
    public class RuleManagement : Manager
    {
        public DBIntegrationContext context;

        public RuleManagement()
        {
            this.context = new DBIntegrationContext();
        }

        public RuleManagement(DBIntegrationContext dbContext)
        {
            this.context = dbContext;
        }

        public void ListRules()
        {
            try
            {
                INewCustomerRuleService ruleSvc =
                    (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name, context);
                ruleSvc.GetRules();
            }
            catch (Exception e)
            {
                throw new Exception("Cannot get list of rules " + e.GetType().Name);
            }
        }
        public void RuleDetails(long id)
        {
            try
            {
                INewCustomerRuleService ruleSvc =
                    (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name, context);
                ruleSvc.RuleDetails(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot get rule details" + e.GetType().Name);
            }
        }

        public void RuleCreate(Rule rule)
        {
            try
            {
                INewCustomerRuleService ruleSvc =
                    (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name, context);
                ruleSvc.RuleCreate(rule);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot create rule" + e.GetType().Name);
            }
        }

        public void RuleEdit(long id)
        {
            try
            {
                INewCustomerRuleService ruleSvc =
                    (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name, context);
                ruleSvc.RuleEdit(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot edit rule" + e.GetType().Name);
            }
        }

        public void RuleEdit(Rule rule)
        {
            try
            {
                INewCustomerRuleService ruleSvc =
                    (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name, context);
                ruleSvc.RuleEdit(rule);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot edit rule" + e.GetType().Name);
            }
        }

        public void RuleDelete(long id)
        {
            try
            {
                INewCustomerRuleService ruleSvc =
                    (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name, context);
                ruleSvc.RuleDelete(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot delete rule" + e.GetType().Name);
            }
        }

        public void RuleDeleteConfirmed(long id)
        {
            try
            {
                INewCustomerRuleService ruleSvc =
                    (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name, context);
                ruleSvc.RuleDeleteConfirmed(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot confirm deleted rule" + e.GetType().Name);
            }
        }

        public void RuleDispose(bool disposing)
        {
            try
            {
                INewCustomerRuleService ruleSvc =
                    (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name, context);
                ruleSvc.RuleDispose(disposing);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot dispose of deleted rule" + e.GetType().Name);
            }
        }
    }
}