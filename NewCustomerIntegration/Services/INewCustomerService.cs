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
        void AddressCreate(NewCustomerIntegration.Domain.Models.Address address);
        dynamic AddressCreateSiteKey();
        NewCustomerIntegration.Domain.Models.Address AddressDelete(long id);
        void AddressDeleteConfirmed(long id);
        NewCustomerIntegration.Domain.Models.Address AddressDetails(long id);
        void AddressDispose(bool disposing);
        void AddressEdit(NewCustomerIntegration.Domain.Models.Address address);
        NewCustomerIntegration.Domain.Models.Address AddressEdit(long id);
        dynamic AddressWriteSiteKey(NewCustomerIntegration.Domain.Models.Address address);
        System.Collections.Generic.IList<NewCustomerIntegration.Domain.Models.Address> GetAddresses();
    }

    public interface INewCustomerPersonService
    {
        System.Collections.Generic.IList<NewCustomerIntegration.Domain.Models.Person> GetPeople();
        void PeopleDispose(bool disposing);
        void PersonCreate(NewCustomerIntegration.Domain.Models.Person person);
        dynamic PersonCreateOrganizationIDKey();
        dynamic PersonCreateUserTypeIDKey();
        NewCustomerIntegration.Domain.Models.Person PersonDelete(long id = 0);
        void PersonDeleteConfirmed(long id);
        NewCustomerIntegration.Domain.Models.Person PersonDetails(long id = 0);
        void PersonEdit(NewCustomerIntegration.Domain.Models.Person person);
        NewCustomerIntegration.Domain.Models.Person PersonEdit(long id = 0);
        dynamic PersonWriteOrganizationIDKey(NewCustomerIntegration.Domain.Models.Person person);
        dynamic PersonWriteUserTypeIDKey(NewCustomerIntegration.Domain.Models.Person person);
    }

    public interface INewCustomerSiteService
    {
        System.Collections.Generic.IList<NewCustomerIntegration.Domain.Models.Site> GetSites();
        dynamic SiteCreateOrganizationIDKey();
        dynamic SiteCreateSiteTypeIDKey();
        dynamic SiteWriteOrganizationIDKey(NewCustomerIntegration.Domain.Models.Site site);
        dynamic SiteWriteSiteTypeIDKey(NewCustomerIntegration.Domain.Models.Site site);
        void SiteCreate(NewCustomerIntegration.Domain.Models.Site site);
        NewCustomerIntegration.Domain.Models.Site SiteDelete(long id = 0);
        void SiteDeleteConfirmed(long id);
        NewCustomerIntegration.Domain.Models.Site SiteDetails(long id = 0);
        void SiteDispose(bool disposing);
        void SiteEdit(NewCustomerIntegration.Domain.Models.Site site);
        NewCustomerIntegration.Domain.Models.Site SiteEdit(long id = 0);
    }

    public interface INewCustomerSiteTypeService
    {
        System.Collections.Generic.IList<long> GetSiteTypes();
        void SiteTypeCreate(NewCustomerIntegration.Domain.Models.SiteType sitetype);
        NewCustomerIntegration.Domain.Models.SiteType SiteTypeDelete(long id);
        void SiteTypeDeleteConfirmed(long id);
        NewCustomerIntegration.Domain.Models.SiteType SiteTypeDetails(long id);
        void SiteTypeDispose(bool disposing);
        void SiteTypeEdit(NewCustomerIntegration.Domain.Models.SiteType sitetype);
        NewCustomerIntegration.Domain.Models.SiteType SiteTypeEdit(long id);
    }

    public interface INewCustomerUserTypeService
    {
        System.Collections.Generic.IList<long> GetUserTypes();
        void UserTypeCreate(NewCustomerIntegration.Domain.Models.UserType usertype);
        NewCustomerIntegration.Domain.Models.UserType UserTypeDelete(long id);
        void UserTypeDeleteConfirmed(long id);
        NewCustomerIntegration.Domain.Models.UserType UserTypeDetails(long id);
        void UserTypeDispose(bool disposing);
        void UserTypeEdit(NewCustomerIntegration.Domain.Models.UserType usertype);
        NewCustomerIntegration.Domain.Models.UserType UserTypeEdit(long id);
    }

    public interface INewCustomerRuleService
    {
        System.Collections.Generic.IList<long> GetRules();
        void RuleCreate(NewCustomerIntegration.Domain.Models.Rule rule);
        NewCustomerIntegration.Domain.Models.Rule RuleDelete(long id);
        void RuleDeleteConfirmed(long id);
        NewCustomerIntegration.Domain.Models.Rule RuleDetails(long id);
        void RuleDispose(bool disposing);
        void RuleEdit(NewCustomerIntegration.Domain.Models.Rule rule);
        NewCustomerIntegration.Domain.Models.Rule RuleEdit(long id);
    }
}