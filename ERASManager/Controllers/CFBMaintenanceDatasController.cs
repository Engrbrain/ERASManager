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
    public class CFBMaintenanceDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBMaintenanceDatas
        public ActionResult Index()
        {
            return View(db.CFBMaintenanceData.ToList());
        }

        // GET: CFBMaintenanceDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBMaintenanceData cFBMaintenanceData = db.CFBMaintenanceData.Find(id);
            if (cFBMaintenanceData == null)
            {
                return HttpNotFound();
            }
            return View(cFBMaintenanceData);
        }

        // GET: CFBMaintenanceDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBMaintenanceDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Parameters,DailyTotal,PreviousTotal,Cummulative,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBMaintenanceData cFBMaintenanceData)
        {
            if (ModelState.IsValid)
            {
                db.CFBMaintenanceData.Add(cFBMaintenanceData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBMaintenanceData);
        }

        // GET: CFBMaintenanceDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBMaintenanceData cFBMaintenanceData = db.CFBMaintenanceData.Find(id);
            if (cFBMaintenanceData == null)
            {
                return HttpNotFound();
            }
            return View(cFBMaintenanceData);
        }

        // POST: CFBMaintenanceDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Parameters,DailyTotal,PreviousTotal,Cummulative,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBMaintenanceData cFBMaintenanceData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBMaintenanceData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBMaintenanceData);
        }

        // GET: CFBMaintenanceDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBMaintenanceData cFBMaintenanceData = db.CFBMaintenanceData.Find(id);
            if (cFBMaintenanceData == null)
            {
                return HttpNotFound();
            }
            return View(cFBMaintenanceData);
        }

        // POST: CFBMaintenanceDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBMaintenanceData cFBMaintenanceData = db.CFBMaintenanceData.Find(id);
            db.CFBMaintenanceData.Remove(cFBMaintenanceData);
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
