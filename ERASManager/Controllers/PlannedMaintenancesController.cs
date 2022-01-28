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
    public class PlannedMaintenancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlannedMaintenances
        public ActionResult Index()
        {
            return View(db.PlannedMaintenance.ToList());
        }

        // GET: PlannedMaintenances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlannedMaintenance plannedMaintenance = db.PlannedMaintenance.Find(id);
            if (plannedMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(plannedMaintenance);
        }

        // GET: PlannedMaintenances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlannedMaintenances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportCategory,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] PlannedMaintenance plannedMaintenance)
        {
            if (ModelState.IsValid)
            {
                db.PlannedMaintenance.Add(plannedMaintenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plannedMaintenance);
        }

        // GET: PlannedMaintenances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlannedMaintenance plannedMaintenance = db.PlannedMaintenance.Find(id);
            if (plannedMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(plannedMaintenance);
        }

        // POST: PlannedMaintenances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportCategory,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] PlannedMaintenance plannedMaintenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plannedMaintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plannedMaintenance);
        }

        // GET: PlannedMaintenances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlannedMaintenance plannedMaintenance = db.PlannedMaintenance.Find(id);
            if (plannedMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(plannedMaintenance);
        }

        // POST: PlannedMaintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlannedMaintenance plannedMaintenance = db.PlannedMaintenance.Find(id);
            db.PlannedMaintenance.Remove(plannedMaintenance);
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
