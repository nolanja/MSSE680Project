using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewCustomerIntegration.Domain.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;


namespace NewCustomerIntegration.DomainTests
{
    [TestClass, System.Runtime.InteropServices.GuidAttribute("E832CAAD-4BFF-46CC-AB6D-73222A50D02C")]
    public class DomainUnitTests
    {
        [TestMethod]
        public void SaveNewOrganization()
        {


            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var newOrg = new Organization();

                newOrg.OrganizationCode = "RWF";
                newOrg.OrganizationName = "RealWorld Diners";
                newOrg.PhoneNumber = "208-555-1234";
                newOrg.FaxNumber = "208-555-3421";
                newOrg.ParentOrganizationCode = "4321";
                newOrg.Theme = "Standard";
                newOrg.Skin = "Red";
                newOrg.Active = true;
                newOrg.DELETED = false;
                newOrg.CreatedDateTime = new DateTime();
                newOrg.CreatedBy = "Administrator";
                newOrg.ModifiedDateTime = new DateTime();
                newOrg.ModifiedBy = "Administrator";
                db.Organizations.Add(newOrg);


                //Act
                db.SaveChanges();


                //Assert -- See if the record retrieved matches the one just entered
                var savedOrg = (from d in db.Organizations where d.OrganizationId == newOrg.OrganizationId select d).Single();

                Assert.AreEqual(savedOrg.OrganizationName, newOrg.OrganizationName);
                Assert.AreEqual(savedOrg.OrganizationCode, newOrg.OrganizationCode);
                Assert.AreEqual(savedOrg.PhoneNumber, newOrg.PhoneNumber);
                Assert.AreEqual(savedOrg.FaxNumber, newOrg.FaxNumber);
                Assert.AreEqual(savedOrg.ParentOrganizationCode, newOrg.ParentOrganizationCode);
                Assert.AreEqual(savedOrg.Theme, newOrg.Theme);
                Assert.AreEqual(savedOrg.Skin, newOrg.Skin);
                Assert.AreEqual(savedOrg.Active, newOrg.Active);
                Assert.AreEqual(savedOrg.DELETED, newOrg.DELETED);
                Assert.AreEqual(savedOrg.CreatedDateTime, newOrg.CreatedDateTime);
                Assert.AreEqual(savedOrg.CreatedBy, newOrg.CreatedBy);
                Assert.AreEqual(savedOrg.ModifiedDateTime, newOrg.ModifiedDateTime);
                Assert.AreEqual(savedOrg.ModifiedBy, newOrg.ModifiedBy);


                //cleanup
                db.Organizations.Remove(newOrg);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void SaveNewAddress()
        {

            using (var db = new DBIntegrationContext())
            {
                //Arrange

                var existingSiteType = new SiteType();

                existingSiteType.SiteTypeId = 7;
                existingSiteType.SiteTypeName = "Restaurant";
                existingSiteType.CreatedDateTime = new DateTime();
                existingSiteType.CreatedBy = "Administrator";
                existingSiteType.ModifiedDateTime = new DateTime();
                existingSiteType.ModifiedBy = "Administrator";
                db.SiteTypes.Add(existingSiteType);

                var existingOrg = new Organization();

                existingOrg.OrganizationCode = "RWF";
                existingOrg.OrganizationName = "RealWorld Diners";
                existingOrg.PhoneNumber = "208-555-1234";
                existingOrg.FaxNumber = "208-555-3421";
                existingOrg.ParentOrganizationCode = "4321";
                existingOrg.Theme = "Standard";
                existingOrg.Skin = "Red";
                existingOrg.Active = true;
                existingOrg.DELETED = false;
                existingOrg.CreatedDateTime = new DateTime();
                existingOrg.CreatedBy = "Administrator";
                existingOrg.ModifiedDateTime = new DateTime();
                existingOrg.ModifiedBy = "Administrator";
                db.Organizations.Add(existingOrg);

                var existingSite = new Site();

                existingSite.SiteId = 1;
                existingSite.OrganizationId = existingOrg.OrganizationId;
                existingSite.SiteTypeId = existingSiteType.SiteTypeId;
                existingSite.SiteName = "Little Island";
                existingSite.SiteCode = "RWF001";
                existingSite.TimeZoneId = 8;
                existingSite.CreatedDateTime = new DateTime();
                existingSite.CreatedBy = "Adminstrator";
                existingSite.ModifiedDateTime = new DateTime();
                existingSite.ModifiedBy = "Administrator";
                db.Sites.Add(existingSite);

                var newAdd = new Address();

                newAdd.SiteId = existingSite.SiteId;
                newAdd.AddressTypeId = 5;
                newAdd.AddressLine1 = "RealWorld Food";
                newAdd.AddressLine2 = "101 Maple Str";
                newAdd.AddressLine3 = "Suite 150";
                newAdd.City = "Meridian";
                newAdd.StateProvinceRegionId = 43;
                newAdd.PostalCode = "83646";
                newAdd.CountryRegionId = 01;
                newAdd.CreatedDateTime = new DateTime();
                newAdd.CreatedBy = "Administrator";
                newAdd.ModifiedDateTime = new DateTime();
                newAdd.ModifiedBy = "Administrator";
                db.Addresses.Add(newAdd);

                //Act
                db.SaveChanges();

                //Assert -- See if the record retrieved matches the one just entered
                Address savedAdd = (from d in db.Addresses where d.AddressId == newAdd.AddressId select d).Single();

                Assert.AreEqual(savedAdd.SiteId, newAdd.SiteId);
                Assert.AreEqual(savedAdd.AddressTypeId, newAdd.AddressTypeId);
                Assert.AreEqual(savedAdd.AddressLine1, newAdd.AddressLine1);
                Assert.AreEqual(savedAdd.AddressLine2, newAdd.AddressLine2);
                Assert.AreEqual(savedAdd.AddressLine3, newAdd.AddressLine3);
                Assert.AreEqual(savedAdd.City, newAdd.City);
                Assert.AreEqual(savedAdd.StateProvinceRegionId, newAdd.StateProvinceRegionId);
                Assert.AreEqual(savedAdd.PostalCode, newAdd.PostalCode);
                Assert.AreEqual(savedAdd.CountryRegionId, newAdd.CountryRegionId);
                Assert.AreEqual(savedAdd.CreatedDateTime, newAdd.CreatedDateTime);
                Assert.AreEqual(savedAdd.CreatedBy, newAdd.CreatedBy);
                Assert.AreEqual(savedAdd.ModifiedDateTime, newAdd.ModifiedDateTime);
                Assert.AreEqual(savedAdd.ModifiedBy, newAdd.ModifiedBy);


                //cleanup
                db.Addresses.Remove(newAdd);
                db.Sites.Remove(existingSite);
                db.SiteTypes.Remove(existingSiteType);
                db.Organizations.Remove(existingOrg);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void SaveNewSiteInfo()
        {

            
            using (var db = new DBIntegrationContext())
            {
                //Arrange

                var existingSiteType = new SiteType();

                existingSiteType.SiteTypeId = 7;
                existingSiteType.SiteTypeName = "Restaurant";
                existingSiteType.CreatedDateTime = new DateTime();
                existingSiteType.CreatedBy = "Administrator";
                existingSiteType.ModifiedDateTime = new DateTime();
                existingSiteType.ModifiedBy = "Administrator";
                db.SiteTypes.Add(existingSiteType);

                var existingOrg = new Organization();

                existingOrg.OrganizationCode = "RWF";
                existingOrg.OrganizationName = "RealWorld Diners";
                existingOrg.PhoneNumber = "208-555-1234";
                existingOrg.FaxNumber = "208-555-3421";
                existingOrg.ParentOrganizationCode = "4321";
                existingOrg.Theme = "Standard";
                existingOrg.Skin = "Red";
                existingOrg.Active = true;
                existingOrg.DELETED = false;
                existingOrg.CreatedDateTime = new DateTime();
                existingOrg.CreatedBy = "Administrator";
                existingOrg.ModifiedDateTime = new DateTime();
                existingOrg.ModifiedBy = "Administrator";
                db.Organizations.Add(existingOrg);

                var newSite = new Site();

                newSite.OrganizationId = existingOrg.OrganizationId;
                newSite.SiteTypeId = existingSiteType.SiteTypeId;
                newSite.SiteName = "Little Island";
                newSite.SiteCode = "RWF001";
                newSite.TimeZoneId = 8;
                newSite.CreatedDateTime = new DateTime();
                newSite.CreatedBy = "Adminstrator";
                newSite.ModifiedDateTime = new DateTime();
                newSite.ModifiedBy = "Administrator";
                db.Sites.Add(newSite);

                //Act
                db.SaveChanges();

                //Assert -- See if the record retrieved matches the one just entered
                Site saveSite = (from d in db.Sites where d.SiteId == newSite.SiteId select d).Single();

                Assert.AreEqual(saveSite.OrganizationId, newSite.OrganizationId);
                Assert.AreEqual(saveSite.SiteTypeId, newSite.SiteTypeId);
                Assert.AreEqual(saveSite.SiteName, newSite.SiteName);
                Assert.AreEqual(saveSite.SiteCode, newSite.SiteCode);
                Assert.AreEqual(saveSite.TimeZoneId, newSite.TimeZoneId);
                Assert.AreEqual(saveSite.CreatedDateTime, newSite.CreatedDateTime);
                Assert.AreEqual(saveSite.CreatedBy, newSite.CreatedBy);
                Assert.AreEqual(saveSite.ModifiedDateTime, newSite.ModifiedDateTime);
                Assert.AreEqual(saveSite.ModifiedBy, newSite.ModifiedBy);

                //cleanup
                db.Sites.Remove(newSite);
                db.SiteTypes.Remove(existingSiteType);
                db.Organizations.Remove(existingOrg);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void SaveNewPerson()
        {

            
            using (var db = new DBIntegrationContext())
            {
                //Arrange

                var newOrg = new Organization();

                newOrg.OrganizationCode = "RWF";
                newOrg.OrganizationName = "RealWorld Diners";
                newOrg.PhoneNumber = "208-555-1234";
                newOrg.FaxNumber = "208-555-3421";
                newOrg.ParentOrganizationCode = "4321";
                newOrg.Theme = "Standard";
                newOrg.Skin = "Red";
                newOrg.Active = true;
                newOrg.DELETED = false;
                newOrg.CreatedDateTime = new DateTime();
                newOrg.CreatedBy = "Administrator";
                newOrg.ModifiedDateTime = new DateTime();
                newOrg.ModifiedBy = "Administrator";
                db.Organizations.Add(newOrg);

                var newUserType = new UserType();

                newUserType.UserTypeName = "User Name";
                newUserType.CreatedDateTime = new DateTime();
                newUserType.CreatedBy = "Administrator";
                newUserType.ModifiedDateTime = new DateTime();
                newUserType.ModifiedBy = "Administrator";
                db.UserTypes.Add(newUserType);

                var newUser = new Person();

                newUser.OrganizationId = newOrg.OrganizationId;
                newUser.UserTypeId = newUserType.UserTypeId;
                newUser.FirstName = "Fred";
                newUser.LastName = "Jones";
                newUser.PhoneNumber = "208-555=-234";
                newUser.EmailAddress = "fjones@itradenetwork.com";
                newUser.UnitName = "RealIdaho";
                newUser.UnitNumber = "4301";
                newUser.Department = "Fast Food";
                newUser.CreatedDateTime = new DateTime();
                newUser.CreatedBy = "Administrator";
                newUser.ModifiedDateTime = new DateTime();
                newUser.ModifiedBy = "Administrator";
                db.People.Add(newUser);


                //Act
                db.SaveChanges();

                //Assert -- See if the record retrieved matches the one just entered
                var saveUser = (from d in db.People where d.UserId == newUser.UserId select d).Single();

                Assert.AreEqual(saveUser.OrganizationId, newUser.OrganizationId);
                Assert.AreEqual(saveUser.UserTypeId, newUser.UserTypeId);
                Assert.AreEqual(saveUser.FirstName, newUser.FirstName);
                Assert.AreEqual(saveUser.LastName, newUser.LastName);
                Assert.AreEqual(saveUser.PhoneNumber, newUser.PhoneNumber);
                Assert.AreEqual(saveUser.EmailAddress, newUser.EmailAddress);
                Assert.AreEqual(saveUser.UnitName, newUser.UnitName);
                Assert.AreEqual(saveUser.UnitNumber, newUser.UnitNumber);
                Assert.AreEqual(saveUser.Department, newUser.Department);
                Assert.AreEqual(saveUser.CreatedDateTime, newUser.CreatedDateTime);
                Assert.AreEqual(saveUser.ModifiedDateTime, newUser.ModifiedDateTime);
                Assert.AreEqual(saveUser.ModifiedBy, newUser.ModifiedBy);

                //cleanup
                db.People.Remove(newUser);
                db.Organizations.Remove(newOrg);
                db.UserTypes.Remove(newUserType);
                db.SaveChanges();            
            }

        }

        [TestMethod]
        public void SaveNewSiteType()
        {
            
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var newSiteType = new SiteType();

                newSiteType.SiteTypeName = "Restaurant";
                newSiteType.CreatedDateTime = new DateTime();
                newSiteType.CreatedBy = "Administrator";
                newSiteType.ModifiedDateTime = new DateTime();
                newSiteType.ModifiedBy = "Administrator";
                db.SiteTypes.Add(newSiteType);

                //Act
                db.SaveChanges();

                //Assert -- See if the record retrieved matches the one just entered
                var saveSite = (from d in db.SiteTypes where d.SiteTypeId == newSiteType.SiteTypeId select d).Single();

                Assert.AreEqual(saveSite.SiteTypeName, newSiteType.SiteTypeName);
                Assert.AreEqual(saveSite.CreatedDateTime, newSiteType.CreatedDateTime);
                Assert.AreEqual(saveSite.CreatedBy, newSiteType.CreatedBy);
                Assert.AreEqual(saveSite.ModifiedDateTime, newSiteType.ModifiedDateTime);
                Assert.AreEqual(saveSite.ModifiedBy, newSiteType.ModifiedBy);

                //Cleanup
                db.SiteTypes.Remove(newSiteType);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void SaveNewUserType()
        { 
            
            using (var db = new DBIntegrationContext())
            {
                //Arrange

                var existingUserType = new UserType();

                existingUserType.UserTypeId = 12;
                existingUserType.UserTypeName = "User Name";
                existingUserType.CreatedDateTime = new DateTime();
                existingUserType.CreatedBy = "Administrator";
                existingUserType.ModifiedDateTime = new DateTime();
                existingUserType.ModifiedBy = "Administrator";
                db.UserTypes.Add(existingUserType);

                var existingOrg = new Organization();

                existingOrg.OrganizationCode = "RWF";
                existingOrg.OrganizationName = "RealWorld Diners";
                existingOrg.PhoneNumber = "208-555-1234";
                existingOrg.FaxNumber = "208-555-3421";
                existingOrg.ParentOrganizationCode = "4321";
                existingOrg.Theme = "Standard";
                existingOrg.Skin = "Red";
                existingOrg.Active = true;
                existingOrg.DELETED = false;
                existingOrg.CreatedDateTime = new DateTime();
                existingOrg.CreatedBy = "Administrator";
                existingOrg.ModifiedDateTime = new DateTime();
                existingOrg.ModifiedBy = "Administrator";
                db.Organizations.Add(existingOrg);

                var existingUser = new Person();

                existingUser.OrganizationId = existingOrg.OrganizationId;
                existingUser.UserTypeId = existingUserType.UserTypeId;
                existingUser.FirstName = "Fred";
                existingUser.LastName = "Jones";
                existingUser.PhoneNumber = "208-555-1234";
                existingUser.EmailAddress = "fjones@itradenetwork.com";
                existingUser.UnitName = "RealIdaho";
                existingUser.UnitNumber = "4301";
                existingUser.Department = "Fast Food";
                existingUser.CreatedDateTime = new DateTime();
                existingUser.CreatedBy = "Administrator";
                existingUser.ModifiedDateTime = new DateTime();
                existingUser.ModifiedBy = "Administrator";
                db.People.Add(existingUser);

                var newUserType = new UserType();

                newUserType.UserTypeId = 10;
                newUserType.UserTypeName = "User Name";
                newUserType.CreatedDateTime = new DateTime();
                newUserType.CreatedBy = "Administrator";
                newUserType.ModifiedDateTime = new DateTime();
                newUserType.ModifiedBy = "Administrator";
                db.UserTypes.Add(newUserType);

                //Act
                db.SaveChanges();

                //Assert -- See if the record retrieved matches the one just entered
                var saveUserType = (from d in db.UserTypes where d.UserTypeId == newUserType.UserTypeId select d).Single();

                Assert.AreEqual(saveUserType.UserTypeName, newUserType.UserTypeName);
                Assert.AreEqual(saveUserType.CreatedDateTime, newUserType.CreatedDateTime);
                Assert.AreEqual(saveUserType.CreatedBy, newUserType.CreatedBy);
                Assert.AreEqual(saveUserType.ModifiedDateTime, newUserType.ModifiedDateTime);
                Assert.AreEqual(saveUserType.ModifiedBy, newUserType.ModifiedBy);

                //Cleanup
                db.UserTypes.Remove(newUserType);
                db.UserTypes.Remove(existingUserType);
                db.Organizations.Remove(existingOrg);
                db.People.Remove(existingUser);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void SaveNewRules()
        {
            
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var newRule = new NewCustomerIntegration.Domain.Models.Rule(); // have to use full qualification as System has Rule

                newRule.ValueTypeId = 16;
                newRule.RuleName = "Substitution";
                newRule.RuleDescription = "Substitute out of stock item with closest like item";
                newRule.CreatedDateTime = new DateTime();
                newRule.CreatedBy = "Administrator";
                newRule.ModifiedDateTime = new DateTime();
                newRule.ModifiedBy = "Administrator";
                db.Rules.Add(newRule);

                //Act 
                db.SaveChanges();

                //Assert -- See if the record retrieved matches the one just entered
                var saveRules = (from d in db.Rules where d.RuleId == newRule.RuleId select d).Single();

                Assert.AreEqual(saveRules.ValueTypeId, newRule.ValueTypeId);
                Assert.AreEqual(saveRules.RuleName, newRule.RuleName );
                Assert.AreEqual(saveRules.RuleDescription, newRule.RuleDescription);
                Assert.AreEqual(saveRules.CreatedDateTime, newRule.CreatedDateTime);
                Assert.AreEqual(saveRules.CreatedBy, newRule.CreatedBy);
                Assert.AreEqual(saveRules.ModifiedDateTime, newRule.ModifiedDateTime);
                Assert.AreEqual(saveRules.ModifiedBy, newRule.ModifiedBy);

                //Cleanup
                db.Rules.Remove(newRule);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void CheckNewPerson()
        {
            
            using (var db = new DBIntegrationContext())
            { 
                //Arrange
                var existingOrg = new Organization();

                existingOrg.OrganizationCode = "RWF";
                existingOrg.OrganizationName = "RealWorld Diners";
                existingOrg.PhoneNumber = "208-555-1234";
                existingOrg.FaxNumber = "208-555-3421";
                existingOrg.ParentOrganizationCode = "4321";
                existingOrg.Theme = "Standard";
                existingOrg.Skin = "Red";
                existingOrg.Active = true;
                existingOrg.DELETED = false;
                existingOrg.CreatedDateTime = new DateTime();
                existingOrg.CreatedBy = "Administrator";
                existingOrg.ModifiedDateTime = new DateTime();
                existingOrg.ModifiedBy = "Administrator";
                db.Organizations.Add(existingOrg);

                var existingUserType = new UserType();

                existingUserType.UserTypeId = 12;
                existingUserType.UserTypeName = "User Name";
                existingUserType.CreatedDateTime = new DateTime();
                existingUserType.CreatedBy = "Administrator";
                existingUserType.ModifiedDateTime = new DateTime();
                existingUserType.ModifiedBy = "Administrator";
                db.UserTypes.Add(existingUserType);

                db.SaveChanges(); // must write as db is empty or it doesn't commit

                var newUser = new Person();
                newUser.OrganizationId = existingOrg.OrganizationId;
                newUser.UserTypeId = 12;
                newUser.FirstName = "Fred";
                newUser.LastName = "Jones";
                newUser.PhoneNumber = existingOrg.PhoneNumber;
                newUser.EmailAddress = "fjones@itradenetwork.com";
                newUser.UnitName = "RealIdaho";
                newUser.UnitNumber = "4301";
                newUser.Department = "Fast Food";
                newUser.CreatedDateTime = new DateTime();
                newUser.CreatedBy = "Administrator";
                newUser.ModifiedDateTime = new DateTime();
                newUser.ModifiedBy = "Administrator";
                db.People.Add(newUser);

                //Act
                db.SaveChanges();

                //Assert -- validate new user information contains user type, company and phone
                //          make sure appropriate fields are not null
                //          make sure Organization is active

                Assert.AreEqual(existingOrg.DELETED, false);
                Assert.AreEqual(newUser.OrganizationId, existingOrg.OrganizationId);
                Assert.AreEqual(newUser.PhoneNumber, existingOrg.PhoneNumber);
                Assert.AreEqual(newUser.UserTypeId, existingUserType.UserTypeId);
                Assert.AreNotEqual(newUser.UserTypeId, null);
                Assert.AreNotEqual(newUser.FirstName, null);
                Assert.AreNotEqual(newUser.LastName, null);
                Assert.AreNotEqual(newUser.CreatedDateTime, null);
                Assert.AreNotEqual(newUser.CreatedBy, null);


                //Cleanup
                db.People.Remove(newUser);
                db.Organizations.Remove(existingOrg);
                db.UserTypes.Remove(existingUserType);
                db.SaveChanges();

            }

        }

        [TestMethod]
        public void CheckNewOrganization()
        {
            
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var existingOrg = new Organization();

                existingOrg.OrganizationId = 15;
                existingOrg.OrganizationCode = "RWF";
                existingOrg.OrganizationName = "RealWorld Diners";
                existingOrg.PhoneNumber = "208-555-1234";
                existingOrg.FaxNumber = "208-555-3421";
                existingOrg.ParentOrganizationCode = "4321";
                existingOrg.Theme = "Custom";
                existingOrg.Skin = "Green";
                existingOrg.Active = true;
                existingOrg.DELETED = false;
                existingOrg.CreatedDateTime = new DateTime();
                existingOrg.CreatedBy = "Administrator";
                existingOrg.ModifiedDateTime = new DateTime();
                existingOrg.ModifiedBy = "Administrator";
                db.Organizations.Add(existingOrg);

                var existingSite = new Site();

                existingSite.SiteId = 1;
                existingSite.OrganizationId = existingOrg.OrganizationId;
                existingSite.SiteTypeId = 7;
                existingSite.SiteName = "Little Island";
                existingSite.SiteCode = "RWF001";
                existingSite.TimeZoneId = 8;
                existingSite.CreatedDateTime = new DateTime();
                existingSite.CreatedBy = "Adminstrator";
                existingSite.ModifiedDateTime = new DateTime();
                existingSite.ModifiedBy = "Administrator";
                db.Sites.Add(existingSite);

                var existingSiteType = new SiteType();

                existingSiteType.SiteTypeId = 7;
                existingSiteType.SiteTypeName = "Restaurant";
                existingSiteType.CreatedDateTime = new DateTime();
                existingSiteType.CreatedBy = "Administrator";
                existingSiteType.ModifiedDateTime = new DateTime();
                existingSiteType.ModifiedBy = "Administrator";
                db.SiteTypes.Add(existingSiteType);

                var existingAdd = new Address();

                existingAdd.AddressId = 0;
                existingAdd.SiteId = existingSite.SiteId;
                existingAdd.AddressTypeId = 5;
                existingAdd.AddressLine1 = "RealWorld Food";
                existingAdd.AddressLine2 = "101 Maple Str";
                existingAdd.AddressLine3 = "Suite 150";
                existingAdd.City = "Meridian";
                existingAdd.StateProvinceRegionId = 43;
                existingAdd.PostalCode = "83642";
                existingAdd.CountryRegionId = 01;
                existingAdd.CreatedDateTime = new DateTime();
                existingAdd.CreatedBy = "Administrator";
                existingAdd.ModifiedDateTime = new DateTime();
                existingAdd.ModifiedBy = "Administrator";
                db.Addresses.Add(existingAdd);

                var newOrg = new Organization();

                newOrg.OrganizationId = 25;
                newOrg.OrganizationCode = "BFW";
                newOrg.OrganizationName = "Big Food Warehouse";
                newOrg.PhoneNumber = "208-555-9658";
                newOrg.FaxNumber = "208-555-9657";
                newOrg.ParentOrganizationCode = "3658";
                newOrg.Theme = "Standard";
                newOrg.Skin = "Red";
                newOrg.Active = true;
                newOrg.DELETED = false;
                newOrg.CreatedDateTime = new DateTime();
                newOrg.CreatedBy = "Administrator";
                newOrg.ModifiedDateTime = new DateTime();
                newOrg.ModifiedBy = "Administrator";
                db.Organizations.Add(newOrg);

                var newSite = new Site();

                var newSiteType = new SiteType();

                newSite.SiteTypeId = 1;
                newSiteType.SiteTypeName = "Warehouse";
                newSiteType.CreatedDateTime = new DateTime();
                newSiteType.CreatedBy = "Administrator";
                newSiteType.ModifiedDateTime = new DateTime();
                newSiteType.ModifiedBy = "Administrator";
                db.SiteTypes.Add(newSiteType);

                newSite.SiteId = 2;
                newSite.OrganizationId = newOrg.OrganizationId;
                newSite.SiteTypeId = newSiteType.SiteTypeId;
                newSite.SiteName = "Big Island";
                newSite.SiteCode = "BFW001";
                newSite.TimeZoneId = 7;
                newSite.CreatedDateTime = new DateTime();
                newSite.CreatedBy = "Adminstrator";
                newSite.ModifiedDateTime = new DateTime();
                newSite.ModifiedBy = "Administrator";
                db.Sites.Add(newSite);
                var newAdd = new Address();

                newAdd.AddressId = 1;
                newAdd.SiteId = newSite.SiteId;
                newAdd.AddressTypeId = 4;
                newAdd.AddressLine1 = "BFW Food";
                newAdd.AddressLine2 = "100 Transit Street";
                newAdd.AddressLine3 = "Suite 25";
                newAdd.City = "Indianapolis";
                newAdd.StateProvinceRegionId = 19;
                newAdd.PostalCode = "46201";
                newAdd.CountryRegionId = 01;
                newAdd.CreatedDateTime = new DateTime();
                newAdd.CreatedBy = "Administrator";
                newAdd.ModifiedDateTime = new DateTime();
                newAdd.ModifiedBy = "Administrator";
                db.Addresses.Add(newAdd);


                //Act
                db.SaveChanges();

                //Assert  - Make sure new org name, address and ID do not match existing org 

                if (existingOrg.OrganizationId != newOrg.OrganizationId)
                { 
                    Assert.AreNotEqual(newOrg.OrganizationName, existingOrg.OrganizationName);
                    Assert.AreNotEqual(newAdd.AddressId, existingAdd.AddressId);
                    Assert.AreNotEqual(newOrg.PhoneNumber, existingOrg.PhoneNumber);
                    Assert.AreNotEqual(newOrg.FaxNumber, existingOrg.FaxNumber);
                    Assert.AreNotEqual(newOrg.ParentOrganizationCode, existingOrg.ParentOrganizationCode);
                    Assert.AreNotEqual(newAdd.AddressLine1, existingAdd.AddressLine1);
                }

                //Cleanup
                db.Organizations.Remove(newOrg);
                db.Organizations.Remove(existingOrg);
                db.Addresses.Remove(newAdd);
                db.Addresses.Remove(existingAdd);
                db.SiteTypes.Remove(newSiteType);
                db.SiteTypes.Remove(existingSiteType);
                db.Sites.Remove(existingSite);
                db.Sites.Remove(newSite);
                db.SaveChanges();

            }
        }

        [TestMethod]
        public void CheckNewSite()
        {
            using (var db = new DBIntegrationContext())
            {
                //Arrange

                var existingSiteType = new SiteType();

                existingSiteType.SiteTypeId = 7;
                existingSiteType.SiteTypeName = "Restaurant";
                existingSiteType.CreatedDateTime = new DateTime();
                existingSiteType.CreatedBy = "Administrator";
                existingSiteType.ModifiedDateTime = new DateTime();
                existingSiteType.ModifiedBy = "Administrator";
                db.SiteTypes.Add(existingSiteType);

                var existingOrg = new Organization();

                existingOrg.OrganizationId = 15;
                existingOrg.OrganizationCode = "RWF";
                existingOrg.OrganizationName = "RealWorld Diners";
                existingOrg.PhoneNumber = "208-555-1234";
                existingOrg.FaxNumber = "208-555-3421";
                existingOrg.ParentOrganizationCode = "4321";
                existingOrg.Theme = "Custom";
                existingOrg.Skin = "Green";
                existingOrg.Active = true;
                existingOrg.DELETED = false;
                existingOrg.CreatedDateTime = new DateTime();
                existingOrg.CreatedBy = "Administrator";
                existingOrg.ModifiedDateTime = new DateTime();
                existingOrg.ModifiedBy = "Administrator";
                db.Organizations.Add(existingOrg);

                var existingSite = new Site();

                existingSite.SiteId = 5;
                existingSite.OrganizationId = existingOrg.OrganizationId;
                existingSite.SiteTypeId = existingSiteType.SiteTypeId;
                existingSite.SiteName = "Little Island";
                existingSite.SiteCode = "RWF001";
                existingSite.TimeZoneId = 8;
                existingSite.CreatedDateTime = new DateTime();
                existingSite.CreatedBy = "Adminstrator";
                existingSite.ModifiedDateTime = new DateTime();
                existingSite.ModifiedBy = "Administrator";
                db.Sites.Add(existingSite);


                var newSiteType = new SiteType();

                newSiteType.SiteTypeId = 1;
                newSiteType.SiteTypeName = "Warehouse";
                newSiteType.CreatedDateTime = new DateTime();
                newSiteType.CreatedBy = "Administrator";
                newSiteType.ModifiedDateTime = new DateTime();
                newSiteType.ModifiedBy = "Administrator";
                db.SiteTypes.Add(newSiteType);

                var newSite = new Site();
                newSite.SiteId = 6;
                newSite.OrganizationId = existingOrg.OrganizationId;
                newSite.SiteTypeId = newSiteType.SiteTypeId;
                newSite.SiteName = "Big Island";
                newSite.SiteCode = "BFW001";
                newSite.TimeZoneId = 7;
                newSite.CreatedDateTime = new DateTime();
                newSite.CreatedBy = "Adminstrator";
                newSite.ModifiedDateTime = new DateTime();
                newSite.ModifiedBy = "Administrator";
                db.Sites.Add(newSite);


                //Act
                db.SaveChanges();

                //Assert -- verify new site doesn't match existing site

                if (newSite.OrganizationId != existingSite.OrganizationId)
                {
                    Assert.AreNotEqual(newSite.SiteName, existingSite.SiteName);
                    Assert.AreNotEqual(newSite.SiteCode, existingSite.SiteCode);
                    Assert.AreNotEqual(newSite.SiteId, existingSite.SiteId);
                }
                else
                {
                    if (newSite.SiteTypeId == existingSite.SiteTypeId)
                    {
                        Assert.AreNotEqual(newSite.SiteName, existingSite.SiteName);
                        Assert.AreNotEqual(newSite.SiteId, existingSite.SiteId);
                        Assert.AreNotEqual(newSite.SiteCode, existingSite.SiteCode);
                    }
                    else
                    {
                        Assert.AreNotEqual(newSite.SiteId, existingSite.SiteId);
                        Assert.AreNotEqual(newSite.SiteCode, existingSite.SiteCode);
                        Assert.AreNotEqual(newSite.SiteName, existingSite.SiteName);
                    }
                }

                //Cleanup
                db.Sites.Remove(existingSite);
                db.Sites.Remove(newSite);
                db.SiteTypes.Remove(existingSiteType);
                db.SiteTypes.Remove(newSiteType);
                db.SaveChanges();

            }
        }

        [TestMethod]
        public void CheckNewRules()
        {
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var existingRule = new NewCustomerIntegration.Domain.Models.Rule();  //have to use full qualification as system has rules
                
                existingRule.RuleId = 4;
                existingRule.ValueTypeId = 16;
                existingRule.RuleName = "Substitution";
                existingRule.RuleDescription = "Substitute out of stock item with closest like item";
                existingRule.CreatedDateTime = new DateTime();
                existingRule.CreatedBy = "Administrator";
                existingRule.ModifiedDateTime = new DateTime();
                existingRule.ModifiedBy = "Administrator";
                db.Rules.Add(existingRule);

                var newRule = new NewCustomerIntegration.Domain.Models.Rule();

                newRule.RuleId = 7;
                newRule.ValueTypeId = 17;
                newRule.RuleName = "Sunday Delivery";
                newRule.RuleDescription = "Deliver on Sunday is O.K.";
                newRule.CreatedDateTime = new DateTime();
                newRule.CreatedBy = "Administrator";
                newRule.ModifiedDateTime = new DateTime();
                newRule.ModifiedBy = "Administrator";
                db.Rules.Add(newRule);

                //Act
                db.SaveChanges();

                //Assert -- make sure new rule doesn't conflict with existing rule
                Assert.AreNotEqual(existingRule.ValueTypeId, newRule.ValueTypeId);
                Assert.AreNotEqual(existingRule.RuleName, newRule.RuleName);

                //Cleanup
                db.Rules.Remove(existingRule);
                db.Rules.Remove(newRule);
                db.SaveChanges();
            }

        }

    // Clean by Columns
        [TestMethod]
        public void DeleteOrganizationContent() 
        {
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                    var query = from d in db.Organizations
                                orderby d.OrganizationId
                                select d;
                    foreach (var item in query)
                    {
                        db.Organizations.Remove(item);
                    }
                
                //Act
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void DeletePersonContent()
        {
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var query = from d in db.People
                            orderby d.UserId
                            select d;
                foreach (var item in query)
                {
                    db.People.Remove(item);
                }

                //Act
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void DeleteAddressContent()
        {
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var query = from d in db.Addresses
                            orderby d.AddressId
                            select d;
                foreach (var item in query)
                {
                    db.Addresses.Remove(item);
                }

                //Act
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void DeleteSiteContent()
        {
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var query = from d in db.Sites
                            orderby d.SiteId
                            select d;

                foreach (var item in query)
                {
                    db.Sites.Remove(item);
                }

                //Act
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void DeleteUserTypeContent()
        {
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var query = from d in db.UserTypes
                            orderby d.UserTypeId
                            select d;

                foreach (var item in query)
                {
                    db.UserTypes.Remove(item);
                }

                //Act
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void DeleteSiteTypeContent()
        {
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var query = from d in db.SiteTypes
                            orderby d.SiteTypeId
                            select d;
                foreach (var item in query)
                {
                    db.SiteTypes.Remove(item);
                }

                //Act
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void DeleteRuleContent()
        {
            using (var db = new DBIntegrationContext())
            {
                //Arrange
                var query = from d in db.Rules
                            orderby d.RuleId
                            select d;
                foreach (var item in query)
                {
                    db.Rules.Remove(item);
                }

                //Act
                db.SaveChanges();
            }
        }
    }
}
