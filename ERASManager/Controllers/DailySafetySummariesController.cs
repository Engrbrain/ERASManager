using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using ERASManager.Models;
using ERASManager.Models.EBOKDailyReport;
using Newtonsoft.Json;

namespace ERASManager.Controllers
{
    public class DailySafetySummariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DailySafetySummaries
        public ActionResult Index()
        {
            var dailySafetySummary = db.DailySafetySummaries.Where(x => x.ReportDate == DateTime.Today.Date);
            return View(dailySafetySummary.ToList());
        }
        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            var dailySafetySummary = db.DailySafetySummaries.Where(x => x.ReportDate >= StartDate && x.ReportDate <= EndDate);
            return View("Index", dailySafetySummary);
        }
        public ActionResult LoadPrevious()
        {
            List<DailySafetySummary> dailySafetySummary = new List<DailySafetySummary>();

            dailySafetySummary = db.Database.SqlQuery<DailySafetySummary>(
        "usp_GetDailySafetySummary"
        ).ToList();
            return View("Index", dailySafetySummary);
        }

        public ActionResult CreateMultipleBulk()
        {
            return View();
        }

        [WebMethod]
        public string LoadBulkData(string mydata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<DailySafetySummary>>(mydata);
            foreach (var data in serializeData)
            {
                DailySafetySummary postdata = new DailySafetySummary
                {
                    SafetyReport = data.SafetyReport,
                    ReportDate = data.ReportDate,
                    TimeStamp = DateTime.Now,
                    UploadTime = DateTime.Now.TimeOfDay.ToString()
                };
                db.DailySafetySummaries.Add(postdata);
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
            DailySafetySummary dailySafetySummary = db.DailySafetySummaries.Find(id);
            if (dailySafetySummary == null)
            {
                return HttpNotFound();
            }
            return View(dailySafetySummary);
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
        public ActionResult Create([Bind(Include = "Id,SafetyReport,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] DailySafetySummary dailySafetySummary)
        {
            if (ModelState.IsValid)
            {
                dailySafetySummary.DayOftheWeek = DateTime.Today.Date.DayOfWeek.ToString();
                dailySafetySummary.TimeStamp = DateTime.Now;
                dailySafetySummary.UploadTime = DateTime.Now.TimeOfDay.ToString();
                db.DailySafetySummaries.Add(dailySafetySummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dailySafetySummary);
        }

        // GET: DailySafetySummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailySafetySummary dailySafetySummary = db.DailySafetySummaries.Find(id);
            if (dailySafetySummary == null)
            {
                return HttpNotFound();
            }
            return View(dailySafetySummary);
        }

        // POST: DailySafetySummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SafetyReport,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] DailySafetySummary dailySafetySummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailySafetySummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dailySafetySummary);
        }

      
        public ActionResult RemoveRecord(int id)
        {
            try
            {
                DailySafetySummary dailySafetySummary = db.DailySafetySummaries.Find(id);
                db.DailySafetySummaries.Remove(dailySafetySummary);
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
