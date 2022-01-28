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
    public class CFBWellDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBWellDatas
        public ActionResult Index()
        {
            return View(db.CFBWellData.ToList());
        }

        // GET: CFBWellDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBWellData cFBWellData = db.CFBWellData.Find(id);
            if (cFBWellData == null)
            {
                return HttpNotFound();
            }
            return View(cFBWellData);
        }

        // GET: CFBWellDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBWellDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rsv,Well,CHOKE,HOURS_Online,HOURS_Offline,THP,FLP,BSW,Ps,Pwf,BHT,DP,OIL,GAS,WATER,API,PumpFrequency,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBWellData cFBWellData)
        {
            if (ModelState.IsValid)
            {
                db.CFBWellData.Add(cFBWellData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBWellData);
        }

        // GET: CFBWellDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBWellData cFBWellData = db.CFBWellData.Find(id);
            if (cFBWellData == null)
            {
                return HttpNotFound();
            }
            return View(cFBWellData);
        }

        // POST: CFBWellDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rsv,Well,CHOKE,HOURS_Online,HOURS_Offline,THP,FLP,BSW,Ps,Pwf,BHT,DP,OIL,GAS,WATER,API,PumpFrequency,Comment,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBWellData cFBWellData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBWellData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBWellData);
        }

        // GET: CFBWellDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBWellData cFBWellData = db.CFBWellData.Find(id);
            if (cFBWellData == null)
            {
                return HttpNotFound();
            }
            return View(cFBWellData);
        }

        // POST: CFBWellDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBWellData cFBWellData = db.CFBWellData.Find(id);
            db.CFBWellData.Remove(cFBWellData);
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
