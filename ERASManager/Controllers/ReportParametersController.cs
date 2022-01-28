using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERASManager.Models;

namespace ERASManager.Controllers
{
    public class ReportParametersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReportParameters
        public ActionResult Index(string ReportBearer)
        {
            Session["ReportBearer"] = ReportBearer;
            ViewBag.Bearer = ReportBearer;
            return View("ReportFilter");
        }

        // GET: ReportParameters/Details/5

        // GET: ReportParameters/Create
        public ActionResult ReportFilter()
        {
            return View();
        }

        // POST: ReportParameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportFilter([Bind(Include = "Id,StartDate,EndDate")] ReportParameter reportParameter)
        {
            if (ModelState.IsValid)
            {
                string ReportBearer = (string)Session["ReportBearer"];
                ViewBag.Bearer = ReportBearer;
                return RedirectToAction("Index",ReportBearer, new { StartDate = reportParameter.StartDate, EndDate = reportParameter.EndDate });
            }

            return View(reportParameter);
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
