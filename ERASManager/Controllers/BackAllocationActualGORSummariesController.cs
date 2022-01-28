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
    public class BackAllocationActualGORSummariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackAllocationActualGORSummaries
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationActualGORSummaries" });

            }
            else
            {
                List<BackAllocationActualGORSummary> backAllocationActualGORSummary = new List<BackAllocationActualGORSummary>();

                backAllocationActualGORSummary = db.Database.SqlQuery<BackAllocationActualGORSummary>(
            "exec dbo.[usp_GetBackAllocationActualGORSummary] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationActualGORSummary);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationActualGORSummary> backAllocationActualGORSummary = new List<BackAllocationActualGORSummary>();

            backAllocationActualGORSummary = db.Database.SqlQuery<BackAllocationActualGORSummary>(
        "exec dbo.[usp_GetBackAllocationActualGORSummary] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationActualGORSummary);
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
