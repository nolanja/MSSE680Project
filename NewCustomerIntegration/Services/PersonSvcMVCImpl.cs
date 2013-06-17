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

namespace NewCustomerIntegration.Services
{
        public class PersonSvcMVCImpl : INewCustomerPersonService 
        {
            DBIntegrationContext customerDB = new DBIntegrationContext();

            public void StorePeople(Person people)
            {
                FileStream fileStream = new FileStream
                    ("People.bin", FileMode.Create, FileAccess.Write);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, people);
                fileStream.Close();
            }

            public ArrayList RetrievePeople()
            {
                FileStream fileStream = new FileStream
                    ("People.bin", FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                ArrayList people = formatter.Deserialize(fileStream) as ArrayList;
                fileStream.Close();
                return people;
            } 

            public IList<Person> GetPeople()
            {
                var people = customerDB.People.Include(p => p.Organization).Include(p => p.UserType);

                return people.ToList();
            }

            public Person PersonDetails(long id)
            {
                return this.customerDB.People.Find(id);
            }

            public dynamic PersonCreateOrganizationIDKey()
            {
                var organizationID = new SelectList(customerDB.Organizations, "OrganizationId", "OrganizationCode");
                return organizationID; 
            }

            public dynamic PersonCreateUserTypeIDKey()
            {
                var userTypeID = new SelectList(customerDB.UserTypes, "UserTypeId", "UserTypeName");
                return userTypeID;
            }

            public dynamic PersonWriteOrganizationIDKey(Person person)
            {
                var organizationID = new SelectList(customerDB.Organizations, "OrganizationId", "OrganizationCode", person.OrganizationId);
                return organizationID;
            }

            public dynamic PersonWriteUserTypeIDKey(Person person)
            {
                var userTypeID = new SelectList(customerDB.UserTypes, "UserTypeId", "UserTypeName", person.UserTypeId);
                return userTypeID;                
            }
            public void PersonCreate(Person person)
            {
                this.customerDB.People.Add(person);
                this.customerDB.SaveChanges();
            }

            public Person PersonEdit(long id)
            {
                return this.customerDB.People.Find(id);
            }

            public void PersonEdit(Person person)
            {
                this.customerDB.Entry(person).State = EntityState.Modified;
                this.customerDB.SaveChanges();
            }

            public Person PersonDelete(long id)
            {
                return this.customerDB.People.Find(id);
            }

            public void PersonDeleteConfirmed(long id)
            {
                var people = this.customerDB.People.Find(id);
                this.customerDB.People.Remove(people);
                this.customerDB.SaveChanges();
            }

            public void PeopleDispose(bool disposing)
            {
                this.customerDB.Dispose();
            }
        }
    
}
