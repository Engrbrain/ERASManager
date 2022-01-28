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
    public class FSOOILQUALITiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FSOOILQUALITies
        public ActionResult Index()
        {
            return View(db.FSOOILQUALITIES.ToList());
        }

        // GET: FSOOILQUALITies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSOOILQUALITY fSOOILQUALITY = db.FSOOILQUALITIES.Find(id);
            if (fSOOILQUALITY == null)
            {
                return HttpNotFound();
            }
            return View(fSOOILQUALITY);
        }

        // GET: FSOOILQUALITies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FSOOILQUALITies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Parameters,ParameterValue,ParameterUnit,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] FSOOILQUALITY fSOOILQUALITY)
        {
            if (ModelState.IsValid)
            {
                db.FSOOILQUALITIES.Add(fSOOILQUALITY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fSOOILQUALITY);
        }

        // GET: FSOOILQUALITies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSOOILQUALITY fSOOILQUALITY = db.FSOOILQUALITIES.Find(id);
            if (fSOOILQUALITY == null)
            {
                return HttpNotFound();
            }
            return View(fSOOILQUALITY);
        }

        // POST: FSOOILQUALITies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Parameters,ParameterValue,ParameterUnit,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] FSOOILQUALITY fSOOILQUALITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fSOOILQUALITY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fSOOILQUALITY);
        }

        // GET: FSOOILQUALITies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FSOOILQUALITY fSOOILQUALITY = db.FSOOILQUALITIES.Find(id);
            if (fSOOILQUALITY == null)
            {
                return HttpNotFound();
            }
            return View(fSOOILQUALITY);
        }

        // POST: FSOOILQUALITies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FSOOILQUALITY fSOOILQUALITY = db.FSOOILQUALITIES.Find(id);
            db.FSOOILQUALITIES.Remove(fSOOILQUALITY);
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
