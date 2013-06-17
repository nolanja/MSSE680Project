using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewCustomerIntegration.Services;
using NewCustomerIntegration.Domain.Models;
using NewCustomerIntegration.Factories;

namespace NewCustomerIntegration.Controllers
{
    public class AddressController : Controller
    {
        //private DBIntegrationContext db = new DBIntegrationContext();
        private INewCustomerAddressService service;

        public AddressController(INewCustomerAddressService service)
        {
            this.service = service;
        }

       

        //
        // GET: /Address/

        public ActionResult Index()
        {
            return View(this.service.GetAddresses());
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(long id = 0)
        {
            Address address = this.service.AddressDetails(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            ViewBag.SiteId = this.service.AddressCreateSiteKey();
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                this.service.AddressCreate(address);
                return RedirectToAction("Index");
            }

            ViewBag.SiteId = this.service.AddressWriteSiteKey(address);
            return View(address);
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Address address = this.service.AddressEdit(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.SiteId = this.service.AddressWriteSiteKey(address);
            return View(address);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                this.service.AddressEdit(address);
                return RedirectToAction("Index");
            }
            ViewBag.SiteId = this.service.AddressWriteSiteKey(address);
            return View(address);
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Address address = this.service.AddressDelete(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this.service.AddressDeleteConfirmed(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.service.AddressDispose(disposing);
            base.Dispose(disposing);
        }
    }
}