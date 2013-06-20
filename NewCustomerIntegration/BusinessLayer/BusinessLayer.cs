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
    public class BusinessLayer
    {
        public class OrganizationManagement : Manager
        {
            public void OrganizationListNames()
            {
                
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.GetOrganizationNames();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list organization names " + e.GetType().Name);
                }
            }

            public void OrganizationDetails(long id)
            {
                
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get organization details " + e.GetType().Name);
                }
            }

            public void OrganizationCreate(Organization organization)
            {
 
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationCreate(organization);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create organization " + e.GetType().Name);
                }
            }

            public void OrganizationEdit(long id)
            {

                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationEdit(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit organization " + e.GetType().Name);
                }
            }

            public void OrganizationEdit(Organization organization)
            {

                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationEdit(organization);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit organization " + e.GetType().Name);
                }
            }

            public void OrganizationDelete(long id)
            {

                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationDelete(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot delete organization " + e.GetType().Name);
                }
            }

            public void OrganizationDeleteConfirmed(long id)
            {

                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationDeleteConfirmed(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot delete organization " + e.GetType().Name);
                }
            }

            public void OrganizationDispose(bool disposing)
            {

                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationDispose(disposing);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot dispose of organization " + e.GetType().Name);
                }
            }

        }

        public class AddressManagement : Manager
        {
            public void ListAddresses()
            {

                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name);
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
                        (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name);
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
                        (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name);
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
                        (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name);
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
                        (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name);
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
                        (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name);
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
                        (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name);
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
                        (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name);
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
                        (INewCustomerAddressService)GetService(typeof(INewCustomerAddressService).Name);
                    addSvc.AddressDispose (dispose);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot confirm address deleted " + e.GetType().Name);
                }
            }

        }

        public class PeopleManagement : Manager
        {
            public void ListPeople()
            {
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.GetPeople();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list of People " + e.GetType().Name);
                }
            }

            public void PersonDetails(long id)
            {
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get Person details " + e.GetType().Name);
                }
            }

            public void PersonCreate()
            {
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonCreateOrganizationIDKey();
                    personSvc.PersonCreateUserTypeIDKey();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create Person key " + e.GetType().Name);
                }
            }

            public void PersonCreate(Person person)
            {
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonCreate(person);
                    //personSvc.PersonWriteOrganizationIDKey(person);
                    //personSvc.PersonWriteUserTypeIDKey(person);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create Person " + e.GetType().Name);
                }
            }

            public void PersonEdit(long id)
            {
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name);
                    Person person = personSvc.PersonEdit(id);
                    personSvc.PersonWriteOrganizationIDKey(person);
                    personSvc.PersonWriteUserTypeIDKey(person);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit Person " + e.GetType().Name);
                }
            }

            public void PersonEdit(Person person)
            {
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonEdit(person);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit Person " + e.GetType().Name);
                }
            }

            public void PersonDelete(long id)
            {
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonDelete(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot delete Person " + e.GetType().Name);
                }
            }

            public void PersonDeleteConfirmed(long id)
            {
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonDeleteConfirmed(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot confirm Person deleted " + e.GetType().Name);
                }
            }

            public void PersonDispose(bool dispose)
            {
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PeopleDispose(dispose);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot confirm Person deleted " + e.GetType().Name);
                }
            }
        }

        public class SiteManagement : Manager
        {
            public void SiteCreate(Site site)
            {
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.SiteCreateOrganizationIDKey();
                    siteSvc.SiteCreateSiteTypeIDKey();
                    siteSvc.SiteCreate(site);
                    siteSvc.SiteWriteOrganizationIDKey(site);
                    siteSvc.SiteWriteSiteTypeIDKey(site);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create site " + e.GetType().Name);
                }
            }

            public void SiteEdit(Site site)
            {
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.SiteCreateOrganizationIDKey();
                    siteSvc.SiteCreateSiteTypeIDKey();
                    siteSvc.SiteEdit(site);
                    siteSvc.SiteWriteOrganizationIDKey(site);
                    siteSvc.SiteWriteSiteTypeIDKey(site);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Edit site " + e.GetType().Name);
                }
            }

            public void SiteList()
            {
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.GetSites();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot List site " + e.GetType().Name);
                }
            }

            public void SiteDelete(long id)
            {
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.SiteDelete(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Delete site " + e.GetType().Name);
                }
            }

            public void SiteDeleteConfirm(long id)
            {
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.SiteDeleteConfirmed(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Deleted site " + e.GetType().Name);
                }
            }

            public void SiteDipose(bool disposing)
            {
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.SiteDispose(disposing);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Dispose site " + e.GetType().Name);
                }
            }

        }

        public class SiteTypeManagement : Manager
        {
            public void ListSiteTypes()
            {
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.GetSiteTypes();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list of site types " + e.GetType().Name);
                }
            }

            public void SiteTypeDetails(long id)
            {
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get site types details " + e.GetType().Name);
                }
            }

            public void SiteTypeCreate(SiteType siteType)
            {
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)GetService(typeof (INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeCreate(siteType);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create site type " + e.GetType().Name);
                }
            }

            public void SiteTypeEdit(long id)
            {
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeEdit(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Edit site type " + e.GetType().Name);
                }
            }

            public void SiteTypeEdit(SiteType siteType)
            {
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeEdit(siteType);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Edit site type " + e.GetType().Name);
                }
            }

            public void SiteTypeDelete(long id)
            {
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeDelete(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Delete site type " + e.GetType().Name);
                }
            }

            public void SiteTypeDeleteConfirmed(long id)
            {
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeDeleteConfirmed(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Delete site type " + e.GetType().Name);
                }
            }

            public void SiteTypeDispose(bool disposing)
            {
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeDispose(disposing);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Delete site type " + e.GetType().Name);
                }
            }
        }

        public class UserTypeManagement : Manager
        {
            public void ListUserTypes()
            {
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.GetUserTypes();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list of User types " + e.GetType().Name);
                }
            }

            public void UserTypeDetails(long id)
            {
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get User types details " + e.GetType().Name);
                }
            }

            public void UserTypeCreate(UserType userType)
            {
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeCreate(userType);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create User type " + e.GetType().Name);
                }
            }

            public void UserTypeEdit(long id)
            {
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeEdit(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Edit User type " + e.GetType().Name);
                }
            }

            public void UserTypeEdit(UserType userType)
            {
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeEdit(userType);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Edit User type " + e.GetType().Name);
                }
            }

            public void UserTypeDelete(long id)
            {
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeDelete(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Delete User type " + e.GetType().Name);
                }
            }

            public void UserTypeDeleteConfirmed(long id)
            {
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeDeleteConfirmed(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Delete User type " + e.GetType().Name);
                }
            }

            public void UserTypeDispose(bool disposing)
            {
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeDispose(disposing);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Delete User type " + e.GetType().Name);
                }
            }
        }

        public class RuleManagement : Manager
        {
            public void ListRules()
            {
                try
                {
                    INewCustomerRuleService ruleSvc =
                        (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name);
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
                        (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name);
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
                        (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name);
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
                        (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name);
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
                        (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name);
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
                        (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name);
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
                        (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name);
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
                        (INewCustomerRuleService)GetService(typeof(INewCustomerRuleService).Name);
                    ruleSvc.RuleDispose(disposing);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot dispose of deleted rule" + e.GetType().Name);
                }
            }
        }
    }
}