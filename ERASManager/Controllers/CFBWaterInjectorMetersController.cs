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
    public class CFBWaterInjectorMetersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBWaterInjectorMeters
        public ActionResult Index()
        {
            return View(db.CFBWaterInjectorMeters.ToList());
        }

        // GET: CFBWaterInjectorMeters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBWaterInjectorMeter cFBWaterInjectorMeter = db.CFBWaterInjectorMeters.Find(id);
            if (cFBWaterInjectorMeter == null)
            {
                return HttpNotFound();
            }
            return View(cFBWaterInjectorMeter);
        }

        // GET: CFBWaterInjectorMeters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBWaterInjectorMeters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MeterName,CurrentEightHours,PreviousEightHours,TwentyFourHours,Press,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBWaterInjectorMeter cFBWaterInjectorMeter)
        {
            if (ModelState.IsValid)
            {
                db.CFBWaterInjectorMeters.Add(cFBWaterInjectorMeter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBWaterInjectorMeter);
        }

        // GET: CFBWaterInjectorMeters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBWaterInjectorMeter cFBWaterInjectorMeter = db.CFBWaterInjectorMeters.Find(id);
            if (cFBWaterInjectorMeter == null)
            {
                return HttpNotFound();
            }
            return View(cFBWaterInjectorMeter);
        }

        // POST: CFBWaterInjectorMeters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MeterName,CurrentEightHours,PreviousEightHours,TwentyFourHours,Press,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBWaterInjectorMeter cFBWaterInjectorMeter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBWaterInjectorMeter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBWaterInjectorMeter);
        }

        // GET: CFBWaterInjectorMeters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBWaterInjectorMeter cFBWaterInjectorMeter = db.CFBWaterInjectorMeters.Find(id);
            if (cFBWaterInjectorMeter == null)
            {
                return HttpNotFound();
            }
            return View(cFBWaterInjectorMeter);
        }

        // POST: CFBWaterInjectorMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBWaterInjectorMeter cFBWaterInjectorMeter = db.CFBWaterInjectorMeters.Find(id);
            db.CFBWaterInjectorMeters.Remove(cFBWaterInjectorMeter);
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
