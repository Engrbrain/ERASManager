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
    public class OperationsSummariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OperationsSummaries
        public ActionResult Index()
        {
            var operationsSummary = db.OperationsSummaries.Where(x => x.ReportDate == DateTime.Today.Date);
            return View(operationsSummary.ToList());
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            var operationsSummary = db.OperationsSummaries.Where(x => x.ReportDate >= StartDate && x.ReportDate <= EndDate);
            return View("Index", operationsSummary);
        }
        public ActionResult LoadPrevious()
        {
            List<OperationsSummary> operationsSummary = new List<OperationsSummary>();

            operationsSummary = db.Database.SqlQuery<OperationsSummary>(
        "usp_GetOperationsSummary"
        ).ToList();
            return View("Index", operationsSummary);
        }

        public ActionResult CreateMultipleBulk()
        {
            return View();
        }

        [WebMethod]
        public string LoadBulkData(string mydata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<OperationsSummary>>(mydata);
            foreach (var data in serializeData)
            {
                OperationsSummary postdata = new OperationsSummary
                {
                    OperationsReport = data.OperationsReport,
                    ReportDate = data.ReportDate,
                    TimeStamp = DateTime.Now,
                    UploadTime = DateTime.Now.TimeOfDay.ToString()
                };
                db.OperationsSummaries.Add(postdata);
            }
            db.SaveChanges();
            return null;
        }



        // GET: OperationsSummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationsSummary operationsSummary = db.OperationsSummaries.Find(id);
            if (operationsSummary == null)
            {
                return HttpNotFound();
            }
            return View(operationsSummary);
        }

        // GET: OperationsSummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OperationsSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OperationsReport,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] OperationsSummary operationsSummary)
        {
            if (ModelState.IsValid)
            {
                operationsSummary.DayOftheWeek = DateTime.Today.Date.DayOfWeek.ToString();
                operationsSummary.TimeStamp = DateTime.Now;
                operationsSummary.UploadTime = DateTime.Now.TimeOfDay.ToString();
                db.OperationsSummaries.Add(operationsSummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operationsSummary);
        }

        // GET: OperationsSummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationsSummary operationsSummary = db.OperationsSummaries.Find(id);
            if (operationsSummary == null)
            {
                return HttpNotFound();
            }
            return View(operationsSummary);
        }

        // POST: OperationsSummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OperationsReport,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] OperationsSummary operationsSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operationsSummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operationsSummary);
        }

        public ActionResult RemoveRecord(int id)
        {
            try
            {
                OperationsSummary operationsSummary = db.OperationsSummaries.Find(id);
                db.OperationsSummaries.Remove(operationsSummary);
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
