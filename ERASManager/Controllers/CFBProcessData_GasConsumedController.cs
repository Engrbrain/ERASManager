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
    public class CFBProcessData_GasConsumedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBProcessData_GasConsumed
        public ActionResult Index()
        {
            return View(db.CFBProcessData_GasConsumed.ToList());
        }

        // GET: CFBProcessData_GasConsumed/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBProcessData_GasConsumed cFBProcessData_GasConsumed = db.CFBProcessData_GasConsumed.Find(id);
            if (cFBProcessData_GasConsumed == null)
            {
                return HttpNotFound();
            }
            return View(cFBProcessData_GasConsumed);
        }

        // GET: CFBProcessData_GasConsumed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBProcessData_GasConsumed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GasFlowParameter,GasFlow,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBProcessData_GasConsumed cFBProcessData_GasConsumed)
        {
            if (ModelState.IsValid)
            {
                db.CFBProcessData_GasConsumed.Add(cFBProcessData_GasConsumed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBProcessData_GasConsumed);
        }

        // GET: CFBProcessData_GasConsumed/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBProcessData_GasConsumed cFBProcessData_GasConsumed = db.CFBProcessData_GasConsumed.Find(id);
            if (cFBProcessData_GasConsumed == null)
            {
                return HttpNotFound();
            }
            return View(cFBProcessData_GasConsumed);
        }

        // POST: CFBProcessData_GasConsumed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GasFlowParameter,GasFlow,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBProcessData_GasConsumed cFBProcessData_GasConsumed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBProcessData_GasConsumed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBProcessData_GasConsumed);
        }

        // GET: CFBProcessData_GasConsumed/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBProcessData_GasConsumed cFBProcessData_GasConsumed = db.CFBProcessData_GasConsumed.Find(id);
            if (cFBProcessData_GasConsumed == null)
            {
                return HttpNotFound();
            }
            return View(cFBProcessData_GasConsumed);
        }

        // POST: CFBProcessData_GasConsumed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBProcessData_GasConsumed cFBProcessData_GasConsumed = db.CFBProcessData_GasConsumed.Find(id);
            db.CFBProcessData_GasConsumed.Remove(cFBProcessData_GasConsumed);
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
