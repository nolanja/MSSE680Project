using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewCustomerIntegration.Domain.Models;

namespace NewCustomerIntegration.Controllers
{
    public class SiteController : Controller
    {
        private DBIntegrationContext db = new DBIntegrationContext();

        //
        // GET: /Site/

        public ActionResult Index()
        {
            var sites = db.Sites.Include(s => s.Organization).Include(s => s.SiteType);
            return View(sites.ToList());
        }

        //
        // GET: /Site/Details/5

        public ActionResult Details(long id = 0)
        {
            Site site = db.Sites.Find(id);
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
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "OrganizationCode");
            ViewBag.SiteTypeId = new SelectList(db.SiteTypes, "SiteTypeId", "SiteTypeName");
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
                db.Sites.Add(site);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "OrganizationCode", site.OrganizationId);
            ViewBag.SiteTypeId = new SelectList(db.SiteTypes, "SiteTypeId", "SiteTypeName", site.SiteTypeId);
            return View(site);
        }

        //
        // GET: /Site/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "OrganizationCode", site.OrganizationId);
            ViewBag.SiteTypeId = new SelectList(db.SiteTypes, "SiteTypeId", "SiteTypeName", site.SiteTypeId);
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
                db.Entry(site).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "OrganizationCode", site.OrganizationId);
            ViewBag.SiteTypeId = new SelectList(db.SiteTypes, "SiteTypeId", "SiteTypeName", site.SiteTypeId);
            return View(site);
        }

        //
        // GET: /Site/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Site site = db.Sites.Find(id);
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
            Site site = db.Sites.Find(id);
            db.Sites.Remove(site);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}