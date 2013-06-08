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
    public class SiteTypeController : Controller
    {
        private DBIntegrationContext db = new DBIntegrationContext();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.SiteTypes.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(long id = 0)
        {
            SiteType sitetype = db.SiteTypes.Find(id);
            if (sitetype == null)
            {
                return HttpNotFound();
            }
            return View(sitetype);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteType sitetype)
        {
            if (ModelState.IsValid)
            {
                db.SiteTypes.Add(sitetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sitetype);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(long id = 0)
        {
            SiteType sitetype = db.SiteTypes.Find(id);
            if (sitetype == null)
            {
                return HttpNotFound();
            }
            return View(sitetype);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiteType sitetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sitetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sitetype);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(long id = 0)
        {
            SiteType sitetype = db.SiteTypes.Find(id);
            if (sitetype == null)
            {
                return HttpNotFound();
            }
            return View(sitetype);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SiteType sitetype = db.SiteTypes.Find(id);
            db.SiteTypes.Remove(sitetype);
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