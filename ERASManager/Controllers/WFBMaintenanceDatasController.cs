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
    public class WFBMaintenanceDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WFBMaintenanceDatas
        public ActionResult Index()
        {
            return View(db.WFBMaintenanceData.ToList());
        }

        // GET: WFBMaintenanceDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBMaintenanceData wFBMaintenanceData = db.WFBMaintenanceData.Find(id);
            if (wFBMaintenanceData == null)
            {
                return HttpNotFound();
            }
            return View(wFBMaintenanceData);
        }

        // GET: WFBMaintenanceDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WFBMaintenanceDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Parameters,DailyTotal,PreviousTotal,Cummulative,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBMaintenanceData wFBMaintenanceData)
        {
            if (ModelState.IsValid)
            {
                db.WFBMaintenanceData.Add(wFBMaintenanceData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wFBMaintenanceData);
        }

        // GET: WFBMaintenanceDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBMaintenanceData wFBMaintenanceData = db.WFBMaintenanceData.Find(id);
            if (wFBMaintenanceData == null)
            {
                return HttpNotFound();
            }
            return View(wFBMaintenanceData);
        }

        // POST: WFBMaintenanceDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Parameters,DailyTotal,PreviousTotal,Cummulative,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBMaintenanceData wFBMaintenanceData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wFBMaintenanceData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wFBMaintenanceData);
        }

        // GET: WFBMaintenanceDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBMaintenanceData wFBMaintenanceData = db.WFBMaintenanceData.Find(id);
            if (wFBMaintenanceData == null)
            {
                return HttpNotFound();
            }
            return View(wFBMaintenanceData);
        }

        // POST: WFBMaintenanceDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WFBMaintenanceData wFBMaintenanceData = db.WFBMaintenanceData.Find(id);
            db.WFBMaintenanceData.Remove(wFBMaintenanceData);
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
