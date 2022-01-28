using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using ERASManager.Models;
using ERASManager.Models.EBOKTranformedData;
using Newtonsoft.Json;

namespace ERASManager.Controllers
{
    public class BackAllocationAssumedGORsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackAllocationAssumedGORs
        public ActionResult Index( DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "BackAllocationAssumedGORs" });


            }
            else { 
            List<BackAllocationAssumedGOR> backAllocationAssumedGOR = new List<BackAllocationAssumedGOR>();

            backAllocationAssumedGOR = db.Database.SqlQuery<BackAllocationAssumedGOR>(
        "exec dbo.[usp_GetBackAllocationAssumedGOR] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View(backAllocationAssumedGOR);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<BackAllocationAssumedGOR> backAllocationAssumedGOR = new List<BackAllocationAssumedGOR>();

            backAllocationAssumedGOR = db.Database.SqlQuery<BackAllocationAssumedGOR>(
        "exec dbo.[usp_GetBackAllocationAssumedGOR] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", backAllocationAssumedGOR);
        }

        public ActionResult LoadPrevious()
        {
            List<BackAllocationAssumedGOR> backAllocationAssumedGOR = new List<BackAllocationAssumedGOR>();

            backAllocationAssumedGOR = db.Database.SqlQuery<BackAllocationAssumedGOR>(
        "usp_GetBackAllocationAssumedGORPrevious"
        ).ToList();
            return View("Index", backAllocationAssumedGOR);
        }

        public ActionResult CreateMultipleBulk()
        {
            return View();
        }

        [WebMethod]
        public string LoadBulkData(string mydata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<BackAllocationAssumedGOR>>(mydata);
            foreach (var data in serializeData)
            {
                BackAllocationAssumedGOR postdata = new BackAllocationAssumedGOR
                {
                    IndicatorDate = data.IndicatorDate,
                    Well = data.Well,
                    AssumedGOR = data.AssumedGOR,
                    ReportDate = data.ReportDate,
                    TimeStamp = DateTime.Now,
                    UploadTime = DateTime.Now.TimeOfDay.ToString()
                };
                db.BackAllocationAssumedGOR.Add(postdata);
            }
            db.SaveChanges();
            return null;
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
        public ActionResult Create([Bind(Include = "Id,Well,IndicatorDate,AssumedGOR,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] BackAllocationAssumedGOR backAllocationAssumedGOR)
        {
            if (ModelState.IsValid)
            {
                backAllocationAssumedGOR.DayOftheWeek = DateTime.Today.Date.DayOfWeek.ToString();
                backAllocationAssumedGOR.TimeStamp = DateTime.Now;
                backAllocationAssumedGOR.UploadTime = DateTime.Now.TimeOfDay.ToString();
                db.BackAllocationAssumedGOR.Add(backAllocationAssumedGOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(backAllocationAssumedGOR);
        }

        // GET: DailySafetySummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackAllocationAssumedGOR backAllocationAssumedGOR = db.BackAllocationAssumedGOR.Find(id);
            if (backAllocationAssumedGOR == null)
            {
                return HttpNotFound();
            }
            return View(backAllocationAssumedGOR);
        }

        // POST: DailySafetySummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Well,IndicatorDate,AssumedGOR,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] BackAllocationAssumedGOR backAllocationAssumedGOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backAllocationAssumedGOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(backAllocationAssumedGOR);
        }


        public ActionResult RemoveRecord(int id)
        {
            try
            {
                BackAllocationAssumedGOR backAllocationAssumedGOR = db.BackAllocationAssumedGOR.Find(id);
                db.BackAllocationAssumedGOR.Remove(backAllocationAssumedGOR);
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
