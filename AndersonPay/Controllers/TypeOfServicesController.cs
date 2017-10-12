using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AndersonPay.Models.InvoiceContext;
using AndersonPay.Models;

namespace AndersonPay.Controllers
{
    public class TypeOfServicesController : Controller
    {
        private InvoiceContext db = new InvoiceContext();

        // GET: TypeOfServices
        public ActionResult Index()
        {
            return View(db.typeofservices.ToList());
        }

        // GET: TypeOfServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeofservice typeofservice = db.typeofservices.Find(id);
            if (typeofservice == null)
            {
                return HttpNotFound();
            }
            return View(typeofservice);
        }

        // GET: TypeOfServices/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: TypeOfServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "typeofserviceId,NameOfService,Rate,Currency,ServiceDescription")] typeofservice typeofservice)
        {
            if (ModelState.IsValid)
            {
                db.typeofservices.Add(typeofservice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: TypeOfServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeofservice typeofservice = db.typeofservices.Find(id);
            if (typeofservice == null)
            {
                return HttpNotFound();
            }
            return PartialView(typeofservice);
        }

        // POST: TypeOfServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "typeofserviceId,NameOfService,Rate,Currency,ServiceDescription")] typeofservice typeofservice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeofservice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: TypeOfServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeofservice typeofservice = db.typeofservices.Find(id);
            if (typeofservice == null)
            {
                return HttpNotFound();
            }
            return PartialView(typeofservice);
        }

        // POST: TypeOfServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            typeofservice typeofservice = db.typeofservices.Find(id);
            db.typeofservices.Remove(typeofservice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
