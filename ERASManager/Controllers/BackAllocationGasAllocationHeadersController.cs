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
    public class BackAllocationGasAllocationHeadersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackAllocationGasAllocationHeaders
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationGasAllocationHeaders" });

            }
            else
            {
                List<BackAllocationGasAllocationHeader> backAllocationGasAllocationHeader = new List<BackAllocationGasAllocationHeader>();

                backAllocationGasAllocationHeader = db.Database.SqlQuery<BackAllocationGasAllocationHeader>(
            "exec dbo.[usp_GetBackAllocationGasAllocationHeader] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationGasAllocationHeader);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationGasAllocationHeader> backAllocationGasAllocationHeader = new List<BackAllocationGasAllocationHeader>();

            backAllocationGasAllocationHeader = db.Database.SqlQuery<BackAllocationGasAllocationHeader>(
        "exec dbo.[usp_GetBackAllocationGasAllocationHeader] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationGasAllocationHeader);
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

