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
    public class EHSSReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EHSSReports
        public ActionResult Index()
        {
            return View(db.EHSSReports.ToList());
        }

        // GET: EHSSReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EHSSReport eHSSReport = db.EHSSReports.Find(id);
            if (eHSSReport == null)
            {
                return HttpNotFound();
            }
            return View(eHSSReport);
        }

        // GET: EHSSReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EHSSReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReportCategory,ReportParameter,ReportValue,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] EHSSReport eHSSReport)
        {
            if (ModelState.IsValid)
            {
                db.EHSSReports.Add(eHSSReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eHSSReport);
        }

        // GET: EHSSReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EHSSReport eHSSReport = db.EHSSReports.Find(id);
            if (eHSSReport == null)
            {
                return HttpNotFound();
            }
            return View(eHSSReport);
        }

        // POST: EHSSReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReportCategory,ReportParameter,ReportValue,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] EHSSReport eHSSReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eHSSReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eHSSReport);
        }

        // GET: EHSSReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EHSSReport eHSSReport = db.EHSSReports.Find(id);
            if (eHSSReport == null)
            {
                return HttpNotFound();
            }
            return View(eHSSReport);
        }

        // POST: EHSSReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EHSSReport eHSSReport = db.EHSSReports.Find(id);
            db.EHSSReports.Remove(eHSSReport);
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
