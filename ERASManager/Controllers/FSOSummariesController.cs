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
    public class FSOSummariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FSOSummaries
        public ActionResult Index()
        {
            return View(db.FSOSummaries.ToList());
        }

        // GET: FSOSummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSOSummary fSOSummary = db.FSOSummaries.Find(id);
            if (fSOSummary == null)
            {
                return HttpNotFound();
            }
            return View(fSOSummary);
        }

        // GET: FSOSummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FSOSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] FSOSummary fSOSummary)
        {
            if (ModelState.IsValid)
            {
                db.FSOSummaries.Add(fSOSummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fSOSummary);
        }

        // GET: FSOSummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSOSummary fSOSummary = db.FSOSummaries.Find(id);
            if (fSOSummary == null)
            {
                return HttpNotFound();
            }
            return View(fSOSummary);
        }

        // POST: FSOSummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] FSOSummary fSOSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fSOSummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fSOSummary);
        }

        // GET: FSOSummaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSOSummary fSOSummary = db.FSOSummaries.Find(id);
            if (fSOSummary == null)
            {
                return HttpNotFound();
            }
            return View(fSOSummary);
        }

        // POST: FSOSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FSOSummary fSOSummary = db.FSOSummaries.Find(id);
            db.FSOSummaries.Remove(fSOSummary);
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
