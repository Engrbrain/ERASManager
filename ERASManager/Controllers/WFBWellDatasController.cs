using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERASManager.Models;
using ERASManager.Models.EBOKDailyReport;

namespace ERASManager.Controllers
{
    public class WFBWellDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WFBWellDatas
        public ActionResult Index()
        {
            return View(db.WFBWellData.ToList());
        }

        // GET: WFBWellDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBWellData wFBWellData = db.WFBWellData.Find(id);
            if (wFBWellData == null)
            {
                return HttpNotFound();
            }
            return View(wFBWellData);
        }

        // GET: WFBWellDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WFBWellDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rsv,Well,CHOKE,HOURS_Online,HOURS_Offline,THP,FLP,BSW,Ps,Pwf,BHT,DP,OIL,GAS,WATER,API,PumpFrequency,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBWellData wFBWellData)
        {
            if (ModelState.IsValid)
            {
                db.WFBWellData.Add(wFBWellData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wFBWellData);
        }

        // GET: WFBWellDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBWellData wFBWellData = db.WFBWellData.Find(id);
            if (wFBWellData == null)
            {
                return HttpNotFound();
            }
            return View(wFBWellData);
        }

        // POST: WFBWellDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rsv,Well,CHOKE,HOURS_Online,HOURS_Offline,THP,FLP,BSW,Ps,Pwf,BHT,DP,OIL,GAS,WATER,API,PumpFrequency,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBWellData wFBWellData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wFBWellData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wFBWellData);
        }

        // GET: WFBWellDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBWellData wFBWellData = db.WFBWellData.Find(id);
            if (wFBWellData == null)
            {
                return HttpNotFound();
            }
            return View(wFBWellData);
        }

        // POST: WFBWellDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WFBWellData wFBWellData = db.WFBWellData.Find(id);
            db.WFBWellData.Remove(wFBWellData);
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
