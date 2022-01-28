using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERASManager.Models;
using ERASManager.Models.EBOKOutputData;
using System.Data.SqlClient;

namespace ERASManager.Controllers
{
    public class BackAllocationQgPotentialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationQgPotentials" });

            }
            else
            {
                List<BackAllocationQgPotential> backAllocationQgPotential = new List<BackAllocationQgPotential>();

                backAllocationQgPotential = db.Database.SqlQuery<BackAllocationQgPotential>(
            "exec dbo.[usp_GetBackAllocationQgPotential] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationQgPotential);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationQgPotential> backAllocationQgPotential = new List<BackAllocationQgPotential>();

            backAllocationQgPotential = db.Database.SqlQuery<BackAllocationQgPotential>(
        "exec dbo.[usp_GetBackAllocationQgPotential] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationQgPotential);
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

