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
    public class UserTypeSvcMVCImpl : INewCustomerUserTypeService 
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public void StoreUserTypes(UserType userTypes)
        {
            FileStream fileStream = new FileStream
                ("UserTypes.bin", FileMode.Create, FileAccess.Write);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, userTypes);
            fileStream.Close();
        }

        public ArrayList RetrieveUserTypes()
        {
            FileStream fileStream = new FileStream
                ("UserTypes.bin", FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
            ArrayList userTypes = formatter.Deserialize(fileStream) as ArrayList;
            fileStream.Close();
            return userTypes;
        }

        public IList<UserType> GetUserTypes()
        {
            var usertypes = customerDB.UserTypes;

            return usertypes.ToList();
        }

        public UserType UserTypeDetails(long id)
        {
            return this.customerDB.UserTypes.Find(id);
        }

        public void UserTypeCreate(UserType usertype)
        {
            this.customerDB.UserTypes.Add(usertype);
            this.customerDB.SaveChanges();
        }

        public UserType UserTypeEdit(long id)
        {
            return this.customerDB.UserTypes.Find(id);
        }

        public void UserTypeEdit(UserType usertype)
        {
            this.customerDB.Entry(usertype).State = EntityState.Modified;
            this.customerDB.SaveChanges();
        }

        public UserType UserTypeDelete(long id)
        {
            return this.customerDB.UserTypes.Find(id);
        }

        public void UserTypeDeleteConfirmed(long id)
        {
            var usertype = this.customerDB.UserTypes.Find(id);
            this.customerDB.UserTypes.Remove(usertype);
            this.customerDB.SaveChanges();
        }

        public void UserTypeDispose(bool disposing)
        {
            this.customerDB.Dispose();
        }
    }
}