using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERASManager.Models;
using ERASManager.Models.EBOKTranformedData;

namespace ERASManager.Controllers
{
    public class WaterInjectorRateLineItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WaterInjectorRateLineItems
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "WaterInjectorRateLineItems" });

            }
            else
            {
                var waterInjectorRateLineItem = db.WaterInjectorRateLineItem.Where(x => x.IndicatorDate >= StartDate && x.IndicatorDate <= EndDate);
                return View(waterInjectorRateLineItem.ToList());
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            var waterInjectorRateLineItem = db.WaterInjectorRateLineItem.Where(x => x.IndicatorDate >= StartDate && x.IndicatorDate <= EndDate);
            return View("Index", waterInjectorRateLineItem);
        }


        // GET: WaterInjectorRateLineItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterInjectorRateLineItem waterInjectorRateLineItem = db.WaterInjectorRateLineItem.Find(id);
            if (waterInjectorRateLineItem == null)
            {
                return HttpNotFound();
            }
            return View(waterInjectorRateLineItem);
        }

        // GET: WaterInjectorRateLineItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaterInjectorRateLineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Well,IndicatorDate,ChokeSize,UpTime,THIP,FLP,HP,INJRate,CumINJRate,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WaterInjectorRateLineItem waterInjectorRateLineItem)
        {
            if (ModelState.IsValid)
            {
                db.WaterInjectorRateLineItem.Add(waterInjectorRateLineItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waterInjectorRateLineItem);
        }

        // GET: WaterInjectorRateLineItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterInjectorRateLineItem waterInjectorRateLineItem = db.WaterInjectorRateLineItem.Find(id);
            if (waterInjectorRateLineItem == null)
            {
                return HttpNotFound();
            }
            return View(waterInjectorRateLineItem);
        }

        // POST: WaterInjectorRateLineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Well,IndicatorDate,ChokeSize,UpTime,THIP,FLP,HP,INJRate,CumINJRate,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WaterInjectorRateLineItem waterInjectorRateLineItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterInjectorRateLineItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterInjectorRateLineItem);
        }

        // GET: WaterInjectorRateLineItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterInjectorRateLineItem waterInjectorRateLineItem = db.WaterInjectorRateLineItem.Find(id);
            if (waterInjectorRateLineItem == null)
            {
                return HttpNotFound();
            }
            return View(waterInjectorRateLineItem);
        }

        // POST: WaterInjectorRateLineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WaterInjectorRateLineItem waterInjectorRateLineItem = db.WaterInjectorRateLineItem.Find(id);
            db.WaterInjectorRateLineItem.Remove(waterInjectorRateLineItem);
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
