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
    public class WFBWaterInjectorMetersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WFBWaterInjectorMeters
        public ActionResult Index()
        {
            return View(db.WFBWaterInjectorMeters.ToList());
        }

        // GET: WFBWaterInjectorMeters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBWaterInjectorMeter wFBWaterInjectorMeter = db.WFBWaterInjectorMeters.Find(id);
            if (wFBWaterInjectorMeter == null)
            {
                return HttpNotFound();
            }
            return View(wFBWaterInjectorMeter);
        }

        // GET: WFBWaterInjectorMeters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WFBWaterInjectorMeters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MeterName,CurrentEightHours,PreviousEightHours,TwentyFourHours,LFP,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBWaterInjectorMeter wFBWaterInjectorMeter)
        {
            if (ModelState.IsValid)
            {
                db.WFBWaterInjectorMeters.Add(wFBWaterInjectorMeter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wFBWaterInjectorMeter);
        }

        // GET: WFBWaterInjectorMeters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBWaterInjectorMeter wFBWaterInjectorMeter = db.WFBWaterInjectorMeters.Find(id);
            if (wFBWaterInjectorMeter == null)
            {
                return HttpNotFound();
            }
            return View(wFBWaterInjectorMeter);
        }

        // POST: WFBWaterInjectorMeters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MeterName,CurrentEightHours,PreviousEightHours,TwentyFourHours,LFP,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBWaterInjectorMeter wFBWaterInjectorMeter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wFBWaterInjectorMeter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wFBWaterInjectorMeter);
        }

        // GET: WFBWaterInjectorMeters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBWaterInjectorMeter wFBWaterInjectorMeter = db.WFBWaterInjectorMeters.Find(id);
            if (wFBWaterInjectorMeter == null)
            {
                return HttpNotFound();
            }
            return View(wFBWaterInjectorMeter);
        }

        // POST: WFBWaterInjectorMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WFBWaterInjectorMeter wFBWaterInjectorMeter = db.WFBWaterInjectorMeters.Find(id);
            db.WFBWaterInjectorMeters.Remove(wFBWaterInjectorMeter);
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
