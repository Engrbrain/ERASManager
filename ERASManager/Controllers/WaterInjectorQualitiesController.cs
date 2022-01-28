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
    public class WaterInjectorQualitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WaterInjectorQualities
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "WaterInjectorQualities" });

            }
            else
            {
                var waterInjectorQuality = db.WaterInjectorQuality.Where(x => x.IndicatorDate >= StartDate && x.IndicatorDate <= EndDate);
                return View(waterInjectorQuality.ToList());
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            var waterInjectorQuality = db.WaterInjectorQuality.Where(x => x.IndicatorDate >= StartDate && x.IndicatorDate <= EndDate);
            return View("Index", waterInjectorQuality);
        }

        // GET: WaterInjectorQualities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterInjectorQuality waterInjectorQuality = db.WaterInjectorQuality.Find(id);
            if (waterInjectorQuality == null)
            {
                return HttpNotFound();
            }
            return View(waterInjectorQuality);
        }

        // GET: WaterInjectorQualities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaterInjectorQualities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IndicatorDate,SWLPumpInlet,PH,ParticlesUpstream,ParticlesDownStream,Remark,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WaterInjectorQuality waterInjectorQuality)
        {
            if (ModelState.IsValid)
            {
                db.WaterInjectorQuality.Add(waterInjectorQuality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waterInjectorQuality);
        }

        // GET: WaterInjectorQualities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterInjectorQuality waterInjectorQuality = db.WaterInjectorQuality.Find(id);
            if (waterInjectorQuality == null)
            {
                return HttpNotFound();
            }
            return View(waterInjectorQuality);
        }

        // POST: WaterInjectorQualities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IndicatorDate,SWLPumpInlet,PH,ParticlesUpstream,ParticlesDownStream,Remark,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WaterInjectorQuality waterInjectorQuality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterInjectorQuality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterInjectorQuality);
        }

        // GET: WaterInjectorQualities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterInjectorQuality waterInjectorQuality = db.WaterInjectorQuality.Find(id);
            if (waterInjectorQuality == null)
            {
                return HttpNotFound();
            }
            return View(waterInjectorQuality);
        }

        // POST: WaterInjectorQualities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WaterInjectorQuality waterInjectorQuality = db.WaterInjectorQuality.Find(id);
            db.WaterInjectorQuality.Remove(waterInjectorQuality);
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
