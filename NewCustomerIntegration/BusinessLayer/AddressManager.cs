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
    public class AddressManagement : Manager
    {
        public DBIntegrationContext context;

        public AddressManagement()
        {
            this.context = new DBIntegrationContext();
        }

        public AddressManagement(DBIntegrationContext dbContext)
        {
            this.context = dbContext;
        }

        public void ListAddresses()
        {

            try
            {
                INewCustomerAddressService addSvc =
                    (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name, context);
                addSvc.GetAddresses();
            }
            catch (Exception e)
            {
                throw new Exception("Cannot get list addresses " + e.GetType().Name);
            }
        }

        public void AddressDetails(long id)
        {
            try
            {
                INewCustomerAddressService addSvc =
                    (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name, context);
                addSvc.AddressDetails(id);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot get address details " + e.GetType().Name);
            }
        }

        public void AddressCreate()
        {
            try
            {
                INewCustomerAddressService addSvc =
                    (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name, context);
                addSvc.AddressCreateSiteKey();
            }
            catch (Exception e)
            {
                throw new Exception("Cannot create address key " + e.GetType().Name);
            }
        }

        public void AddressCreate(Address address)
        {
            try
            {
                INewCustomerAddressService addSvc =
                    (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name, context);
                addSvc.AddressCreateSiteKey();
                addSvc.AddressCreate(address);
                addSvc.AddressWriteSiteKey(address);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot create address " + e.GetType().Name);
            }
        }

        public void AddressEdit(long id)
        {
            try
            {
                INewCustomerAddressService addSvc =
                    (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name, context);
                addSvc.AddressEdit(id);

            }
            catch (Exception e)
            {
                throw new Exception("Cannot edit address " + e.GetType().Name);
            }
        }

        public void AddressEdit(Address address)
        {
            try
            {
                INewCustomerAddressService addSvc =
                    (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name, context);
                addSvc.AddressEdit(address);
                addSvc.AddressWriteSiteKey(address);

            }
            catch (Exception e)
            {
                throw new Exception("Cannot edit address " + e.GetType().Name);
            }
        }

        public void AddressDelete(long id)
        {
            try
            {
                INewCustomerAddressService addSvc =
                    (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name, context);
                addSvc.AddressDelete(id);

            }
            catch (Exception e)
            {
                throw new Exception("Cannot delete address " + e.GetType().Name);
            }
        }

        public void AddressDeleteConfirmed(long id)
        {
            try
            {
                INewCustomerAddressService addSvc =
                    (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name, context);
                addSvc.AddressDeleteConfirmed(id);

            }
            catch (Exception e)
            {
                throw new Exception("Cannot confirm address deleted " + e.GetType().Name);
            }
        }

        public void AddressDispose(bool dispose)
        {
            try
            {
                INewCustomerAddressService addSvc =
                    (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name, context);
                addSvc.AddressDispose(dispose);

            }
            catch (Exception e)
            {
                throw new Exception("Cannot confirm address deleted " + e.GetType().Name);
            }
        }

    }
}