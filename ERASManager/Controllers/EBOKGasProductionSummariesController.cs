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
    public class EBOKGasProductionSummariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EBOKGasProductionSummaries
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");

                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "EBOKGasProductionSummaries" });
            }
            else
            {
                var eBOKGasProductionSummary = db.EBOKGasProductionSummary.Where(x => x.IndicatorDate >= StartDate && x.IndicatorDate <= EndDate);
                return View(eBOKGasProductionSummary.ToList());
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            var eBOKGasProductionSummary = db.EBOKGasProductionSummary.Where(x => x.IndicatorDate >= StartDate && x.IndicatorDate <= EndDate);
            return View("Index", eBOKGasProductionSummary);
        }

        // GET: EBOKGasProductionSummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EBOKGasProductionSummary eBOKGasProductionSummary = db.EBOKGasProductionSummary.Find(id);
            if (eBOKGasProductionSummary == null)
            {
                return HttpNotFound();
            }
            return View(eBOKGasProductionSummary);
        }

        // GET: EBOKGasProductionSummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EBOKGasProductionSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IndicatorDate,TwoPhaseSeperator,TestSeperator,ProductionSeperator,LPVessels,WFBAllocatedgas,WFBProcessUptime,WFBFlaringUptime,WFBContribution,WFBPROCESSTOTAL,WFBGasLift,CFBGasLift,TOTALGasLift,GeneratorFuel,FuelGasKOD,GTCompressorconsumption,CalcuatedInjectedGas,MeteredGasInjected,GASUtilizationTotal,HPFLARE,LPFLARE,WFBGasFlared,TotalMeteredGasFlared,GASFLAREDTOTAL,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] EBOKGasProductionSummary eBOKGasProductionSummary)
        {
            if (ModelState.IsValid)
            {
                db.EBOKGasProductionSummary.Add(eBOKGasProductionSummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eBOKGasProductionSummary);
        }

        // GET: EBOKGasProductionSummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EBOKGasProductionSummary eBOKGasProductionSummary = db.EBOKGasProductionSummary.Find(id);
            if (eBOKGasProductionSummary == null)
            {
                return HttpNotFound();
            }
            return View(eBOKGasProductionSummary);
        }

        // POST: EBOKGasProductionSummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IndicatorDate,TwoPhaseSeperator,TestSeperator,ProductionSeperator,LPVessels,WFBAllocatedgas,WFBProcessUptime,WFBFlaringUptime,WFBContribution,WFBPROCESSTOTAL,WFBGasLift,CFBGasLift,TOTALGasLift,GeneratorFuel,FuelGasKOD,GTCompressorconsumption,CalcuatedInjectedGas,MeteredGasInjected,GASUtilizationTotal,HPFLARE,LPFLARE,WFBGasFlared,TotalMeteredGasFlared,GASFLAREDTOTAL,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] EBOKGasProductionSummary eBOKGasProductionSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eBOKGasProductionSummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eBOKGasProductionSummary);
        }

        // GET: EBOKGasProductionSummaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EBOKGasProductionSummary eBOKGasProductionSummary = db.EBOKGasProductionSummary.Find(id);
            if (eBOKGasProductionSummary == null)
            {
                return HttpNotFound();
            }
            return View(eBOKGasProductionSummary);
        }

        // POST: EBOKGasProductionSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EBOKGasProductionSummary eBOKGasProductionSummary = db.EBOKGasProductionSummary.Find(id);
            db.EBOKGasProductionSummary.Remove(eBOKGasProductionSummary);
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
