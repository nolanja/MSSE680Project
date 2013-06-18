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
    public class AddressSvcMVCImpl : INewCustomerAddressService 
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public void StoreAddresses(Address addresses)
        {
            try
            {
                FileStream fileStream = new FileStream
            ("Address.bin", FileMode.Create, FileAccess.Write);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, addresses);
                fileStream.Close();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create Address.bin " + e.GetType().Name);
            }
        }

        public ArrayList RetrieveAddresses()
        {
            try
            {
                FileStream fileStream = new FileStream
            ("Address.bin", FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                ArrayList addresses = formatter.Deserialize(fileStream) as ArrayList;
                fileStream.Close();
                return addresses;
            }
            catch (FileNotFoundException e)
            {
                
                throw new FileNotFoundException("Unable to open Address.bin " + e.GetType().Name);
            }
        } 

        public IList<Address> GetAddresses()
        {

                var addresses = this.customerDB.Addresses.Include(a => a.Site);
                return addresses.ToList();
        }

        public Address AddressDetails(long id)
        {
            try
            {
                return this.customerDB.Addresses.Find(id);
            }
            catch (IOException e)
            {
                throw new IOException("Unable to find Address " + e.GetType().Name);
            }
        }

        public dynamic AddressCreateSiteKey()
        {
            try
            {
                var siteID = new SelectList(this.customerDB.Sites, "SiteId", "SiteName");
                return siteID;
            }
            catch (IOException e)
            {
                throw new IOException("Unable to create site key " + e.GetType().Name);
            }
        }

        public dynamic AddressWriteSiteKey(Address address)
        {

            try
            {
                var siteID = new SelectList(this.customerDB.Sites, "SiteId", "SiteName", address.SiteId);
                return siteID;
            }
            catch (IOException e)
            {

                throw new IOException("Unable to write stie key" + e.GetType().Name);
            }
        }

        public void AddressCreate(Address address)
        {
            try
            {
                this.customerDB.Addresses.Add(address);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find address " + e.GetType().Name);
            }
            try
            {
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to write to File " + e.GetType().Name);
            }

        }

        public Address AddressEdit(long id)
        {
            try
            {
                return this.customerDB.Addresses.Find(id);
            }
            catch (Exception e)
            {
                
                throw new IOException("The address " + id.ToString() + "can't be found " + e.GetType().Name);
            }
        }

        public void AddressEdit(Address address)
        {
            try
            {
                this.customerDB.Entry(address).State = EntityState.Modified;
            }
            catch (Exception)
            {
                
                throw new IOException ("Unable to find " + address);
            }
            try
            {
                this.customerDB.SaveChanges();
            }
            catch (Exception e)
            {
                
                throw new IOException("Unable to save address file" + e.GetType().Name);
            }
        }

        public Address AddressDelete(long id)
        {
            try
            {
                return this.customerDB.Addresses.Find(id);
            }
            catch (Exception e)
            {
                
                throw new IOException ("Unable to locate " + id.ToString() +e.GetType().Name);
            }
        }

        public void AddressDeleteConfirmed(long id)
        {
            try
            {
                var address = this.customerDB.Addresses.Find(id);
                this.customerDB.Addresses.Remove(address);
            }
            catch (IOException e1)
            {

                throw new IOException("Unable to remove address " + id.ToString() + e1.GetType().Name);
            }


            try
            {
                this.customerDB.SaveChanges();
            }
            catch (Exception e)
            {
                
                throw new FileNotFoundException("Unable to find file" + e.GetType().Name);
            }
        }

        public void AddressDispose(bool disposing)
        {
            try
            {
                this.customerDB.Dispose();
            }
            catch (FileNotFoundException e)
            {
                
                throw new FileNotFoundException("Unable to find file " + e.GetType().Name);
            }
        }
    }
}