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
    public class CFBProcessData_ReadingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBProcessData_Reading
        public ActionResult Index()
        {
            return View(db.CFBProcessData_Reading.ToList());
        }

        // GET: CFBProcessData_Reading/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBProcessData_Reading cFBProcessData_Reading = db.CFBProcessData_Reading.Find(id);
            if (cFBProcessData_Reading == null)
            {
                return HttpNotFound();
            }
            return View(cFBProcessData_Reading);
        }

        // GET: CFBProcessData_Reading/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBProcessData_Reading/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GasSource,Pressure,Temperature,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBProcessData_Reading cFBProcessData_Reading)
        {
            if (ModelState.IsValid)
            {
                db.CFBProcessData_Reading.Add(cFBProcessData_Reading);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBProcessData_Reading);
        }

        // GET: CFBProcessData_Reading/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBProcessData_Reading cFBProcessData_Reading = db.CFBProcessData_Reading.Find(id);
            if (cFBProcessData_Reading == null)
            {
                return HttpNotFound();
            }
            return View(cFBProcessData_Reading);
        }

        // POST: CFBProcessData_Reading/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GasSource,Pressure,Temperature,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBProcessData_Reading cFBProcessData_Reading)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBProcessData_Reading).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBProcessData_Reading);
        }

        // GET: CFBProcessData_Reading/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBProcessData_Reading cFBProcessData_Reading = db.CFBProcessData_Reading.Find(id);
            if (cFBProcessData_Reading == null)
            {
                return HttpNotFound();
            }
            return View(cFBProcessData_Reading);
        }

        // POST: CFBProcessData_Reading/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBProcessData_Reading cFBProcessData_Reading = db.CFBProcessData_Reading.Find(id);
            db.CFBProcessData_Reading.Remove(cFBProcessData_Reading);
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
