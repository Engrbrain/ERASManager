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
    public class CFBSummariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBSummaries
        public ActionResult Index()
        {
            return View(db.CFBSummaries.ToList());
        }

        // GET: CFBSummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBSummary cFBSummary = db.CFBSummaries.Find(id);
            if (cFBSummary == null)
            {
                return HttpNotFound();
            }
            return View(cFBSummary);
        }

        // GET: CFBSummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBSummary cFBSummary)
        {
            if (ModelState.IsValid)
            {
                db.CFBSummaries.Add(cFBSummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBSummary);
        }

        // GET: CFBSummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBSummary cFBSummary = db.CFBSummaries.Find(id);
            if (cFBSummary == null)
            {
                return HttpNotFound();
            }
            return View(cFBSummary);
        }

        // POST: CFBSummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBSummary cFBSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBSummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBSummary);
        }

        // GET: CFBSummaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBSummary cFBSummary = db.CFBSummaries.Find(id);
            if (cFBSummary == null)
            {
                return HttpNotFound();
            }
            return View(cFBSummary);
        }

        // POST: CFBSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBSummary cFBSummary = db.CFBSummaries.Find(id);
            db.CFBSummaries.Remove(cFBSummary);
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
