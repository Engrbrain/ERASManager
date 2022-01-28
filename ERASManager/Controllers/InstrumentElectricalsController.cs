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
    public class InstrumentElectricalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InstrumentElectricals
        public ActionResult Index()
        {
            return View(db.InstrumentElectricals.ToList());
        }

        // GET: InstrumentElectricals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstrumentElectrical instrumentElectrical = db.InstrumentElectricals.Find(id);
            if (instrumentElectrical == null)
            {
                return HttpNotFound();
            }
            return View(instrumentElectrical);
        }

        // GET: InstrumentElectricals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstrumentElectricals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] InstrumentElectrical instrumentElectrical)
        {
            if (ModelState.IsValid)
            {
                db.InstrumentElectricals.Add(instrumentElectrical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrumentElectrical);
        }

        // GET: InstrumentElectricals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstrumentElectrical instrumentElectrical = db.InstrumentElectricals.Find(id);
            if (instrumentElectrical == null)
            {
                return HttpNotFound();
            }
            return View(instrumentElectrical);
        }

        // POST: InstrumentElectricals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] InstrumentElectrical instrumentElectrical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instrumentElectrical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instrumentElectrical);
        }

        // GET: InstrumentElectricals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstrumentElectrical instrumentElectrical = db.InstrumentElectricals.Find(id);
            if (instrumentElectrical == null)
            {
                return HttpNotFound();
            }
            return View(instrumentElectrical);
        }

        // POST: InstrumentElectricals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InstrumentElectrical instrumentElectrical = db.InstrumentElectricals.Find(id);
            db.InstrumentElectricals.Remove(instrumentElectrical);
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
