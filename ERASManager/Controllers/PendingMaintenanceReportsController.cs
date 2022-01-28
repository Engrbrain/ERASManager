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
    public class PendingMaintenanceReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PendingMaintenanceReports
        public ActionResult Index()
        {
            return View(db.PendingMaintenanceReports.ToList());
        }

        // GET: PendingMaintenanceReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingMaintenanceReport pendingMaintenanceReport = db.PendingMaintenanceReports.Find(id);
            if (pendingMaintenanceReport == null)
            {
                return HttpNotFound();
            }
            return View(pendingMaintenanceReport);
        }

        // GET: PendingMaintenanceReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PendingMaintenanceReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] PendingMaintenanceReport pendingMaintenanceReport)
        {
            if (ModelState.IsValid)
            {
                db.PendingMaintenanceReports.Add(pendingMaintenanceReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pendingMaintenanceReport);
        }

        // GET: PendingMaintenanceReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingMaintenanceReport pendingMaintenanceReport = db.PendingMaintenanceReports.Find(id);
            if (pendingMaintenanceReport == null)
            {
                return HttpNotFound();
            }
            return View(pendingMaintenanceReport);
        }

        // POST: PendingMaintenanceReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] PendingMaintenanceReport pendingMaintenanceReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pendingMaintenanceReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pendingMaintenanceReport);
        }

        // GET: PendingMaintenanceReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingMaintenanceReport pendingMaintenanceReport = db.PendingMaintenanceReports.Find(id);
            if (pendingMaintenanceReport == null)
            {
                return HttpNotFound();
            }
            return View(pendingMaintenanceReport);
        }

        // POST: PendingMaintenanceReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PendingMaintenanceReport pendingMaintenanceReport = db.PendingMaintenanceReports.Find(id);
            db.PendingMaintenanceReports.Remove(pendingMaintenanceReport);
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
