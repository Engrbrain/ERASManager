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
    public class CFBProcessData_GasProducedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CFBProcessData_GasProduced
        public ActionResult Index()
        {
            return View(db.CFBProcessData_GasProduced.ToList());
        }

        // GET: CFBProcessData_GasProduced/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBProcessData_GasProduced cFBProcessData_GasProduced = db.CFBProcessData_GasProduced.Find(id);
            if (cFBProcessData_GasProduced == null)
            {
                return HttpNotFound();
            }
            return View(cFBProcessData_GasProduced);
        }

        // GET: CFBProcessData_GasProduced/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CFBProcessData_GasProduced/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GasFlowParameter,GasFlow,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBProcessData_GasProduced cFBProcessData_GasProduced)
        {
            if (ModelState.IsValid)
            {
                db.CFBProcessData_GasProduced.Add(cFBProcessData_GasProduced);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFBProcessData_GasProduced);
        }

        // GET: CFBProcessData_GasProduced/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBProcessData_GasProduced cFBProcessData_GasProduced = db.CFBProcessData_GasProduced.Find(id);
            if (cFBProcessData_GasProduced == null)
            {
                return HttpNotFound();
            }
            return View(cFBProcessData_GasProduced);
        }

        // POST: CFBProcessData_GasProduced/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GasFlowParameter,GasFlow,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] CFBProcessData_GasProduced cFBProcessData_GasProduced)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFBProcessData_GasProduced).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFBProcessData_GasProduced);
        }

        // GET: CFBProcessData_GasProduced/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFBProcessData_GasProduced cFBProcessData_GasProduced = db.CFBProcessData_GasProduced.Find(id);
            if (cFBProcessData_GasProduced == null)
            {
                return HttpNotFound();
            }
            return View(cFBProcessData_GasProduced);
        }

        // POST: CFBProcessData_GasProduced/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CFBProcessData_GasProduced cFBProcessData_GasProduced = db.CFBProcessData_GasProduced.Find(id);
            db.CFBProcessData_GasProduced.Remove(cFBProcessData_GasProduced);
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
