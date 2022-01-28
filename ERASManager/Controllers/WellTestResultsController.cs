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
    public class WellTestResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WellTestResults
        public ActionResult Index()
        {
            return View(db.WellTestResults.ToList());
        }

        // GET: WellTestResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellTestResult wellTestResult = db.WellTestResults.Find(id);
            if (wellTestResult == null)
            {
                return HttpNotFound();
            }
            return View(wellTestResult);
        }

        // GET: WellTestResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WellTestResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rsv,Well,TestDate,Choke,Hours,THP,FLP,BSW,API,GROSSLIQUID,OIL,GAS,WATER,GOR,GLR,Ps,Pwf,FREQ,NETOILPOTENTIAL,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WellTestResult wellTestResult)
        {
            if (ModelState.IsValid)
            {
                db.WellTestResults.Add(wellTestResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wellTestResult);
        }

        // GET: WellTestResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellTestResult wellTestResult = db.WellTestResults.Find(id);
            if (wellTestResult == null)
            {
                return HttpNotFound();
            }
            return View(wellTestResult);
        }

        // POST: WellTestResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rsv,Well,TestDate,Choke,Hours,THP,FLP,BSW,API,GROSSLIQUID,OIL,GAS,WATER,GOR,GLR,Ps,Pwf,FREQ,NETOILPOTENTIAL,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WellTestResult wellTestResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wellTestResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wellTestResult);
        }

        // GET: WellTestResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellTestResult wellTestResult = db.WellTestResults.Find(id);
            if (wellTestResult == null)
            {
                return HttpNotFound();
            }
            return View(wellTestResult);
        }

        // POST: WellTestResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WellTestResult wellTestResult = db.WellTestResults.Find(id);
            db.WellTestResults.Remove(wellTestResult);
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
