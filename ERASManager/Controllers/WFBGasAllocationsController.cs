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
    public class WFBGasAllocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WFBGasAllocations
        public ActionResult Index()
        {
            return View(db.WFBGasAllocations.ToList());
        }

        // GET: WFBGasAllocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBGasAllocation wFBGasAllocation = db.WFBGasAllocations.Find(id);
            if (wFBGasAllocation == null)
            {
                return HttpNotFound();
            }
            return View(wFBGasAllocation);
        }

        // GET: WFBGasAllocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WFBGasAllocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Well,GOR,GAS,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBGasAllocation wFBGasAllocation)
        {
            if (ModelState.IsValid)
            {
                db.WFBGasAllocations.Add(wFBGasAllocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wFBGasAllocation);
        }

        // GET: WFBGasAllocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBGasAllocation wFBGasAllocation = db.WFBGasAllocations.Find(id);
            if (wFBGasAllocation == null)
            {
                return HttpNotFound();
            }
            return View(wFBGasAllocation);
        }

        // POST: WFBGasAllocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Well,GOR,GAS,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] WFBGasAllocation wFBGasAllocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wFBGasAllocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wFBGasAllocation);
        }

        // GET: WFBGasAllocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WFBGasAllocation wFBGasAllocation = db.WFBGasAllocations.Find(id);
            if (wFBGasAllocation == null)
            {
                return HttpNotFound();
            }
            return View(wFBGasAllocation);
        }

        // POST: WFBGasAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WFBGasAllocation wFBGasAllocation = db.WFBGasAllocations.Find(id);
            db.WFBGasAllocations.Remove(wFBGasAllocation);
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
