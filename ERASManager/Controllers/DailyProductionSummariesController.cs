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
    public class DailyProductionSummariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DailyProductionSummaries
        public ActionResult Index()
        {
            return View(db.DailyProductionSummaries.ToList());
        }

        // GET: DailyProductionSummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyProductionSummary dailyProductionSummary = db.DailyProductionSummaries.Find(id);
            if (dailyProductionSummary == null)
            {
                return HttpNotFound();
            }
            return View(dailyProductionSummary);
        }

        // GET: DailyProductionSummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DailyProductionSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ReportParameter,MopuMeter,WaterInjection,Oilinventory,GasProduced,GasUtilized,GasFlared,ProducedWater,WfbUptime,MopuUptime,WaterInjectionUptime,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] DailyProductionSummary dailyProductionSummary)
        {
            if (ModelState.IsValid)
            {
                db.DailyProductionSummaries.Add(dailyProductionSummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dailyProductionSummary);
        }

        // GET: DailyProductionSummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyProductionSummary dailyProductionSummary = db.DailyProductionSummaries.Find(id);
            if (dailyProductionSummary == null)
            {
                return HttpNotFound();
            }
            return View(dailyProductionSummary);
        }

        // POST: DailyProductionSummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ReportParameter,MopuMeter,WaterInjection,Oilinventory,GasProduced,GasUtilized,GasFlared,ProducedWater,WfbUptime,MopuUptime,WaterInjectionUptime,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] DailyProductionSummary dailyProductionSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyProductionSummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dailyProductionSummary);
        }

        // GET: DailyProductionSummaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyProductionSummary dailyProductionSummary = db.DailyProductionSummaries.Find(id);
            if (dailyProductionSummary == null)
            {
                return HttpNotFound();
            }
            return View(dailyProductionSummary);
        }

        // POST: DailyProductionSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyProductionSummary dailyProductionSummary = db.DailyProductionSummaries.Find(id);
            db.DailyProductionSummaries.Remove(dailyProductionSummary);
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
