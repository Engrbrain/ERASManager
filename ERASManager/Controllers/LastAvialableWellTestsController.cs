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
    public class LastAvialableWellTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LastAvialableWellTests
        public ActionResult Index()
        {
            return View(db.LastAvialableWellTests.ToList());
        }

        // GET: LastAvialableWellTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastAvialableWellTest lastAvialableWellTest = db.LastAvialableWellTests.Find(id);
            if (lastAvialableWellTest == null)
            {
                return HttpNotFound();
            }
            return View(lastAvialableWellTest);
        }

        // GET: LastAvialableWellTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LastAvialableWellTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Well,GrossLiquid,Oil,Gas,Water,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] LastAvialableWellTest lastAvialableWellTest)
        {
            if (ModelState.IsValid)
            {
                db.LastAvialableWellTests.Add(lastAvialableWellTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lastAvialableWellTest);
        }

        // GET: LastAvialableWellTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastAvialableWellTest lastAvialableWellTest = db.LastAvialableWellTests.Find(id);
            if (lastAvialableWellTest == null)
            {
                return HttpNotFound();
            }
            return View(lastAvialableWellTest);
        }

        // POST: LastAvialableWellTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Well,GrossLiquid,Oil,Gas,Water,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] LastAvialableWellTest lastAvialableWellTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lastAvialableWellTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lastAvialableWellTest);
        }

        // GET: LastAvialableWellTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastAvialableWellTest lastAvialableWellTest = db.LastAvialableWellTests.Find(id);
            if (lastAvialableWellTest == null)
            {
                return HttpNotFound();
            }
            return View(lastAvialableWellTest);
        }

        // POST: LastAvialableWellTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LastAvialableWellTest lastAvialableWellTest = db.LastAvialableWellTests.Find(id);
            db.LastAvialableWellTests.Remove(lastAvialableWellTest);
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
