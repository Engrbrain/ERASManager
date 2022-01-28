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
    public class WFBProcessData_ReadingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WFBProcessData_Reading
        public ActionResult Index()
        {
            return View(db.WFBProcessData_Reading.ToList());
        }

        // GET: WFBProcessData_Reading/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBProcessData_Reading wFBProcessData_Reading = db.WFBProcessData_Reading.Find(id);
            if (wFBProcessData_Reading == null)
            {
                return HttpNotFound();
            }
            return View(wFBProcessData_Reading);
        }

        // GET: WFBProcessData_Reading/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WFBProcessData_Reading/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GasSource,Pressure,Temperature,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBProcessData_Reading wFBProcessData_Reading)
        {
            if (ModelState.IsValid)
            {
                db.WFBProcessData_Reading.Add(wFBProcessData_Reading);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wFBProcessData_Reading);
        }

        // GET: WFBProcessData_Reading/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBProcessData_Reading wFBProcessData_Reading = db.WFBProcessData_Reading.Find(id);
            if (wFBProcessData_Reading == null)
            {
                return HttpNotFound();
            }
            return View(wFBProcessData_Reading);
        }

        // POST: WFBProcessData_Reading/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GasSource,Pressure,Temperature,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBProcessData_Reading wFBProcessData_Reading)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wFBProcessData_Reading).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wFBProcessData_Reading);
        }

        // GET: WFBProcessData_Reading/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBProcessData_Reading wFBProcessData_Reading = db.WFBProcessData_Reading.Find(id);
            if (wFBProcessData_Reading == null)
            {
                return HttpNotFound();
            }
            return View(wFBProcessData_Reading);
        }

        // POST: WFBProcessData_Reading/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WFBProcessData_Reading wFBProcessData_Reading = db.WFBProcessData_Reading.Find(id);
            db.WFBProcessData_Reading.Remove(wFBProcessData_Reading);
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
