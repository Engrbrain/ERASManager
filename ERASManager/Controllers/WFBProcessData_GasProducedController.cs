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
    public class WFBProcessData_GasProducedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WFBProcessData_GasProduced
        public ActionResult Index()
        {
            return View(db.WFBProcessData_GasProduced.ToList());
        }

        // GET: WFBProcessData_GasProduced/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBProcessData_GasProduced wFBProcessData_GasProduced = db.WFBProcessData_GasProduced.Find(id);
            if (wFBProcessData_GasProduced == null)
            {
                return HttpNotFound();
            }
            return View(wFBProcessData_GasProduced);
        }

        // GET: WFBProcessData_GasProduced/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WFBProcessData_GasProduced/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GasFlowParameter,GasFlow,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBProcessData_GasProduced wFBProcessData_GasProduced)
        {
            if (ModelState.IsValid)
            {
                db.WFBProcessData_GasProduced.Add(wFBProcessData_GasProduced);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wFBProcessData_GasProduced);
        }

        // GET: WFBProcessData_GasProduced/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBProcessData_GasProduced wFBProcessData_GasProduced = db.WFBProcessData_GasProduced.Find(id);
            if (wFBProcessData_GasProduced == null)
            {
                return HttpNotFound();
            }
            return View(wFBProcessData_GasProduced);
        }

        // POST: WFBProcessData_GasProduced/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GasFlowParameter,GasFlow,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBProcessData_GasProduced wFBProcessData_GasProduced)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wFBProcessData_GasProduced).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wFBProcessData_GasProduced);
        }

        // GET: WFBProcessData_GasProduced/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBProcessData_GasProduced wFBProcessData_GasProduced = db.WFBProcessData_GasProduced.Find(id);
            if (wFBProcessData_GasProduced == null)
            {
                return HttpNotFound();
            }
            return View(wFBProcessData_GasProduced);
        }

        // POST: WFBProcessData_GasProduced/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WFBProcessData_GasProduced wFBProcessData_GasProduced = db.WFBProcessData_GasProduced.Find(id);
            db.WFBProcessData_GasProduced.Remove(wFBProcessData_GasProduced);
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
