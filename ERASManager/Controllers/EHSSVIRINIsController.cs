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
    public class EHSSVIRINIsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EHSSVIRINIs
        public ActionResult Index()
        {
            return View(db.EHSSVIRINIS.ToList());
        }

        // GET: EHSSVIRINIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EHSSVIRINI eHSSVIRINI = db.EHSSVIRINIS.Find(id);
            if (eHSSVIRINI == null)
            {
                return HttpNotFound();
            }
            return View(eHSSVIRINI);
        }

        // GET: EHSSVIRINIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EHSSVIRINIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParameterCategory,Parameter,Today,CurrentWeek,Month,Cummulative,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] EHSSVIRINI eHSSVIRINI)
        {
            if (ModelState.IsValid)
            {
                db.EHSSVIRINIS.Add(eHSSVIRINI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eHSSVIRINI);
        }

        // GET: EHSSVIRINIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EHSSVIRINI eHSSVIRINI = db.EHSSVIRINIS.Find(id);
            if (eHSSVIRINI == null)
            {
                return HttpNotFound();
            }
            return View(eHSSVIRINI);
        }

        // POST: EHSSVIRINIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParameterCategory,Parameter,Today,CurrentWeek,Month,Cummulative,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] EHSSVIRINI eHSSVIRINI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eHSSVIRINI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eHSSVIRINI);
        }

        // GET: EHSSVIRINIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EHSSVIRINI eHSSVIRINI = db.EHSSVIRINIS.Find(id);
            if (eHSSVIRINI == null)
            {
                return HttpNotFound();
            }
            return View(eHSSVIRINI);
        }

        // POST: EHSSVIRINIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EHSSVIRINI eHSSVIRINI = db.EHSSVIRINIS.Find(id);
            db.EHSSVIRINIS.Remove(eHSSVIRINI);
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
