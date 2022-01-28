using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERASManager.Models;
using ERASManager.Models.EBOKTranformedData;
using System.Data.SqlClient;
using System.Web.Services;
using Newtonsoft.Json;

namespace ERASManager.Controllers
{
    public class BackAllocationBPLDsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackAllocationBPLDs
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationBPLDs" });

            }
            else
            {
                List<BackAllocationBPLD> backAllocationBPLD = new List<BackAllocationBPLD>();

                backAllocationBPLD = db.Database.SqlQuery<BackAllocationBPLD>(
            "exec dbo.[usp_GetBackAllocationBPLD] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(backAllocationBPLD);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationBPLD> backAllocationBPLD = new List<BackAllocationBPLD>();

            backAllocationBPLD = db.Database.SqlQuery<BackAllocationBPLD>(
        "exec dbo.[usp_GetBackAllocationBPLD] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationBPLD);
        }

        public ActionResult LoadPrevious()
        {
            List<BackAllocationBPLD> backAllocationBPLD = new List<BackAllocationBPLD>();

            backAllocationBPLD = db.Database.SqlQuery<BackAllocationBPLD>(
        "usp_GetBackAllocationBPLDPrevious"
        ).ToList();
            return View("Index", backAllocationBPLD);
        }

        public ActionResult CreateMultipleBulk()
        {
            return View();
        }

        [WebMethod]
        public string LoadBulkData(string mydata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<BackAllocationBPLD>>(mydata);
            foreach (var data in serializeData)
            {
                BackAllocationBPLD postdata = new BackAllocationBPLD
                {
                    IndicatorDate = data.IndicatorDate,
                    Well = data.Well,
                    BPLD = data.BPLD,
                    ReportDate = data.ReportDate,
                    TimeStamp = DateTime.Now,
                    UploadTime = DateTime.Now.TimeOfDay.ToString()
                };
                db.BackAllocationBPLD.Add(postdata);
            }
            db.SaveChanges();
            return null;
        }

        // GET: DailySafetySummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackAllocationBPLD backAllocationBPLD = db.BackAllocationBPLD.Find(id);
            if (backAllocationBPLD == null)
            {
                return HttpNotFound();
            }
            return View(backAllocationBPLD);
        }

        // GET: DailySafetySummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DailySafetySummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Well,IndicatorDate,AssumedGOR,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] BackAllocationBPLD backAllocationBPLD)
        {
            if (ModelState.IsValid)
            {
                backAllocationBPLD.DayOftheWeek = DateTime.Today.Date.DayOfWeek.ToString();
                backAllocationBPLD.TimeStamp = DateTime.Now;
                backAllocationBPLD.UploadTime = DateTime.Now.TimeOfDay.ToString();
                db.BackAllocationBPLD.Add(backAllocationBPLD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(backAllocationBPLD);
        }

        // GET: DailySafetySummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackAllocationBPLD backAllocationBPLD = db.BackAllocationBPLD.Find(id);
            if (backAllocationBPLD == null)
            {
                return HttpNotFound();
            }
            return View(backAllocationBPLD);
        }

        // POST: DailySafetySummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Well,IndicatorDate,AssumedGOR,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] BackAllocationBPLD backAllocationBPLD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backAllocationBPLD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(backAllocationBPLD);
        }


        public ActionResult RemoveRecord(int id)
        {
            try
            {
                BackAllocationBPLD backAllocationBPLD = db.BackAllocationBPLD.Find(id);
                db.BackAllocationBPLD.Remove(backAllocationBPLD);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
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