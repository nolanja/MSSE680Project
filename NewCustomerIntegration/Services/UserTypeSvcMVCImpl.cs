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
    public class UserTypeSvcMVCImpl : INewCustomerUserTypeService 
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public void StoreUserTypes(UserType userTypes)
        {
            try
            {
                FileStream fileStream = new FileStream
            ("UserTypes.bin", FileMode.Create, FileAccess.Write);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, userTypes);
                fileStream.Close();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create UserTypes.bin file " + e.GetType().Name);
            }
        }

        public ArrayList RetrieveUserTypes()
        {
            try
            {
                FileStream fileStream = new FileStream
            ("UserTypes.bin", FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                ArrayList userTypes = formatter.Deserialize(fileStream) as ArrayList;
                fileStream.Close();
                return userTypes;
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to open UserTypes.bin file " + e.GetType().Name);
            }
        }

        public IList<UserType> GetUserTypes()
        {
            try
            {
                var usertypes = customerDB.UserTypes;
                return usertypes.ToList();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to list User Types " + e.GetType().Name);
            }
        }

        public UserType UserTypeDetails(long id)
        {
            try
            {
                return this.customerDB.UserTypes.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find User Type with ID " + id.ToString() + e.GetType().Name);
            }
        }

        public void UserTypeCreate(UserType usertype)
        {
            try
            {
                this.customerDB.UserTypes.Add(usertype);
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to create User Type "  + e.GetType().Name);
            }
        }

        public UserType UserTypeEdit(long id)
        {
            try
            {
                return this.customerDB.UserTypes.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find User Type ID " + id.ToString() + e.GetType().Name);
            }
        }

        public void UserTypeEdit(UserType usertype)
        {
            try
            {
                this.customerDB.Entry(usertype).State = EntityState.Modified;
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to edit User Type " + e.GetType().Name);
            }
        }

        public UserType UserTypeDelete(long id)
        {
            try
            {
                return this.customerDB.UserTypes.Find(id);
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to find User Type with ID " + id.ToString() + e.GetType().Name);
            }
        }

        public void UserTypeDeleteConfirmed(long id)
        {
            try
            {
                var usertype = this.customerDB.UserTypes.Find(id);
                this.customerDB.UserTypes.Remove(usertype);
                this.customerDB.SaveChanges();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to remove User Type with ID " + id.ToString() + e.GetType().Name);
            }
        }

        public void UserTypeDispose(bool disposing)
        {
            try
            {
                this.customerDB.Dispose();
            }
            catch (IOException e)
            {
                
                throw new IOException("Unable to dispose of User Type " + e.GetType().Name);
            }
        }
    }
}