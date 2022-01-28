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
    public class PendingProjectWorkReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PendingProjectWorkReports
        public ActionResult Index()
        {
            return View(db.PendingProjectWorkReports.ToList());
        }

        // GET: PendingProjectWorkReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingProjectWorkReport pendingProjectWorkReport = db.PendingProjectWorkReports.Find(id);
            if (pendingProjectWorkReport == null)
            {
                return HttpNotFound();
            }
            return View(pendingProjectWorkReport);
        }

        // GET: PendingProjectWorkReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PendingProjectWorkReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] PendingProjectWorkReport pendingProjectWorkReport)
        {
            if (ModelState.IsValid)
            {
                db.PendingProjectWorkReports.Add(pendingProjectWorkReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pendingProjectWorkReport);
        }

        // GET: PendingProjectWorkReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingProjectWorkReport pendingProjectWorkReport = db.PendingProjectWorkReports.Find(id);
            if (pendingProjectWorkReport == null)
            {
                return HttpNotFound();
            }
            return View(pendingProjectWorkReport);
        }

        // POST: PendingProjectWorkReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] PendingProjectWorkReport pendingProjectWorkReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pendingProjectWorkReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pendingProjectWorkReport);
        }

        // GET: PendingProjectWorkReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PendingProjectWorkReport pendingProjectWorkReport = db.PendingProjectWorkReports.Find(id);
            if (pendingProjectWorkReport == null)
            {
                return HttpNotFound();
            }
            return View(pendingProjectWorkReport);
        }

        // POST: PendingProjectWorkReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PendingProjectWorkReport pendingProjectWorkReport = db.PendingProjectWorkReports.Find(id);
            db.PendingProjectWorkReports.Remove(pendingProjectWorkReport);
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
