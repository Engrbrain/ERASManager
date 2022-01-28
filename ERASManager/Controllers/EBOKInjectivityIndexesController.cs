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
    public class EBOKInjectivityIndexesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EBOKInjectivityIndexes
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "EBOKInjectivityIndexes" });
            }
            else
            {
                List< EBOKInjectivityIndex> eBOKInjectivityIndex = new List< EBOKInjectivityIndex>();

                eBOKInjectivityIndex = db.Database.SqlQuery< EBOKInjectivityIndex>(
            "exec dbo.[usp_GetEBOKInjectivityIndex] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(eBOKInjectivityIndex);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List< EBOKInjectivityIndex> eBOKInjectivityIndex = new List< EBOKInjectivityIndex>();

            eBOKInjectivityIndex = db.Database.SqlQuery< EBOKInjectivityIndex>(
        "exec dbo.[usp_Get EBOKInjectivityIndex] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", eBOKInjectivityIndex);
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


