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
    public class CFBGasCompressionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBGasCompressions
        public ActionResult Index()
        {
            return View(db.CFBGasCompressions.ToList());
        }

        // GET: CFBGasCompressions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBGasCompression cFBGasCompression = db.CFBGasCompressions.Find(id);
            if (cFBGasCompression == null)
            {
                return HttpNotFound();
            }
            return View(cFBGasCompression);
        }

        // GET: CFBGasCompressions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBGasCompressions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Compressor,SuctionPressure,DischargePressure,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBGasCompression cFBGasCompression)
        {
            if (ModelState.IsValid)
            {
                db.CFBGasCompressions.Add(cFBGasCompression);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBGasCompression);
        }

        // GET: CFBGasCompressions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBGasCompression cFBGasCompression = db.CFBGasCompressions.Find(id);
            if (cFBGasCompression == null)
            {
                return HttpNotFound();
            }
            return View(cFBGasCompression);
        }

        // POST: CFBGasCompressions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Compressor,SuctionPressure,DischargePressure,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBGasCompression cFBGasCompression)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBGasCompression).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBGasCompression);
        }

        // GET: CFBGasCompressions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBGasCompression cFBGasCompression = db.CFBGasCompressions.Find(id);
            if (cFBGasCompression == null)
            {
                return HttpNotFound();
            }
            return View(cFBGasCompression);
        }

        // POST: CFBGasCompressions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBGasCompression cFBGasCompression = db.CFBGasCompressions.Find(id);
            db.CFBGasCompressions.Remove(cFBGasCompression);
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
