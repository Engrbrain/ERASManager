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
    public class UnPlannedMaintenanceReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UnPlannedMaintenanceReports
        public ActionResult Index()
        {
            return View(db.UnPlannedMaintenanceReports.ToList());
        }

        // GET: UnPlannedMaintenanceReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnPlannedMaintenanceReport unPlannedMaintenanceReport = db.UnPlannedMaintenanceReports.Find(id);
            if (unPlannedMaintenanceReport == null)
            {
                return HttpNotFound();
            }
            return View(unPlannedMaintenanceReport);
        }

        // GET: UnPlannedMaintenanceReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnPlannedMaintenanceReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] UnPlannedMaintenanceReport unPlannedMaintenanceReport)
        {
            if (ModelState.IsValid)
            {
                db.UnPlannedMaintenanceReports.Add(unPlannedMaintenanceReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unPlannedMaintenanceReport);
        }

        // GET: UnPlannedMaintenanceReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnPlannedMaintenanceReport unPlannedMaintenanceReport = db.UnPlannedMaintenanceReports.Find(id);
            if (unPlannedMaintenanceReport == null)
            {
                return HttpNotFound();
            }
            return View(unPlannedMaintenanceReport);
        }

        // POST: UnPlannedMaintenanceReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] UnPlannedMaintenanceReport unPlannedMaintenanceReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unPlannedMaintenanceReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unPlannedMaintenanceReport);
        }

        // GET: UnPlannedMaintenanceReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnPlannedMaintenanceReport unPlannedMaintenanceReport = db.UnPlannedMaintenanceReports.Find(id);
            if (unPlannedMaintenanceReport == null)
            {
                return HttpNotFound();
            }
            return View(unPlannedMaintenanceReport);
        }

        // POST: UnPlannedMaintenanceReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnPlannedMaintenanceReport unPlannedMaintenanceReport = db.UnPlannedMaintenanceReports.Find(id);
            db.UnPlannedMaintenanceReports.Remove(unPlannedMaintenanceReport);
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
