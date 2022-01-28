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
    public class WellTestEnrichmentDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WellTestEnrichmentDatas
        public ActionResult Index()
        {
            return View(db.WellTestEnrichmentData.ToList());
        }

        // GET: WellTestEnrichmentDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellTestEnrichmentData wellTestEnrichmentData = db.WellTestEnrichmentData.Find(id);
            if (wellTestEnrichmentData == null)
            {
                return HttpNotFound();
            }
            return View(wellTestEnrichmentData);
        }

        // GET: WellTestEnrichmentDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WellTestEnrichmentDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Well,Rsv,TimeStamp")] WellTestEnrichmentData wellTestEnrichmentData)
        {
            if (ModelState.IsValid)
            {
                db.WellTestEnrichmentData.Add(wellTestEnrichmentData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wellTestEnrichmentData);
        }

        // GET: WellTestEnrichmentDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellTestEnrichmentData wellTestEnrichmentData = db.WellTestEnrichmentData.Find(id);
            if (wellTestEnrichmentData == null)
            {
                return HttpNotFound();
            }
            return View(wellTestEnrichmentData);
        }

        // POST: WellTestEnrichmentDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Well,Rsv,TimeStamp")] WellTestEnrichmentData wellTestEnrichmentData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wellTestEnrichmentData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wellTestEnrichmentData);
        }

        // GET: WellTestEnrichmentDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellTestEnrichmentData wellTestEnrichmentData = db.WellTestEnrichmentData.Find(id);
            if (wellTestEnrichmentData == null)
            {
                return HttpNotFound();
            }
            return View(wellTestEnrichmentData);
        }

        // POST: WellTestEnrichmentDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WellTestEnrichmentData wellTestEnrichmentData = db.WellTestEnrichmentData.Find(id);
            db.WellTestEnrichmentData.Remove(wellTestEnrichmentData);
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
