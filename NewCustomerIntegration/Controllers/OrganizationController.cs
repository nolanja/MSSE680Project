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
    public class OrganizationController : Controller
    {
        //private DBIntegrationContext db = new DBIntegrationContext();
        private INewCustomerOrganizationService service;
        public OrganizationController(INewCustomerOrganizationService service)
        {
            this.service = service;
        }
        //
        // GET: /Organization/

        public ActionResult Index()
        {
            return View(this.service.GetOrganizationNames());
        }

        //
        // GET: /Organization/Details/5

        public ActionResult Details(long id = 0)
        {
            Organization organization = this.service.OrganizationDetails(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // GET: /Organization/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Organization/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                this.service.OrganizationCreate(organization);
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        //
        // GET: /Organization/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Organization organization = this.service.OrganizationEdit(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // POST: /Organization/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                this.service.OrganizationEdit(organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        //
        // GET: /Organization/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Organization organization = this.service.OrganizationDelete(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // POST: /Organization/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this.service.OrganizationDeleteConfirmed(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.service.OrganizationDispose(disposing);
            base.Dispose(disposing);
        }
    }
}