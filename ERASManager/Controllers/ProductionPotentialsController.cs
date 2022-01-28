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
    public class ProductionPotentialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductionPotentials
        public ActionResult Index()
        {
            return View(db.ProductionPotential.ToList());
        }

        // GET: ProductionPotentials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPotential productionPotential = db.ProductionPotential.Find(id);
            if (productionPotential == null)
            {
                return HttpNotFound();
            }
            return View(productionPotential);
        }

        // GET: ProductionPotentials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionPotentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Well,GrossLiquid,Oil,Gas,Water,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] ProductionPotential productionPotential)
        {
            if (ModelState.IsValid)
            {
                db.ProductionPotential.Add(productionPotential);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionPotential);
        }

        // GET: ProductionPotentials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPotential productionPotential = db.ProductionPotential.Find(id);
            if (productionPotential == null)
            {
                return HttpNotFound();
            }
            return View(productionPotential);
        }

        // POST: ProductionPotentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Well,GrossLiquid,Oil,Gas,Water,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] ProductionPotential productionPotential)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionPotential).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productionPotential);
        }

        // GET: ProductionPotentials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPotential productionPotential = db.ProductionPotential.Find(id);
            if (productionPotential == null)
            {
                return HttpNotFound();
            }
            return View(productionPotential);
        }

        // POST: ProductionPotentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionPotential productionPotential = db.ProductionPotential.Find(id);
            db.ProductionPotential.Remove(productionPotential);
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
