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
    public class EBOKHallPlotDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EBOKHallPlotDatas
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "EBOKHallPlotDatas" });
            }
            else
            {
                List<EBOKHallPlotData> EBOKHallPlotData = new List<EBOKHallPlotData>();

                EBOKHallPlotData = db.Database.SqlQuery<EBOKHallPlotData>(
            "exec dbo.[usp_GetEBOKHallPlotData] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(EBOKHallPlotData);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<EBOKHallPlotData> EBOKHallPlotData = new List<EBOKHallPlotData>();

            EBOKHallPlotData = db.Database.SqlQuery<EBOKHallPlotData>(
        "exec dbo.[usp_GetEBOKHallPlotData] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", EBOKHallPlotData);
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

