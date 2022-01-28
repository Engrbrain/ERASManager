using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERASManager.Models;
using ERASManager.Models.EBOKDailyReport;

namespace ERASManager.Controllers
{
    public class CONSUMABLESANALYSISController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CONSUMABLESANALYSIS
        public ActionResult Index()
        {
            return View(db.CONSUMABLESANALYSIS.ToList());
        }

        // GET: CONSUMABLESANALYSIS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSUMABLESANALYSIS cONSUMABLESANALYSIS = db.CONSUMABLESANALYSIS.Find(id);
            if (cONSUMABLESANALYSIS == null)
            {
                return HttpNotFound();
            }
            return View(cONSUMABLESANALYSIS);
        }

        // GET: CONSUMABLESANALYSIS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CONSUMABLESANALYSIS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Parameters,PrevROB,Produced,Received,DailyConsumption,ROB,ConsumptionYTD,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CONSUMABLESANALYSIS cONSUMABLESANALYSIS)
        {
            if (ModelState.IsValid)
            {
                db.CONSUMABLESANALYSIS.Add(cONSUMABLESANALYSIS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cONSUMABLESANALYSIS);
        }

        // GET: CONSUMABLESANALYSIS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSUMABLESANALYSIS cONSUMABLESANALYSIS = db.CONSUMABLESANALYSIS.Find(id);
            if (cONSUMABLESANALYSIS == null)
            {
                return HttpNotFound();
            }
            return View(cONSUMABLESANALYSIS);
        }

        // POST: CONSUMABLESANALYSIS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Parameters,PrevROB,Produced,Received,DailyConsumption,ROB,ConsumptionYTD,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CONSUMABLESANALYSIS cONSUMABLESANALYSIS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONSUMABLESANALYSIS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cONSUMABLESANALYSIS);
        }

        // GET: CONSUMABLESANALYSIS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSUMABLESANALYSIS cONSUMABLESANALYSIS = db.CONSUMABLESANALYSIS.Find(id);
            if (cONSUMABLESANALYSIS == null)
            {
                return HttpNotFound();
            }
            return View(cONSUMABLESANALYSIS);
        }

        // POST: CONSUMABLESANALYSIS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CONSUMABLESANALYSIS cONSUMABLESANALYSIS = db.CONSUMABLESANALYSIS.Find(id);
            db.CONSUMABLESANALYSIS.Remove(cONSUMABLESANALYSIS);
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
