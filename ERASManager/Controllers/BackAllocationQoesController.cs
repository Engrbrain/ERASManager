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
    public class BackAllocationQoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackAllocationQoes
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationQoes" });

            }
            else
            {
                List<BackAllocationQo> backAllocationActualGORHeader = new List<BackAllocationQo>();

                backAllocationActualGORHeader = db.Database.SqlQuery<BackAllocationQo>(
            "exec dbo.[usp_GetBackAllocationQo] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationActualGORHeader);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationQo> backAllocationActualGORHeader = new List<BackAllocationQo>();

            backAllocationActualGORHeader = db.Database.SqlQuery<BackAllocationQo>(
        "exec dbo.[usp_GetBackAllocationQo] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationActualGORHeader);
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

