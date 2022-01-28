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
    public class CFBCrudeExportMetersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBCrudeExportMeters
        public ActionResult Index()
        {
            return View(db.CFBCrudeExportMeters.ToList());
        }


        public ActionResult LoadPrevious()
        {
            List<CFBCrudeExportMeter> cFBCrudeExportMeter = new List<CFBCrudeExportMeter>();

            cFBCrudeExportMeter = db.Database.SqlQuery<CFBCrudeExportMeter>(
        "usp_GetCFBCrudeExportMeterPrevious"
        ).ToList();
            return View(cFBCrudeExportMeter);
        }

        public ActionResult CreateMultipleBulk()
        {
            return View();
        }

        [WebMethod]
        public string LoadBulkData(string mydata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<CFBCrudeExportMeter>>(mydata);
            foreach (var data in serializeData)
            {
                CFBCrudeExportMeter postdata = new CFBCrudeExportMeter
                {
                    BSW = data.BSW,
                    CurrentEightHours = data.CurrentEightHours,
                    DayOftheWeek = DateTime.Now.DayOfWeek.ToString(),
                    GrossCorr = data.GrossCorr,
                    MeterFactor = data.MeterFactor,
                    MeterName = data.MeterName,
                    NetOil = data.NetOil,
                    ReportDate = data.ReportDate,
                    TimeStamp = DateTime.Now,
                    UploadTime = DateTime.Now.TimeOfDay.ToString()
                };
                db.CFBCrudeExportMeters.Add(postdata);
               
            }
            db.SaveChanges();
            return  null; 
        }

        // GET: CFBCrudeExportMeters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBCrudeExportMeter cFBCrudeExportMeter = db.CFBCrudeExportMeters.Find(id);
            if (cFBCrudeExportMeter == null)
            {
                return HttpNotFound();
            }
            return View(cFBCrudeExportMeter);
        }

        // GET: CFBCrudeExportMeters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBCrudeExportMeters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MeterName,CurrentEightHours,MeterFactor,GrossCorr,BSW,NetOil,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBCrudeExportMeter cFBCrudeExportMeter)
        {
            if (ModelState.IsValid)
            {
                db.CFBCrudeExportMeters.Add(cFBCrudeExportMeter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBCrudeExportMeter);
        }

        // GET: CFBCrudeExportMeters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBCrudeExportMeter cFBCrudeExportMeter = db.CFBCrudeExportMeters.Find(id);
            if (cFBCrudeExportMeter == null)
            {
                return HttpNotFound();
            }
            return View(cFBCrudeExportMeter);
        }

        // POST: CFBCrudeExportMeters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MeterName,CurrentEightHours,MeterFactor,GrossCorr,BSW,NetOil,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBCrudeExportMeter cFBCrudeExportMeter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBCrudeExportMeter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBCrudeExportMeter);
        }

        // GET: CFBCrudeExportMeters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBCrudeExportMeter cFBCrudeExportMeter = db.CFBCrudeExportMeters.Find(id);
            if (cFBCrudeExportMeter == null)
            {
                return HttpNotFound();
            }
            return View(cFBCrudeExportMeter);
        }

        // POST: CFBCrudeExportMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBCrudeExportMeter cFBCrudeExportMeter = db.CFBCrudeExportMeters.Find(id);
            db.CFBCrudeExportMeters.Remove(cFBCrudeExportMeter);
            db.SaveChanges();
            return RedirectToAction("Index");
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
