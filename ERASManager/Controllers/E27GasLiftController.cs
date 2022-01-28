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
    public class E27GasLiftController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: E27GasLift
        public ActionResult Index()
        {
            return View(db.E27GasLifts.ToList());
        }

        // GET: E27GasLift/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E27GasLift e27GasLift = db.E27GasLifts.Find(id);
            if (e27GasLift == null)
            {
                return HttpNotFound();
            }
            return View(e27GasLift);
        }

        // GET: E27GasLift/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: E27GasLift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GasLift,Blpd,InterpolationResult,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] E27GasLift e27GasLift)
        {
            if (ModelState.IsValid)
            {
                db.E27GasLifts.Add(e27GasLift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(e27GasLift);
        }

        // GET: E27GasLift/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E27GasLift e27GasLift = db.E27GasLifts.Find(id);
            if (e27GasLift == null)
            {
                return HttpNotFound();
            }
            return View(e27GasLift);
        }

        // POST: E27GasLift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GasLift,Blpd,InterpolationResult,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] E27GasLift e27GasLift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e27GasLift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e27GasLift);
        }

        // GET: E27GasLift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E27GasLift e27GasLift = db.E27GasLifts.Find(id);
            if (e27GasLift == null)
            {
                return HttpNotFound();
            }
            return View(e27GasLift);
        }

        // POST: E27GasLift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            E27GasLift e27GasLift = db.E27GasLifts.Find(id);
            db.E27GasLifts.Remove(e27GasLift);
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
