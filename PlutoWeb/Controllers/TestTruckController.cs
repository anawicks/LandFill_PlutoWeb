using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;

namespace PlutoWeb.Controllers
{
    public class TestTruckController : Controller
    {
        private PlutoContext db = new PlutoContext();

        // GET: TestTruck
        public ActionResult Index()
        {
            return View(db.tblTruckCompanies.ToList());
        }

        // GET: TestTruck/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTruckCompanies tblTruckCompanies = db.tblTruckCompanies.Find(id);
            if (tblTruckCompanies == null)
            {
                return HttpNotFound();
            }
            return View(tblTruckCompanies);
        }

        // GET: TestTruck/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestTruck/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TruckCompId,TruckCompName,TruckCompAddr,TruckCompCity,TruckCompProv,TruckCompPostal,TruckCompPhone")] tblTruckCompanies tblTruckCompanies)
        {
            if (ModelState.IsValid)
            {
                db.tblTruckCompanies.Add(tblTruckCompanies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTruckCompanies);
        }

        // GET: TestTruck/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTruckCompanies tblTruckCompanies = db.tblTruckCompanies.Find(id);
            if (tblTruckCompanies == null)
            {
                return HttpNotFound();
            }
            return View(tblTruckCompanies);
        }

        // POST: TestTruck/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TruckCompId,TruckCompName,TruckCompAddr,TruckCompCity,TruckCompProv,TruckCompPostal,TruckCompPhone")] tblTruckCompanies tblTruckCompanies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTruckCompanies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTruckCompanies);
        }

        // GET: TestTruck/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTruckCompanies tblTruckCompanies = db.tblTruckCompanies.Find(id);
            if (tblTruckCompanies == null)
            {
                return HttpNotFound();
            }
            return View(tblTruckCompanies);
        }

        // POST: TestTruck/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTruckCompanies tblTruckCompanies = db.tblTruckCompanies.Find(id);
            db.tblTruckCompanies.Remove(tblTruckCompanies);
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
