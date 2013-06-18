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
        public class OrganizationManagement
        {
            public void OrganizationListNames()
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)factory.GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.GetOrganizationNames();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list organization names " + e.GetType().Name);
                }
            }

            public void OrganizationDetails(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)factory.GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get organization details " + e.GetType().Name);
                }
            }

            public void OrganizationCreate(Organization organization)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)factory.GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationCreate(organization);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create organization " + e.GetType().Name);
                }
            }

            public void OrganizationEdit(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)factory.GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationEdit(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit organization " + e.GetType().Name);
                }
            }

            public void OrganizationEdit(Organization organization)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)factory.GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationEdit(organization);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit organization " + e.GetType().Name);
                }
            }

            public void OrganizationDelete(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)factory.GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationDelete(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot delete organization " + e.GetType().Name);
                }
            }

            public void OrganizationDeleteConfirmed(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)factory.GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationDeleteConfirmed(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot delete organization " + e.GetType().Name);
                }
            }

            public void OrganizationDispose(bool disposing)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerOrganizationService orgSvc =
                        (INewCustomerOrganizationService)factory.GetService(typeof(INewCustomerOrganizationService).Name);
                    orgSvc.OrganizationDispose(disposing);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot dispose of organization " + e.GetType().Name);
                }
            }

        }

        public class AddressManagement
        {
            public void ListAddresses()
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)factory.GetService(typeof(INewCustomerAddressService).Name);
                    addSvc.GetAddresses();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list addresses " + e.GetType().Name);
                }
            }

            public void AddressDetails(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)factory.GetService(typeof(INewCustomerAddressService).Name);
                    addSvc.AddressDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get address details " + e.GetType().Name);
                }
            }

            public void AddressCreate()
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)factory.GetService(typeof(INewCustomerAddressService).Name);
                    addSvc.AddressCreateSiteKey();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create address key " + e.GetType().Name);
                }
            }

            public void AddressCreate(Address address)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)factory.GetService(typeof(INewCustomerAddressService).Name);
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
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)factory.GetService(typeof(INewCustomerAddressService).Name);
                    addSvc.AddressEdit(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit address " + e.GetType().Name);
                }
            }

            public void AddressEdit(Address address)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)factory.GetService(typeof(INewCustomerAddressService).Name);
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
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)factory.GetService(typeof(INewCustomerAddressService).Name);
                    addSvc.AddressDelete(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot delete address " + e.GetType().Name);
                }
            }

            public void AddressDeleteConfirmed(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)factory.GetService(typeof(INewCustomerAddressService).Name);
                    addSvc.AddressDeleteConfirmed(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot confirm address deleted " + e.GetType().Name);
                }
            }

            public void AddressDispose(bool dispose)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerAddressService addSvc =
                        (INewCustomerAddressService)factory.GetService(typeof(INewCustomerAddressService).Name);
                    addSvc.AddressDispose (dispose);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot confirm address deleted " + e.GetType().Name);
                }
            }

        }

        public class PeopleManagement
        {
            public void ListPeople()
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)factory.GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.GetPeople();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list of People " + e.GetType().Name);
                }
            }

            public void PersonDetails(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)factory.GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get Person details " + e.GetType().Name);
                }
            }

            public void PersonCreate()
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)factory.GetService(typeof(INewCustomerPersonService).Name);
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
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)factory.GetService(typeof(INewCustomerPersonService).Name);
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
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)factory.GetService(typeof(INewCustomerPersonService).Name);
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
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)factory.GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonEdit(person);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit Person " + e.GetType().Name);
                }
            }

            public void PersonDelete(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)factory.GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonDelete(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot delete Person " + e.GetType().Name);
                }
            }

            public void PersonDeleteConfirmed(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)factory.GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PersonDeleteConfirmed(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot confirm Person deleted " + e.GetType().Name);
                }
            }

            public void PersonDispose(bool dispose)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerPersonService personSvc =
                        (INewCustomerPersonService)factory.GetService(typeof(INewCustomerPersonService).Name);
                    personSvc.PeopleDispose(dispose);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot confirm Person deleted " + e.GetType().Name);
                }
            }
        }

        public class SiteManagement
        {
            public void SiteCreate(Site site)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService) factory.GetService(typeof(INewCustomerSiteService).Name);
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
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)factory.GetService(typeof(INewCustomerSiteService).Name);
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
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)factory.GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.GetSites();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot List site " + e.GetType().Name);
                }
            }

            public void SiteDelete(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)factory.GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.SiteDelete(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Delete site " + e.GetType().Name);
                }
            }

            public void SiteDeleteConfirm(long id)
            {
                                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)factory.GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.SiteDeleteConfirmed(id);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Deleted site " + e.GetType().Name);
                }
            }

            public void SiteDipose(bool disposing)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteService siteSvc =
                        (INewCustomerSiteService)factory.GetService(typeof(INewCustomerSiteService).Name);
                    siteSvc.SiteDispose(disposing);

                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Dispose site " + e.GetType().Name);
                }
            }

        }

        public class SiteTypeManagement
        {
            public void ListSiteTypes()
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)factory.GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.GetSiteTypes();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list of site types " + e.GetType().Name);
                }
            }

            public void SiteTypeDetails(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)factory.GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get site types details " + e.GetType().Name);
                }
            }

            public void SiteTypeCreate(SiteType siteType)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService) factory.GetService(typeof (INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeCreate(siteType);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create site type " + e.GetType().Name);
                }
            }

            public void SiteTypeEdit(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)factory.GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeEdit(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Edit site type " + e.GetType().Name);
                }
            }

            public void SiteTypeEdit(SiteType siteType)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)factory.GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeEdit(siteType);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Edit site type " + e.GetType().Name);
                }
            }

            public void SiteTypeDelete(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)factory.GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeDelete(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Delete site type " + e.GetType().Name);
                }
            }

            public void SiteTypeDeleteConfirmed(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)factory.GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeDeleteConfirmed(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Delete site type " + e.GetType().Name);
                }
            }

            public void SiteTypeDispose(bool disposing)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerSiteTypeService siteTypeSvc =
                        (INewCustomerSiteTypeService)factory.GetService(typeof(INewCustomerSiteTypeService).Name);
                    siteTypeSvc.SiteTypeDispose(disposing);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Delete site type " + e.GetType().Name);
                }
            }
        }

        public class UserTypeManagement
        {
            public void ListUserTypes()
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)factory.GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.GetUserTypes();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list of User types " + e.GetType().Name);
                }
            }

            public void UserTypeDetails(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)factory.GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get User types details " + e.GetType().Name);
                }
            }

            public void UserTypeCreate(UserType userType)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)factory.GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeCreate(userType);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create User type " + e.GetType().Name);
                }
            }

            public void UserTypeEdit(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)factory.GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeEdit(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Edit User type " + e.GetType().Name);
                }
            }

            public void UserTypeEdit(UserType userType)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)factory.GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeEdit(userType);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Edit User type " + e.GetType().Name);
                }
            }

            public void UserTypeDelete(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)factory.GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeDelete(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Delete User type " + e.GetType().Name);
                }
            }

            public void UserTypeDeleteConfirmed(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)factory.GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeDeleteConfirmed(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Delete User type " + e.GetType().Name);
                }
            }

            public void UserTypeDispose(bool disposing)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerUserTypeService userTypeSvc =
                        (INewCustomerUserTypeService)factory.GetService(typeof(INewCustomerUserTypeService).Name);
                    userTypeSvc.UserTypeDispose(disposing);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot Confirm Delete User type " + e.GetType().Name);
                }
            }
        }

        public class RuleManagement
        {
            public void ListRules()
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerRuleService ruleSvc =
                        (INewCustomerRuleService)factory.GetService(typeof(INewCustomerRuleService).Name);
                    ruleSvc.GetRules();
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get list of rules " + e.GetType().Name);
                }
            }
            public void RuleDetails(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerRuleService ruleSvc =
                        (INewCustomerRuleService)factory.GetService(typeof(INewCustomerRuleService).Name);
                    ruleSvc.RuleDetails(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot get rule details" + e.GetType().Name);
                }
            }

            public void RuleCreate(Rule rule)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerRuleService ruleSvc =
                        (INewCustomerRuleService)factory.GetService(typeof(INewCustomerRuleService).Name);
                    ruleSvc.RuleCreate(rule);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot create rule" + e.GetType().Name);
                }
            }

            public void RuleEdit(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerRuleService ruleSvc =
                        (INewCustomerRuleService)factory.GetService(typeof(INewCustomerRuleService).Name);
                    ruleSvc.RuleEdit(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit rule" + e.GetType().Name);
                }
            }

            public void RuleEdit(Rule rule)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerRuleService ruleSvc =
                        (INewCustomerRuleService)factory.GetService(typeof(INewCustomerRuleService).Name);
                    ruleSvc.RuleEdit(rule);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot edit rule" + e.GetType().Name);
                }
            }

            public void RuleDelete(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerRuleService ruleSvc =
                        (INewCustomerRuleService)factory.GetService(typeof(INewCustomerRuleService).Name);
                    ruleSvc.RuleDelete(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot delete rule" + e.GetType().Name);
                }
            }

            public void RuleDeleteConfirmed(long id)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerRuleService ruleSvc =
                        (INewCustomerRuleService)factory.GetService(typeof(INewCustomerRuleService).Name);
                    ruleSvc.RuleDeleteConfirmed(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Cannot confirm deleted rule" + e.GetType().Name);
                }
            }

            public void RuleDispose(bool disposing)
            {
                NewCustomerIntegrationFactory factory = NewCustomerIntegrationFactory.GetInstance();
                try
                {
                    INewCustomerRuleService ruleSvc =
                        (INewCustomerRuleService)factory.GetService(typeof(INewCustomerRuleService).Name);
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