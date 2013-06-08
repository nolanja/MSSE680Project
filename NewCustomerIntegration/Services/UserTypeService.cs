using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewCustomerIntegration.Services;
using NewCustomerIntegration.Domain.Models;

namespace NewCustomerIntegration.Services
{
    public class UserTypeService : INewCustomerUserTypeService
    {
        DBIntegrationContext customerDB = new DBIntegrationContext();

        public IList<long> GetUserTypes()
        {
            var usertypes = from usertype in customerDB.UserTypes
                            select usertype.UserTypeId;

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