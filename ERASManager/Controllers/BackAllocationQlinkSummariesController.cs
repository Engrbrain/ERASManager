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
    public class BackAllocationQlinkSummariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackAllocationQlinkSummaries
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationQlinkSummaries" });

            }
            else
            {
                List<BackAllocationQlinkSummary> backAllocationQlinkSummary = new List<BackAllocationQlinkSummary>();

                backAllocationQlinkSummary = db.Database.SqlQuery<BackAllocationQlinkSummary>(
            "exec dbo.[usp_GetBackAllocationQlinkSummary] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationQlinkSummary);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationQlinkSummary> backAllocationQlinkSummary = new List<BackAllocationQlinkSummary>();

            backAllocationQlinkSummary = db.Database.SqlQuery<BackAllocationQlinkSummary>(
        "exec dbo.[usp_GetBackAllocationQlinkSummary] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationQlinkSummary);
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
