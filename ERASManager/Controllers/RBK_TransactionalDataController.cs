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
using ERASManager.Models.RevisedBackAllocation;

namespace ERASManager.Controllers
{
    public class RBK_TransactionalDataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RBK_TransactionalData
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "RBK_TransactionalData" });

            }
            else
            {
                List<RBK_TransactionalData> rBK_TransactionalData = new List<RBK_TransactionalData>();

                rBK_TransactionalData = db.Database.SqlQuery<RBK_TransactionalData>(
            "exec dbo.[usp_GetRBK_TransactionalData] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(rBK_TransactionalData);
            }
        }


        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<RBK_TransactionalData> rBK_TransactionalData = new List<RBK_TransactionalData>();

            rBK_TransactionalData = db.Database.SqlQuery<RBK_TransactionalData>(
        "exec dbo.[usp_GetRBK_TransactionalData] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", rBK_TransactionalData);
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
