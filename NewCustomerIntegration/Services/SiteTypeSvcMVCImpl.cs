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
    public class SiteTypeSvcMVCImpl  : INewCustomerSiteTypeService 
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public void StoreSiteTypes(SiteType siteTypes)
        {
            try
            {
                FileStream fileStream = new FileStream
            ("SiteTypes.bin", FileMode.Create, FileAccess.Write);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, siteTypes);
                fileStream.Close();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create file SiteTypes.bin " + e.GetType().Name);
            }
        }

        public ArrayList RetrieveSiteTypes()
        {
            try
            {
                FileStream fileStream = new FileStream
            ("SiteTypes.bin", FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                ArrayList siteTypes = formatter.Deserialize(fileStream) as ArrayList;
                fileStream.Close();
                return siteTypes;
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to read file SiteTypes.bin" + e.GetType().Name);
            }
        }


        public IList<SiteType> GetSiteTypes()
        {
            try
            {
                var sitetypes = customerDB.SiteTypes;

                return sitetypes.ToList();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to list sites " + e.GetType().Name);
            }
        }

        public SiteType SiteTypeDetails(long id)
        {
            try
            {
                return this.customerDB.SiteTypes.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find site type " + id.ToString() + e.GetType().Name);
            }
        }

        public void SiteTypeCreate(SiteType sitetype)
        {
            try
            {
                this.customerDB.SiteTypes.Add(sitetype);
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create SiteType " + e.GetType().Name);
            }
        }

        public SiteType SiteTypeEdit(long id)
        {
            try
            {
                return this.customerDB.SiteTypes.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find Site Type ID " + id.ToString() + e.GetType().Name);
            }
        }

        public void SiteTypeEdit(SiteType sitetype)
        {
            try
            {
                this.customerDB.Entry(sitetype).State = EntityState.Modified;
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to edit Site Type " + e.GetType().Name);
            }
        }

        public SiteType SiteTypeDelete(long id)
        {
            try
            {
                return this.customerDB.SiteTypes.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find Site Type ID " + id.ToString() + e.GetType().Name);
            }
        }

        public void SiteTypeDeleteConfirmed(long id)
        {
            try
            {
                var sitetype = this.customerDB.SiteTypes.Find(id);
                this.customerDB.SiteTypes.Remove(sitetype);
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to remove Site Type " + id.ToString() + e.GetType().Name);
            }
        }

        public void SiteTypeDispose(bool disposing)
        {
            try
            {
                this.customerDB.Dispose();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to dispose of Site Type " + e.GetType().Name);
            }
        }
    }
}