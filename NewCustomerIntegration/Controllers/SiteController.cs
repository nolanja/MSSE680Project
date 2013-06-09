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
    public class SiteController : Controller
    {
        //private DBIntegrationContext db = new DBIntegrationContext();
        private INewCustomerSiteService service;
        public SiteController(INewCustomerSiteService service)
        {
            this.service = service;
        }
        //
        // GET: /Site/

        public ActionResult Index()
        {
            var sites = this.service.GetSites();
            return View(sites.ToList());
        }

        //
        // GET: /Site/Details/5

        public ActionResult Details(long id = 0)
        {
            Site site = this.service.SiteDetails(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        //
        // GET: /Site/Create

        public ActionResult Create()
        {
            ViewBag.OrganizationId = this.service.SiteCreateOrganizationIDKey();
            ViewBag.SiteTypeId = this.service.SiteCreateSiteTypeIDKey();
            return View();
        }

        //
        // POST: /Site/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Site site)
        {
            if (ModelState.IsValid)
            {
                this.service.SiteCreate(site);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = this.service.SiteWriteOrganizationIDKey(site);
            ViewBag.SiteTypeId = this.service.SiteWriteSiteTypeIDKey(site);
            return View(site);
        }

        //
        // GET: /Site/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Site site = this.service.SiteEdit(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = this.service.SiteWriteOrganizationIDKey(site);
            ViewBag.SiteTypeId = this.service.SiteWriteSiteTypeIDKey(site);
            return View(site);
        }

        //
        // POST: /Site/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Site site)
        {
            if (ModelState.IsValid)
            {
                this.service.SiteEdit(site);
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = this.service.SiteWriteOrganizationIDKey(site);
            ViewBag.SiteTypeId = this.service.SiteWriteSiteTypeIDKey(site);
            return View(site);
        }

        //
        // GET: /Site/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Site site = this.service.SiteDelete(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        //
        // POST: /Site/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this.service.SiteDeleteConfirmed(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.service.SiteDispose(disposing);
            base.Dispose(disposing);
        }
    }
}