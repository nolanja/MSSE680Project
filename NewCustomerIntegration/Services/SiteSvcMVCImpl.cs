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
    public class SiteSvcMVCImpl : INewCustomerSiteService 
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public void StoreSites(Site sites)
        {
            try
            {
                FileStream fileStream = new FileStream
            ("Sites.bin", FileMode.Create, FileAccess.Write);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, sites);
                fileStream.Close();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create Sites.bin " + e.GetType().Name);
            }
        }

        public ArrayList RetrieveSites()
        {
            try
            {
                FileStream fileStream = new FileStream
            ("Sites.bin", FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                ArrayList sites = formatter.Deserialize(fileStream) as ArrayList;
                fileStream.Close();
                return sites;
            }
            catch (FileNotFoundException e)
            {
                
                throw new FileNotFoundException("Unable to open file Sites.bin " + e.GetType().Name);
            }
        } 

        public IList<Site> GetSites()
        {
            try
            {
                var sites = customerDB.Sites.Include(s => s.Organization).Include(s => s.SiteType);
                return sites.ToList();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to list sites " + e.GetType().Name);
            }
        }

        public Site SiteDetails(long id)
        {
            try
            {
                return this.customerDB.Sites.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find " + id.ToString() + e.GetType().Name);
            }
        }

        public dynamic SiteCreateOrganizationIDKey()
        {
            try
            {
                var organizationID = new SelectList(customerDB.Organizations, "OrganizationId", "OrganizationCode");
                return organizationID;
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create Organization ID key " + e.GetType().Name);
            }
        }

        public dynamic SiteCreateSiteTypeIDKey()
        {
            try
            {
                var siteTypeID = new SelectList(customerDB.SiteTypes, "SiteTypeId", "SiteTypeName");
                return siteTypeID;
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create Site Type ID key " + e.GetType().Name);
            }
        }

        public dynamic SiteWriteOrganizationIDKey(Site site)
        {
            try
            {
                var organizationID = new SelectList(customerDB.Organizations, "OrganizationId", "OrganizationCode", site.OrganizationId);
                return organizationID;
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to write Organization ID key " + e.GetType().Name);
            }
        }

        public dynamic SiteWriteSiteTypeIDKey(Site site)
        {
            try
            {
                var siteTypeID = new SelectList(customerDB.SiteTypes, "UserTypeId", "UserTypeName", site.SiteTypeId);
                return siteTypeID;
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to write Site Type ID key " + e.GetType().Name);
            }
        }
        public void SiteCreate(Site site)
        {
            try
            {
                this.customerDB.Sites.Add(site);
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create site " + e.GetType().Name);
            }
        }

        public Site SiteEdit(long id)
        {
            try
            {
                return this.customerDB.Sites.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find site " + id.ToString() + e.GetType().Name);
            }
        }

        public void SiteEdit(Site site)
        {
            try
            {
                this.customerDB.Entry(site).State = EntityState.Modified;
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to Edit site " + e.GetType().Name);
            }
        }

        public Site SiteDelete(long id)
        {
            try
            {
                return this.customerDB.Sites.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find " + id.ToString() + e.GetType().Name);
            }
        }

        public void SiteDeleteConfirmed(long id)
        {
            try
            {
                var site = this.customerDB.Sites.Find(id);
                this.customerDB.Sites.Remove(site);
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to remove stite " + id.ToString() + e.GetType().Name);
            }
        }

        public void SiteDispose(bool disposing)
        {
            try
            {
                this.customerDB.Dispose();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to dispose of file" + e.GetType().Name);
            }
        }
    }
}