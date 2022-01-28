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
    public class BackAllocationFlowHRSController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackAllocationFlowHRS
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationFlowHRS" });

            }
            else
            {
                List<BackAllocationFlowHRS> backAllocationFlowHRS = new List<BackAllocationFlowHRS>();

                backAllocationFlowHRS = db.Database.SqlQuery<BackAllocationFlowHRS>(
            "exec dbo.[usp_GetBackAllocationFlowHRS] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationFlowHRS);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationFlowHRS> backAllocationFlowHRS = new List<BackAllocationFlowHRS>();

            backAllocationFlowHRS = db.Database.SqlQuery<BackAllocationFlowHRS>(
        "exec dbo.[usp_GetBackAllocationFlowHRS] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationFlowHRS);
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

