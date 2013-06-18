using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NewCustomerIntegration.Services;
using NewCustomerIntegration.Domain.Models;
using NewCustomerIntegration.Factories;

namespace NewCustomerIntegration.Services
{
    public class RuleSvcMVCImpl  : INewCustomerRuleService 
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public void StoreRules(NewCustomerIntegration.Domain.Models.Rule rules)
        {
            try
            {
                FileStream fileStream = new FileStream
            ("Rules.bin", FileMode.Create, FileAccess.Write);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, rules);
                fileStream.Close();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create Rules.bin " + e.GetType().Name);
            }
        }

        public ArrayList RetrieveRules()
        {
            try
            {
                FileStream fileStream = new FileStream
            ("Rules.bin", FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                ArrayList rules = formatter.Deserialize(fileStream) as ArrayList;
                fileStream.Close();
                return rules;
            }
            catch (FileNotFoundException e)
            {
                
                throw new FileNotFoundException("Unable to open file Rules.bin " + e.GetType().Name);
            }
        } 

        public IList<NewCustomerIntegration.Domain.Models.Rule> GetRules()
        {
            try
            {
                var rules = customerDB.Rules;
                return rules.ToList();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to list Rules " + e.GetType().Name);
            }
        }

        public NewCustomerIntegration.Domain.Models.Rule RuleDetails(long id)
        {
            try
            {
                return this.customerDB.Rules.Find(id);
            }
            catch (IOException e)
            {

                throw new IOException("Unable to find " + id.ToString() + e.GetType().Name);
            }
        }

        public void RuleCreate(NewCustomerIntegration.Domain.Models.Rule rule)
        {
            try
            {
                this.customerDB.Rules.Add(rule);
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create rule " + e.GetType().Name);
            }
        }

        public NewCustomerIntegration.Domain.Models.Rule RuleEdit(long id)
        {
            try
            {
                return this.customerDB.Rules.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find rule " + id.ToString() + e.GetType().Name);
            }
        }

        public void RuleEdit(NewCustomerIntegration.Domain.Models.Rule rule)
        {
            try
            {
                this.customerDB.Entry(rule).State = EntityState.Modified;
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to edit rule " + e.GetType().Name);
            }
        }

        public NewCustomerIntegration.Domain.Models.Rule RuleDelete(long id)
        {
            try
            {
                return this.customerDB.Rules.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find rule " + id.ToString() + e.GetType().Name);
            }
        }

        public void RuleDeleteConfirmed(long id)
        {
            try
            {
                var rule = this.customerDB.Rules.Find(id);
                this.customerDB.Rules.Remove(rule);
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to remove rule " + id.ToString() + e.GetType().Name);
            }
        }

        public void RuleDispose(bool disposing)
        {
            try
            {
                this.customerDB.Dispose();
            }
            catch (IOException e)
            {
                
                throw new IOException("unable to dispose of file " + e.GetType().Name);
            }
        }
    }
}