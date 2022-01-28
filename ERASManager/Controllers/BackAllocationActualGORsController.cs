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
    public class BackAllocationActualGORsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackAllocationActualGORs
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationActualGORs" });

            }
            else
            {
                List<BackAllocationActualGORHeader> backAllocationActualGORHeader = new List<BackAllocationActualGORHeader>();

                backAllocationActualGORHeader = db.Database.SqlQuery<BackAllocationActualGORHeader>(
            "exec dbo.[usp_GetBackAllocationActualGORHeader] @StartDate,@EndDate",
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
            List<BackAllocationActualGORHeader> backAllocationActualGORHeader = new List<BackAllocationActualGORHeader>();

            backAllocationActualGORHeader = db.Database.SqlQuery<BackAllocationActualGORHeader>(
        "exec dbo.[usp_GetBackAllocationActualGORHeader] @StartDate,@EndDate",
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
