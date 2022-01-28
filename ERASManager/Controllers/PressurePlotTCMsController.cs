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
    public class PressurePlotTCMsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PressurePlotTCMs
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "PressurePlotTCMs" });

            }
            else
            {
                List<PressurePlotTCM> pressurePlotTCM = new List<PressurePlotTCM>();

                pressurePlotTCM = db.Database.SqlQuery<PressurePlotTCM>(
            "exec dbo.[usp_GetPressurePlotTCM] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", StartDate)
            ).ToList();
                return View(pressurePlotTCM);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<PressurePlotTCM> pressurePlotTCM = new List<PressurePlotTCM>();

            pressurePlotTCM = db.Database.SqlQuery<PressurePlotTCM>(
        "exec dbo.[usp_GetPressurePlotTCM] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", StartDate)
        ).ToList();
            return View("Index", pressurePlotTCM);
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

