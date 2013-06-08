using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewCustomerIntegration.Domain.Models;

namespace NewCustomerIntegration.Services
{
    public interface INewCustomerOrganizationService
    {
        // Organization Service Interfaces
        IList<string> GetOrganizationNames();
        Organization OrganizationDetails(long id);
        void OrganizationCreate(Organization organization);
        Organization OrganizationEdit(long id);
        void OrganizationEdit(Organization organization);
        Organization OrganizationDelete(long id);
        void OrganizationDeleteConfirmed(long id);
        void OrganizationDispose(bool disposing);
    }

    public interface INewCustomerAddressService
    {
        // Address Service Interfaces
        IList<Address> GetAddresses();
        Address AddressDetails(long id);
        dynamic AddressCreateSiteKey();
        dynamic AddressWriteSiteKey(Address address);
        void AddressCreate(Address address);
        Address AddressEdit(long id);
        void AddressEdit(Address address);
        Address AddressDelete(long id);
        void AddressDeleteConfirmed(long id);
        void AddressDispose(bool disposing);
    }
}