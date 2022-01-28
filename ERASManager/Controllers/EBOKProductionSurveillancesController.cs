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
    public class EBOKProductionSurveillancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EBOKProductionSurveillances
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "EBOKProductionSurveillances" });
            }
            else
            {
                List<EBOKProductionSurveillance> eBOKProductionSurveillance = new List<EBOKProductionSurveillance>();

                eBOKProductionSurveillance = db.Database.SqlQuery<EBOKProductionSurveillance>(
            "exec dbo.[usp_GetEBOKProductionSurveillance] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(eBOKProductionSurveillance);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<EBOKProductionSurveillance> eBOKProductionSurveillance = new List<EBOKProductionSurveillance>();

            eBOKProductionSurveillance = db.Database.SqlQuery<EBOKProductionSurveillance>(
        "exec dbo.[usp_GetEBOKProductionSurveillance] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", eBOKProductionSurveillance);
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


