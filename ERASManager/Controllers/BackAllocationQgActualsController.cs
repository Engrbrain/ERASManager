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
    public class BackAllocationQgActualsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackAllocationQgActuals
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationQgActuals" });

            }
            else
            {
                List<BackAllocationQgActual> backAllocationQgActual = new List<BackAllocationQgActual>();

                backAllocationQgActual = db.Database.SqlQuery<BackAllocationQgActual>(
            "exec dbo.[usp_GetBackAllocationQgActual] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationQgActual);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationQgActual> backAllocationQgActual = new List<BackAllocationQgActual>();

            backAllocationQgActual = db.Database.SqlQuery<BackAllocationQgActual>(
        "exec dbo.[usp_GetBackAllocationQgActual] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationQgActual);
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
