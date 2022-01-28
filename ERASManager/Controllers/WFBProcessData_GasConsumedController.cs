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
    public class WFBProcessData_GasConsumedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WFBProcessData_GasConsumed
        public ActionResult Index()
        {
            return View(db.WFBProcessData_GasConsumed.ToList());
        }

        // GET: WFBProcessData_GasConsumed/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBProcessData_GasConsumed wFBProcessData_GasConsumed = db.WFBProcessData_GasConsumed.Find(id);
            if (wFBProcessData_GasConsumed == null)
            {
                return HttpNotFound();
            }
            return View(wFBProcessData_GasConsumed);
        }

        // GET: WFBProcessData_GasConsumed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WFBProcessData_GasConsumed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GasFlowParameter,GasFlow,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBProcessData_GasConsumed wFBProcessData_GasConsumed)
        {
            if (ModelState.IsValid)
            {
                db.WFBProcessData_GasConsumed.Add(wFBProcessData_GasConsumed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wFBProcessData_GasConsumed);
        }

        // GET: WFBProcessData_GasConsumed/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBProcessData_GasConsumed wFBProcessData_GasConsumed = db.WFBProcessData_GasConsumed.Find(id);
            if (wFBProcessData_GasConsumed == null)
            {
                return HttpNotFound();
            }
            return View(wFBProcessData_GasConsumed);
        }

        // POST: WFBProcessData_GasConsumed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GasFlowParameter,GasFlow,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBProcessData_GasConsumed wFBProcessData_GasConsumed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wFBProcessData_GasConsumed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wFBProcessData_GasConsumed);
        }

        // GET: WFBProcessData_GasConsumed/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBProcessData_GasConsumed wFBProcessData_GasConsumed = db.WFBProcessData_GasConsumed.Find(id);
            if (wFBProcessData_GasConsumed == null)
            {
                return HttpNotFound();
            }
            return View(wFBProcessData_GasConsumed);
        }

        // POST: WFBProcessData_GasConsumed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WFBProcessData_GasConsumed wFBProcessData_GasConsumed = db.WFBProcessData_GasConsumed.Find(id);
            db.WFBProcessData_GasConsumed.Remove(wFBProcessData_GasConsumed);
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
