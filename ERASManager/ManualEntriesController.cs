using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERASManager.Models;
using ERASManager.Models.EBOKTranformedData;

namespace ERASManager
{
    public class ManualEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManualEntries
        public ActionResult Index()
        {
            return View(db.ManualEntry.ToList());
        }

        // GET: ManualEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManualEntry manualEntry = db.ManualEntry.Find(id);
            if (manualEntry == null)
            {
                return HttpNotFound();
            }
            return View(manualEntry);
        }

        // GET: ManualEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManualEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Well,IndicatorDate,BLPD,AssumedGOR,WaterOverboard,Pumpablecargo,FreeWaterReceived,UllageMeasurement")] ManualEntry manualEntry)
        {
            if (ModelState.IsValid)
            {
                db.ManualEntry.Add(manualEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manualEntry);
        }

        // GET: ManualEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManualEntry manualEntry = db.ManualEntry.Find(id);
            if (manualEntry == null)
            {
                return HttpNotFound();
            }
            return View(manualEntry);
        }

        // POST: ManualEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Well,IndicatorDate,BLPD,AssumedGOR,WaterOverboard,Pumpablecargo,FreeWaterReceived,UllageMeasurement")] ManualEntry manualEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manualEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manualEntry);
        }

        // GET: ManualEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManualEntry manualEntry = db.ManualEntry.Find(id);
            if (manualEntry == null)
            {
                return HttpNotFound();
            }
            return View(manualEntry);
        }

        // POST: ManualEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManualEntry manualEntry = db.ManualEntry.Find(id);
            db.ManualEntry.Remove(manualEntry);
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
