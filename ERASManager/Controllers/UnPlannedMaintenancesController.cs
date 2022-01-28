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
    public class UnPlannedMaintenancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UnPlannedMaintenances
        public ActionResult Index()
        {
            return View(db.UnPlannedMaintenance.ToList());
        }

        // GET: UnPlannedMaintenances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnPlannedMaintenance unPlannedMaintenance = db.UnPlannedMaintenance.Find(id);
            if (unPlannedMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(unPlannedMaintenance);
        }

        // GET: UnPlannedMaintenances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnPlannedMaintenances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportCategory,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] UnPlannedMaintenance unPlannedMaintenance)
        {
            if (ModelState.IsValid)
            {
                db.UnPlannedMaintenance.Add(unPlannedMaintenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unPlannedMaintenance);
        }

        // GET: UnPlannedMaintenances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnPlannedMaintenance unPlannedMaintenance = db.UnPlannedMaintenance.Find(id);
            if (unPlannedMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(unPlannedMaintenance);
        }

        // POST: UnPlannedMaintenances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportCategory,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] UnPlannedMaintenance unPlannedMaintenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unPlannedMaintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unPlannedMaintenance);
        }

        // GET: UnPlannedMaintenances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnPlannedMaintenance unPlannedMaintenance = db.UnPlannedMaintenance.Find(id);
            if (unPlannedMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(unPlannedMaintenance);
        }

        // POST: UnPlannedMaintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnPlannedMaintenance unPlannedMaintenance = db.UnPlannedMaintenance.Find(id);
            db.UnPlannedMaintenance.Remove(unPlannedMaintenance);
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
