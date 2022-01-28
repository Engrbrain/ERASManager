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
    public class ProducedWaterDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProducedWaterDatas
        public ActionResult Index()
        {
            return View(db.ProducedWaterData.ToList());
        }

        // GET: ProducedWaterDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducedWaterData producedWaterData = db.ProducedWaterData.Find(id);
            if (producedWaterData == null)
            {
                return HttpNotFound();
            }
            return View(producedWaterData);
        }

        // GET: ProducedWaterDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducedWaterDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Parameters,TwentyFourHourReading,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] ProducedWaterData producedWaterData)
        {
            if (ModelState.IsValid)
            {
                db.ProducedWaterData.Add(producedWaterData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producedWaterData);
        }

        // GET: ProducedWaterDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducedWaterData producedWaterData = db.ProducedWaterData.Find(id);
            if (producedWaterData == null)
            {
                return HttpNotFound();
            }
            return View(producedWaterData);
        }

        // POST: ProducedWaterDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Parameters,TwentyFourHourReading,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] ProducedWaterData producedWaterData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producedWaterData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producedWaterData);
        }

        // GET: ProducedWaterDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducedWaterData producedWaterData = db.ProducedWaterData.Find(id);
            if (producedWaterData == null)
            {
                return HttpNotFound();
            }
            return View(producedWaterData);
        }

        // POST: ProducedWaterDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProducedWaterData producedWaterData = db.ProducedWaterData.Find(id);
            db.ProducedWaterData.Remove(producedWaterData);
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
