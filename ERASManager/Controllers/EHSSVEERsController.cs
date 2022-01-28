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
    public class EHSSVEERsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EHSSVEERs
        public ActionResult Index()
        {
            return View(db.EHSSVEERS.ToList());
        }

        // GET: EHSSVEERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EHSSVEER eHSSVEER = db.EHSSVEERS.Find(id);
            if (eHSSVEER == null)
            {
                return HttpNotFound();
            }
            return View(eHSSVEER);
        }

        // GET: EHSSVEERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EHSSVEERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParameterCategory,Parameter,Today,CurrentWeek,Month,Cummulative,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] EHSSVEER eHSSVEER)
        {
            if (ModelState.IsValid)
            {
                db.EHSSVEERS.Add(eHSSVEER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eHSSVEER);
        }

        // GET: EHSSVEERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EHSSVEER eHSSVEER = db.EHSSVEERS.Find(id);
            if (eHSSVEER == null)
            {
                return HttpNotFound();
            }
            return View(eHSSVEER);
        }

        // POST: EHSSVEERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParameterCategory,Parameter,Today,CurrentWeek,Month,Cummulative,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] EHSSVEER eHSSVEER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eHSSVEER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eHSSVEER);
        }

        // GET: EHSSVEERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EHSSVEER eHSSVEER = db.EHSSVEERS.Find(id);
            if (eHSSVEER == null)
            {
                return HttpNotFound();
            }
            return View(eHSSVEER);
        }

        // POST: EHSSVEERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EHSSVEER eHSSVEER = db.EHSSVEERS.Find(id);
            db.EHSSVEERS.Remove(eHSSVEER);
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
