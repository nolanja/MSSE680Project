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
    public class RuleController : Controller
    {
        //private DBIntegrationContext db = new DBIntegrationContext();
        private INewCustomerRuleService service;
        public RuleController(INewCustomerRuleService service)
        {
            this.service = service;
        }
        //
        // GET: /Rule/

        public ActionResult Index()
        {
            return View(this.service.GetRules());
        }

        //
        // GET: /Rule/Details/5

        public ActionResult Details(long id = 0)
        {
            NewCustomerIntegration.Domain.Models.Rule rule = this.service.RuleDetails(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        //
        // GET: /Rule/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Rule/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewCustomerIntegration.Domain.Models.Rule rule)
        {
            if (ModelState.IsValid)
            {
                this.service.RuleCreate(rule);
                return RedirectToAction("Index");
            }

            return View(rule);
        }

        //
        // GET: /Rule/Edit/5

        public ActionResult Edit(long id = 0)
        {
            NewCustomerIntegration.Domain.Models.Rule rule = this.service.RuleEdit(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        //
        // POST: /Rule/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewCustomerIntegration.Domain.Models.Rule rule)
        {
            if (ModelState.IsValid)
            {
                this.service.RuleEdit(rule);
                return RedirectToAction("Index");
            }
            return View(rule);
        }

        //
        // GET: /Rule/Delete/5

        public ActionResult Delete(long id = 0)
        {
            NewCustomerIntegration.Domain.Models.Rule rule = this.service.RuleDelete(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        //
        // POST: /Rule/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this.service.RuleDeleteConfirmed(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.service.RuleDispose(disposing);
            base.Dispose(disposing);
        }
    }
}