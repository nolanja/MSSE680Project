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

    public class UserTypeManagement : Manager
    {
        public DBIntegrationContext context;

        public UserTypeManagement()
        {
            this.context = new DBIntegrationContext();
        }

        public UserTypeManagement(DBIntegrationContext dbContext)
        {
            this.context = dbContext;
        }
        public void ListUserTypes()
        {
            try
            {
                INewCustomerUserTypeService userTypeSvc =
                    (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name, context);
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
                    (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name, context);
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
                    (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name, context);
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
                    (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name, context);
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
                    (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name, context);
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
                    (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name, context);
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
                    (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name, context);
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
                    (INewCustomerUserTypeService)GetService(typeof(INewCustomerUserTypeService).Name, context);
                userTypeSvc.UserTypeDispose(disposing);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot Confirm Delete User type " + e.GetType().Name);
            }
        }
    }
}