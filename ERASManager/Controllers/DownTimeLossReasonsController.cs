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
    public class DownTimeLossReasonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DownTimeLossReasons
        public ActionResult Index()
        {
            var downTimeLossReasons = db.DownTimeLossReasons.Where(x => x.ReportDate == DateTime.Today.Date);
            return View(downTimeLossReasons.ToList());
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            var downTimeLossReasons = db.DownTimeLossReasons.Where(x => x.ReportDate >= StartDate && x.ReportDate <= EndDate);
            return View("Index", downTimeLossReasons);
        }
        public ActionResult LoadPrevious()
        {
            List<DownTimeLossReason> downTimeLossReason = new List<DownTimeLossReason>();

            downTimeLossReason = db.Database.SqlQuery<DownTimeLossReason>(
        "usp_GetDownTimeLossReason"
        ).ToList();
            return View("Index", downTimeLossReason);
        }

        public ActionResult CreateMultipleBulk()
        {
            return View();
        }

        [WebMethod]
        public string LoadBulkData(string mydata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<DownTimeLossReason>>(mydata);
            foreach (var data in serializeData)
            {
                DownTimeLossReason postdata = new DownTimeLossReason
                {
                    DownTimeReport = data.DownTimeReport,
                    ReportDate = data.ReportDate,
                    TimeStamp = DateTime.Now,
                    UploadTime = DateTime.Now.TimeOfDay.ToString()
                };
                db.DownTimeLossReasons.Add(postdata);
            }
            db.SaveChanges();
            return null;
        }

        // GET: DownTimeLossReasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeLossReason downTimeLossReason = db.DownTimeLossReasons.Find(id);
            if (downTimeLossReason == null)
            {
                return HttpNotFound();
            }
            return View(downTimeLossReason);
        }

        // GET: DownTimeLossReasons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DownTimeLossReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DownTimeReport,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] DownTimeLossReason downTimeLossReason)
        {
            if (ModelState.IsValid)
            {
                downTimeLossReason.DayOftheWeek = DateTime.Today.Date.DayOfWeek.ToString();
                downTimeLossReason.TimeStamp = DateTime.Now;
                downTimeLossReason.UploadTime = DateTime.Now.TimeOfDay.ToString();
                db.DownTimeLossReasons.Add(downTimeLossReason);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(downTimeLossReason);
        }

        // GET: DownTimeLossReasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownTimeLossReason downTimeLossReason = db.DownTimeLossReasons.Find(id);
            if (downTimeLossReason == null)
            {
                return HttpNotFound();
            }
            return View(downTimeLossReason);
        }

        // POST: DownTimeLossReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DownTimeReport,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] DownTimeLossReason downTimeLossReason)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downTimeLossReason).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(downTimeLossReason);
        }

        public ActionResult RemoveRecord(int id)
        {
            try
            {
                DownTimeLossReason downTimeLossReason = db.DownTimeLossReasons.Find(id);
                db.DownTimeLossReasons.Remove(downTimeLossReason);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet); ;
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
