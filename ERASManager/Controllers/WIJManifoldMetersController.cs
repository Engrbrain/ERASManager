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
    public class WIJManifoldMetersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WIJManifoldMeters
        public ActionResult Index()
        {
            return View(db.WIJManifoldMeters.ToList());
        }

        // GET: WIJManifoldMeters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIJManifoldMeter wIJManifoldMeter = db.WIJManifoldMeters.Find(id);
            if (wIJManifoldMeter == null)
            {
                return HttpNotFound();
            }
            return View(wIJManifoldMeter);
        }

        // GET: WIJManifoldMeters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WIJManifoldMeters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MeterName,CurrentEightHours,PreviousEightHours,TwentyFourHours,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WIJManifoldMeter wIJManifoldMeter)
        {
            if (ModelState.IsValid)
            {
                db.WIJManifoldMeters.Add(wIJManifoldMeter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wIJManifoldMeter);
        }

        // GET: WIJManifoldMeters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIJManifoldMeter wIJManifoldMeter = db.WIJManifoldMeters.Find(id);
            if (wIJManifoldMeter == null)
            {
                return HttpNotFound();
            }
            return View(wIJManifoldMeter);
        }

        // POST: WIJManifoldMeters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MeterName,CurrentEightHours,PreviousEightHours,TwentyFourHours,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WIJManifoldMeter wIJManifoldMeter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wIJManifoldMeter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wIJManifoldMeter);
        }

        // GET: WIJManifoldMeters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIJManifoldMeter wIJManifoldMeter = db.WIJManifoldMeters.Find(id);
            if (wIJManifoldMeter == null)
            {
                return HttpNotFound();
            }
            return View(wIJManifoldMeter);
        }

        // POST: WIJManifoldMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WIJManifoldMeter wIJManifoldMeter = db.WIJManifoldMeters.Find(id);
            db.WIJManifoldMeters.Remove(wIJManifoldMeter);
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
