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
    public class UserTypeController : Controller
    {
        //private DBIntegrationContext db = new DBIntegrationContext();
        private INewCustomerUserTypeService service;
        public UserTypeController(INewCustomerUserTypeService service)
        {
            this.service = service;
        }
        //
        // GET: /UserType/

        public ActionResult Index()
        {
            return View(this.service.GetUserTypes());
        }

        //
        // GET: /UserType/Details/5

        public ActionResult Details(long id = 0)
        {
            UserType usertype = this.service.UserTypeDetails(id);
            if (usertype == null)
            {
                return HttpNotFound();
            }
            return View(usertype);
        }

        //
        // GET: /UserType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserType usertype)
        {
            if (ModelState.IsValid)
            {
                this.service.UserTypeCreate(usertype);
                return RedirectToAction("Index");
            }

            return View(usertype);
        }

        //
        // GET: /UserType/Edit/5

        public ActionResult Edit(long id = 0)
        {
            UserType usertype = this.service.UserTypeEdit(id);
            if (usertype == null)
            {
                return HttpNotFound();
            }
            return View(usertype);
        }

        //
        // POST: /UserType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserType usertype)
        {
            if (ModelState.IsValid)
            {
                this.service.UserTypeEdit(usertype);
                return RedirectToAction("Index");
            }
            return View(usertype);
        }

        //
        // GET: /UserType/Delete/5

        public ActionResult Delete(long id = 0)
        {
            UserType usertype = this.service.UserTypeDelete(id);
            if (usertype == null)
            {
                return HttpNotFound();
            }
            return View(usertype);
        }

        //
        // POST: /UserType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this.service.UserTypeDeleteConfirmed(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.service.UserTypeDispose(disposing);
            base.Dispose(disposing);
        }
    }
}