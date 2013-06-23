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

    public class PeopleManagement : Manager
    {

        public DBIntegrationContext context;

        public PeopleManagement()
        {
            this.context = new DBIntegrationContext();
        }

        public PeopleManagement(DBIntegrationContext dbContext)
        {
            this.context = dbContext;
        }

        public void ListPeople()
        {
            try
            {
                INewCustomerPersonService personSvc =
                    (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name, context);
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
                    (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name, context);
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
                    (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name, context);
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
                    (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name, context);
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
                    (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name, context);
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
                    (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name, context);
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
                    (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name, context);
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
                    (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name, context);
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
                    (INewCustomerPersonService)GetService(typeof(INewCustomerPersonService).Name, context);
                personSvc.PeopleDispose(dispose);

            }
            catch (Exception e)
            {
                throw new Exception("Cannot confirm Person deleted " + e.GetType().Name);
            }
        }
    }
}