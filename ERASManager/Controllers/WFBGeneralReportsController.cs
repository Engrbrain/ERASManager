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
    public class WFBGeneralReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WFBGeneralReports
        public ActionResult Index()
        {
            return View(db.WFBGeneralReports.ToList());
        }

        // GET: WFBGeneralReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBGeneralReport wFBGeneralReport = db.WFBGeneralReports.Find(id);
            if (wFBGeneralReport == null)
            {
                return HttpNotFound();
            }
            return View(wFBGeneralReport);
        }

        // GET: WFBGeneralReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WFBGeneralReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBGeneralReport wFBGeneralReport)
        {
            if (ModelState.IsValid)
            {
                db.WFBGeneralReports.Add(wFBGeneralReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wFBGeneralReport);
        }

        // GET: WFBGeneralReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBGeneralReport wFBGeneralReport = db.WFBGeneralReports.Find(id);
            if (wFBGeneralReport == null)
            {
                return HttpNotFound();
            }
            return View(wFBGeneralReport);
        }

        // POST: WFBGeneralReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBGeneralReport wFBGeneralReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wFBGeneralReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wFBGeneralReport);
        }

        // GET: WFBGeneralReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBGeneralReport wFBGeneralReport = db.WFBGeneralReports.Find(id);
            if (wFBGeneralReport == null)
            {
                return HttpNotFound();
            }
            return View(wFBGeneralReport);
        }

        // POST: WFBGeneralReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WFBGeneralReport wFBGeneralReport = db.WFBGeneralReports.Find(id);
            db.WFBGeneralReports.Remove(wFBGeneralReport);
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
