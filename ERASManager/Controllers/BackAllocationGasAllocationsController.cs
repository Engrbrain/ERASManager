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
    public class BackAllocationGasAllocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationGasAllocations" });

            }
            else
            {
                List<BackAllocationGasAllocation> backAllocationGasAllocation = new List<BackAllocationGasAllocation>();

                backAllocationGasAllocation = db.Database.SqlQuery<BackAllocationGasAllocation>(
            "exec dbo.[usp_GetBackAllocationGasAllocation] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationGasAllocation);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationGasAllocation> backAllocationGasAllocation = new List<BackAllocationGasAllocation>();

            backAllocationGasAllocation = db.Database.SqlQuery<BackAllocationGasAllocation>(
        "exec dbo.[usp_GetBackAllocationGasAllocation] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationGasAllocation);
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
