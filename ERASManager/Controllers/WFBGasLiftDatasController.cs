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
    public class WFBGasLiftDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WFBGasLiftDatas
        public ActionResult Index()
        {
            return View(db.WFBGasLiftData.ToList());
        }

        // GET: WFBGasLiftDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBGasLiftData wFBGasLiftData = db.WFBGasLiftData.Find(id);
            if (wFBGasLiftData == null)
            {
                return HttpNotFound();
            }
            return View(wFBGasLiftData);
        }

        // GET: WFBGasLiftDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WFBGasLiftDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Well,Parameter,ParameterValue,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBGasLiftData wFBGasLiftData)
        {
            if (ModelState.IsValid)
            {
                db.WFBGasLiftData.Add(wFBGasLiftData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wFBGasLiftData);
        }

        // GET: WFBGasLiftDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBGasLiftData wFBGasLiftData = db.WFBGasLiftData.Find(id);
            if (wFBGasLiftData == null)
            {
                return HttpNotFound();
            }
            return View(wFBGasLiftData);
        }

        // POST: WFBGasLiftDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Well,Parameter,ParameterValue,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBGasLiftData wFBGasLiftData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wFBGasLiftData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wFBGasLiftData);
        }

        // GET: WFBGasLiftDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBGasLiftData wFBGasLiftData = db.WFBGasLiftData.Find(id);
            if (wFBGasLiftData == null)
            {
                return HttpNotFound();
            }
            return View(wFBGasLiftData);
        }

        // POST: WFBGasLiftDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WFBGasLiftData wFBGasLiftData = db.WFBGasLiftData.Find(id);
            db.WFBGasLiftData.Remove(wFBGasLiftData);
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
