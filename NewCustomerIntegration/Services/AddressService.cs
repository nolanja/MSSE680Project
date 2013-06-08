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
    public class AddressService : INewCustomerAddressService
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public IList<Address> GetAddresses()
        {
            var addresses = this.customerDB.Addresses.Include(a => a.Site);
            return addresses.ToList();

        }

        public Address AddressDetails(long id)
        {
            return this.customerDB.Addresses.Find(id);
        }

        public dynamic AddressCreateSiteKey()
        {
             var siteID = new SelectList(this.customerDB.Sites, "SiteId", "SiteName");
            return siteID;
        }

        public dynamic AddressWriteSiteKey(Address address)
        {
            var siteID = new SelectList(this.customerDB.Sites, "SiteId", "SiteName", address.SiteId);
            return siteID;
        }

        public void AddressCreate(Address address)
        {
            this.customerDB.Addresses.Add(address);
            this.customerDB.SaveChanges();

        }

        public Address AddressEdit(long id)
        {
            return this.customerDB.Addresses.Find(id);
        }

        public void AddressEdit(Address address)
        {
            this.customerDB.Entry(address).State = EntityState.Modified;
            this.customerDB.SaveChanges();
        }

        public Address AddressDelete(long id)
        {
            return this.customerDB.Addresses.Find(id);
        }

        public void AddressDeleteConfirmed(long id)
        {
            var address = this.customerDB.Addresses.Find(id);
            this.customerDB.Addresses.Remove(address);
            this.customerDB.SaveChanges();
        }

        public void AddressDispose(bool disposing)
        {
            this.customerDB.Dispose();
        }
    }
}