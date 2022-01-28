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
    public class PlantOperationsReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlantOperationsReports
        public ActionResult Index()
        {
            return View(db.PlantOperationsReports.ToList());
        }

        // GET: PlantOperationsReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantOperationsReport plantOperationsReport = db.PlantOperationsReports.Find(id);
            if (plantOperationsReport == null)
            {
                return HttpNotFound();
            }
            return View(plantOperationsReport);
        }

        // GET: PlantOperationsReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlantOperationsReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] PlantOperationsReport plantOperationsReport)
        {
            if (ModelState.IsValid)
            {
                db.PlantOperationsReports.Add(plantOperationsReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plantOperationsReport);
        }

        // GET: PlantOperationsReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantOperationsReport plantOperationsReport = db.PlantOperationsReports.Find(id);
            if (plantOperationsReport == null)
            {
                return HttpNotFound();
            }
            return View(plantOperationsReport);
        }

        // POST: PlantOperationsReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] PlantOperationsReport plantOperationsReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantOperationsReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plantOperationsReport);
        }

        // GET: PlantOperationsReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantOperationsReport plantOperationsReport = db.PlantOperationsReports.Find(id);
            if (plantOperationsReport == null)
            {
                return HttpNotFound();
            }
            return View(plantOperationsReport);
        }

        // POST: PlantOperationsReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlantOperationsReport plantOperationsReport = db.PlantOperationsReports.Find(id);
            db.PlantOperationsReports.Remove(plantOperationsReport);
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
