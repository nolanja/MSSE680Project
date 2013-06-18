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
        public class PersonSvcMVCImpl : INewCustomerPersonService 
        {
            DBIntegrationContext customerDB = new DBIntegrationContext();

            public void StorePeople(Person people)
            {
                try
                {
                    FileStream fileStream = new FileStream
                ("People.bin", FileMode.Create, FileAccess.Write);
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, people);
                    fileStream.Close();
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to open People.bin " + e.GetType().Name);
                }
            }

            public ArrayList RetrievePeople()
            {
                try
                {
                    FileStream fileStream = new FileStream
                ("People.bin", FileMode.Open, FileAccess.Read);
                    IFormatter formatter = new BinaryFormatter();
                    ArrayList people = formatter.Deserialize(fileStream) as ArrayList;
                    fileStream.Close();
                    return people;
                }
                catch (FileNotFoundException e)
                {

                    throw new FileNotFoundException("Unable to find People.bin " + e.GetType().Name);
                }
            } 

            public IList<Person> GetPeople()
            {
                try
                {
                    var people = customerDB.People.Include(p => p.Organization).Include(p => p.UserType);
                    return people.ToList();
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to create list of people " + e.GetType().Name);
                }
            }

            public Person PersonDetails(long id)
            {
                try
                {
                    return this.customerDB.People.Find(id);
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to find " + id.ToString() + e.GetType().Name);
                }
            }

            public dynamic PersonCreateOrganizationIDKey()
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

            public dynamic PersonCreateUserTypeIDKey()
            {
                try
                {
                    var userTypeID = new SelectList(customerDB.UserTypes, "UserTypeId", "UserTypeName");
                    return userTypeID;
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to create User Type ID key " + e.GetType().Name);
                }
            }

            public dynamic PersonWriteOrganizationIDKey(Person person)
            {
                try
                {
                    var organizationID = new SelectList(customerDB.Organizations, "OrganizationId", "OrganizationCode", person.OrganizationId);
                    return organizationID;
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to write Organzation ID key " + e.GetType().Name);
                }
            }

            public dynamic PersonWriteUserTypeIDKey(Person person)
            {
                try
                {
                    var userTypeID = new SelectList(customerDB.UserTypes, "UserTypeId", "UserTypeName", person.UserTypeId);
                    return userTypeID;
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to write User Type ID key " + e.GetType().Name);
                }               
            }
            public void PersonCreate(Person person)
            {
                try
                {
                    this.customerDB.People.Add(person);
                    this.customerDB.SaveChanges();
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to add new person " + e.GetType().Name);
                }
            }

            public Person PersonEdit(long id)
            {
                try
                {
                    return this.customerDB.People.Find(id);
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to find person " + id.ToString() + e.GetType().Name);
                }
            }

            public void PersonEdit(Person person)
            {
                try
                {
                    this.customerDB.Entry(person).State = EntityState.Modified;
                    this.customerDB.SaveChanges();
                }
                catch (IOException e)
                {

                    throw new IOException("Cannot edit person " + e.GetType().Name);
                }
            }

            public Person PersonDelete(long id)
            {
                try
                {
                    return this.customerDB.People.Find(id);
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to find " + id.ToString() + e.GetType().Name);
                }
            }

            public void PersonDeleteConfirmed(long id)
            {
                try
                {
                    var people = this.customerDB.People.Find(id);
                    this.customerDB.People.Remove(people);
                    this.customerDB.SaveChanges();
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to remove person " + e.GetType().Name);
                }

            }                    

            public void PeopleDispose(bool disposing)
            {
                try
                {
                    this.customerDB.Dispose();
                }
                catch (IOException e)
                {
                    
                    throw new IOException("Unable to dispose of file " + e.GetType().Name);
                }
            }
        }
    
}
