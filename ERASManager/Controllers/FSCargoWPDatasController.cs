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
    public class FSCargoWPDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FSCargoWPDatas
        public ActionResult Index()
        {
            return View(db.FSCargoWPData.ToList());
        }

        // GET: FSCargoWPDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSCargoWPData fSCargoWPData = db.FSCargoWPData.Find(id);
            if (fSCargoWPData == null)
            {
                return HttpNotFound();
            }
            return View(fSCargoWPData);
        }

        // GET: FSCargoWPDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FSCargoWPDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Parameters,ParameterValue,ParameterUnit,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] FSCargoWPData fSCargoWPData)
        {
            if (ModelState.IsValid)
            {
                db.FSCargoWPData.Add(fSCargoWPData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fSCargoWPData);
        }

        // GET: FSCargoWPDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSCargoWPData fSCargoWPData = db.FSCargoWPData.Find(id);
            if (fSCargoWPData == null)
            {
                return HttpNotFound();
            }
            return View(fSCargoWPData);
        }

        // POST: FSCargoWPDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Parameters,ParameterValue,ParameterUnit,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] FSCargoWPData fSCargoWPData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fSCargoWPData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fSCargoWPData);
        }

        // GET: FSCargoWPDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSCargoWPData fSCargoWPData = db.FSCargoWPData.Find(id);
            if (fSCargoWPData == null)
            {
                return HttpNotFound();
            }
            return View(fSCargoWPData);
        }

        // POST: FSCargoWPDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FSCargoWPData fSCargoWPData = db.FSCargoWPData.Find(id);
            db.FSCargoWPData.Remove(fSCargoWPData);
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
