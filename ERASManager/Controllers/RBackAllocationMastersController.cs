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
using ERASManager.Models.RevisedBackAllocation;
using Newtonsoft.Json;

namespace ERASManager.Controllers
{
    public class RBackAllocationMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RBackAllocationMasters
        public ActionResult Index(DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate == null)
            {
                //return View("Index", "ReportParameters");
                return RedirectToAction("Index", "ReportParameters", new { ReportBearer = "RBackAllocationMasters" });
            }
            else
            {
                List<RBackAllocationMaster> rBackAllocationMaster = new List<RBackAllocationMaster>();

                rBackAllocationMaster = db.Database.SqlQuery<RBackAllocationMaster>(
            "exec dbo.[usp_GetRBackAllocationMaster] @StartDate,@EndDate",
           new SqlParameter("@StartDate", StartDate),
           new SqlParameter("@EndDate", EndDate)
            ).ToList();
                return View(rBackAllocationMaster);
            }
        }

        public ActionResult FilterReport(ReportParameter model)
        {
            var StartDate = model.StartDate.Date;
            var EndDate = model.EndDate.Date;
            List<RBackAllocationMaster> rBackAllocationMaster = new List<RBackAllocationMaster>();

            rBackAllocationMaster = db.Database.SqlQuery<RBackAllocationMaster>(
        "exec dbo.[usp_GetRBackAllocationMaster] @StartDate,@EndDate",
       new SqlParameter("@StartDate", StartDate),
       new SqlParameter("@EndDate", EndDate)
        ).ToList();
            return View("Index", rBackAllocationMaster);
        }

      
        public ActionResult CreateMultipleBulk(RBackDateSelector model)
        {
            var IndicatorDate = model.IndicatorDate;
            List<RBackAllocationMaster> rBackAllocationMaster = new List<RBackAllocationMaster>();

            rBackAllocationMaster = db.Database.SqlQuery<RBackAllocationMaster>(
        "exec dbo.[usp_GetRBackInfoByDate] @IndicatorDate",
       new SqlParameter("@IndicatorDate", IndicatorDate)).ToList();
            bool isEmpty = !rBackAllocationMaster.Any();
            if (isEmpty)
            {
                ViewBag.Message = "Sorry Daily Report has not been uploaded for the selected date";
            }
            return View(rBackAllocationMaster);
        }

        public ActionResult ProcessBackAllocation()
        {
            List<RBackAllocationMaster> rBackAllocationMaster = new List<RBackAllocationMaster>();

            rBackAllocationMaster = db.Database.SqlQuery<RBackAllocationMaster>(
        "exec dbo.[ProcessRBackAllocation]").ToList();

            List<RBackAllocationMaster> legBackAllocationMaster = new List<RBackAllocationMaster>();

            legBackAllocationMaster = db.Database.SqlQuery<RBackAllocationMaster>(
        "exec dbo.[ProcessLegacyBackAllocation]").ToList();
            var IndicatorDate = legBackAllocationMaster.FirstOrDefault().IndicatorDate;
             return RedirectToAction("Index", "RBK_TransactionalData", new { StartDate = IndicatorDate, EndDate=IndicatorDate });
        }

        [WebMethod]
        public string LoadBulkData(string mydata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<RBackAllocationMaster>>(mydata);
            foreach (var data in serializeData)
            {
                RBackAllocationMaster postdata = new RBackAllocationMaster
                {
                    IndicatorDate = data.IndicatorDate,
                    Well = data.Well,
                    BLPD = data.BLPD,
                    BSW = data.BSW,
                    GOR = data.GOR,
                    CFBStrinkageFactor = data.CFBStrinkageFactor,
                    WFBStrinkageFactor = data.WFBStrinkageFactor,
                    TimeStamp = data.TimeStamp
                };
                db.RBackAllocationMasters.Add(postdata);

            }
          
            db.SaveChanges();
            return null;
        }

        // GET: RBackAllocationMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RBackAllocationMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IndicatorDate,BLPD,BSW,GOR,CFBStrinkageFactor,WFBStrinkageFactor,TimeStamp")] RBackAllocationMaster rBackAllocationMaster)
        {
            if (ModelState.IsValid)
            {
                rBackAllocationMaster.TimeStamp = DateTime.Now;
                db.RBackAllocationMasters.Add(rBackAllocationMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rBackAllocationMaster);
        }

        // GET: RBackAllocationMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RBackAllocationMaster rBackAllocationMaster = db.RBackAllocationMasters.Find(id);
            if (rBackAllocationMaster == null)
            {
                return HttpNotFound();
            }
            return View(rBackAllocationMaster);
        }

        // POST: RBackAllocationMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IndicatorDate,BLPD,BSW,GOR,CFBStrinkageFactor,WFBStrinkageFactor,TimeStamp")] RBackAllocationMaster rBackAllocationMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rBackAllocationMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rBackAllocationMaster);
        }

        public ActionResult RemoveRecord(int id)
        {
            try
            {
                RBackAllocationMaster rBackAllocationMaster = db.RBackAllocationMasters.Find(id);
                db.RBackAllocationMasters.Remove(rBackAllocationMaster);
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
