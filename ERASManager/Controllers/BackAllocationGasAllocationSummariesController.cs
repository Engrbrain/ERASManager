using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERASManager.Models;
using ERASManager.Models.EBOKOutputData;

namespace ERASManager.Controllers
{
    public class BackAllocationGasAllocationSummariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationGasAllocationSummaries" });

            }
            else
            {
                List<BackAllocationGasAllocationSummary> backAllocationGasAllocationSummary = new List<BackAllocationGasAllocationSummary>();

                backAllocationGasAllocationSummary = db.Database.SqlQuery<BackAllocationGasAllocationSummary>(
            "exec dbo.[usp_GetBackAllocationGasAllocationSummary] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationGasAllocationSummary);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationGasAllocationSummary> backAllocationGasAllocationSummary = new List<BackAllocationGasAllocationSummary>();

            backAllocationGasAllocationSummary = db.Database.SqlQuery<BackAllocationGasAllocationSummary>(
        "exec dbo.[usp_GetBackAllocationGasAllocationSummary] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationGasAllocationSummary);
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
