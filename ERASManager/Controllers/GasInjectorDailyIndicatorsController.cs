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
    public class GasInjectorDailyIndicatorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GasInjectorDailyIndicators
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "GasInjectorDailyIndicators" });

            }
            else
            {
                var gasInjectorDailyIndicators = db.GasInjectorDailyIndicators.Where(x => x.IndicatorDate >= StartDate && x.IndicatorDate <= EndDate);
                return View(gasInjectorDailyIndicators.ToList());
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            var gasInjectorDailyIndicators = db.GasInjectorDailyIndicators.Where(x => x.IndicatorDate >= StartDate && x.IndicatorDate <= EndDate);
            return View("Index", gasInjectorDailyIndicators);
        }

        // GET: GasInjectorDailyIndicators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasInjectorDailyIndicators gasInjectorDailyIndicators = db.GasInjectorDailyIndicators.Find(id);
            if (gasInjectorDailyIndicators == null)
            {
                return HttpNotFound();
            }
            return View(gasInjectorDailyIndicators);
        }

        // GET: GasInjectorDailyIndicators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GasInjectorDailyIndicators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IndicatorDate,ChokeSize,Uptime,Well,CompDischPress,GasInject,IFLP,IFLSkinTemp,ITHP,IBHP,IBHT,Remark,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] GasInjectorDailyIndicators gasInjectorDailyIndicators)
        {
            if (ModelState.IsValid)
            {
                db.GasInjectorDailyIndicators.Add(gasInjectorDailyIndicators);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gasInjectorDailyIndicators);
        }

        // GET: GasInjectorDailyIndicators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasInjectorDailyIndicators gasInjectorDailyIndicators = db.GasInjectorDailyIndicators.Find(id);
            if (gasInjectorDailyIndicators == null)
            {
                return HttpNotFound();
            }
            return View(gasInjectorDailyIndicators);
        }

        // POST: GasInjectorDailyIndicators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IndicatorDate,ChokeSize,Uptime,Well,CompDischPress,GasInject,IFLP,IFLSkinTemp,ITHP,IBHP,IBHT,Remark,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] GasInjectorDailyIndicators gasInjectorDailyIndicators)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasInjectorDailyIndicators).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gasInjectorDailyIndicators);
        }

        // GET: GasInjectorDailyIndicators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasInjectorDailyIndicators gasInjectorDailyIndicators = db.GasInjectorDailyIndicators.Find(id);
            if (gasInjectorDailyIndicators == null)
            {
                return HttpNotFound();
            }
            return View(gasInjectorDailyIndicators);
        }

        // POST: GasInjectorDailyIndicators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GasInjectorDailyIndicators gasInjectorDailyIndicators = db.GasInjectorDailyIndicators.Find(id);
            db.GasInjectorDailyIndicators.Remove(gasInjectorDailyIndicators);
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
