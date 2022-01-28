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
    public class CFBWaterInjectorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBWaterInjectors
        public ActionResult Index()
        {
            return View(db.CFBWaterInjectors.ToList());
        }

        // GET: CFBWaterInjectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBWaterInjector cFBWaterInjector = db.CFBWaterInjectors.Find(id);
            if (cFBWaterInjector == null)
            {
                return HttpNotFound();
            }
            return View(cFBWaterInjector);
        }

        // GET: CFBWaterInjectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBWaterInjectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WaterInjector,Choke,D_Time,THP,FLP,VolumeInjected,Remarks,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBWaterInjector cFBWaterInjector)
        {
            if (ModelState.IsValid)
            {
                db.CFBWaterInjectors.Add(cFBWaterInjector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBWaterInjector);
        }

        // GET: CFBWaterInjectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBWaterInjector cFBWaterInjector = db.CFBWaterInjectors.Find(id);
            if (cFBWaterInjector == null)
            {
                return HttpNotFound();
            }
            return View(cFBWaterInjector);
        }

        // POST: CFBWaterInjectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WaterInjector,Choke,D_Time,THP,FLP,VolumeInjected,Remarks,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBWaterInjector cFBWaterInjector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBWaterInjector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBWaterInjector);
        }

        // GET: CFBWaterInjectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBWaterInjector cFBWaterInjector = db.CFBWaterInjectors.Find(id);
            if (cFBWaterInjector == null)
            {
                return HttpNotFound();
            }
            return View(cFBWaterInjector);
        }

        // POST: CFBWaterInjectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBWaterInjector cFBWaterInjector = db.CFBWaterInjectors.Find(id);
            db.CFBWaterInjectors.Remove(cFBWaterInjector);
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
