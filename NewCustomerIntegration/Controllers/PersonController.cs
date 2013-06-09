using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewCustomerIntegration.Services;
using NewCustomerIntegration.Domain.Models;

namespace NewCustomerIntegration.Controllers
{
    public class PersonController : Controller
    {
        //private DBIntegrationContext db = new DBIntegrationContext();
        private INewCustomerPersonService service;
        public PersonController(INewCustomerPersonService service)
        {
            this.service = service;
        }

        //
        // GET: /Person/

        public ActionResult Index()
        {
            return View(this.service.GetPeople());
        }

        //
        // GET: /Person/Details/5

        public ActionResult Details(long id = 0)
        {
            Person person = this.service.PersonDetails(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Person/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                this.service.PersonCreate(person);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = this.service.PersonWriteOrganizationIDKey(person);
            ViewBag.UserTypeId = this.service.PersonWriteUserTypeIDKey(person);
            return View(person);
        }

        //
        // GET: /Person/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Person person = this.service.PersonEdit(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = this.service.PersonWriteOrganizationIDKey(person);
            ViewBag.UserTypeId = this.service.PersonWriteUserTypeIDKey(person);
            return View(person);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                this.service.PersonEdit(person);
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = this.service.PersonWriteOrganizationIDKey(person);
            ViewBag.UserTypeId = this.service.PersonWriteUserTypeIDKey(person);
            return View(person);
        }

        //
        // GET: /Person/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Person person = this.service.PersonDelete(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Person/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this.service.PersonDeleteConfirmed(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.service.PeopleDispose(disposing);
            base.Dispose(disposing);
        }
    }
}