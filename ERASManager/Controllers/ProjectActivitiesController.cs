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
    public class ProjectActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProjectActivities
        public ActionResult Index()
        {
            return View(db.ProjectActivities.ToList());
        }

        // GET: ProjectActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectActivity projectActivity = db.ProjectActivities.Find(id);
            if (projectActivity == null)
            {
                return HttpNotFound();
            }
            return View(projectActivity);
        }

        // GET: ProjectActivities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] ProjectActivity projectActivity)
        {
            if (ModelState.IsValid)
            {
                db.ProjectActivities.Add(projectActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectActivity);
        }

        // GET: ProjectActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectActivity projectActivity = db.ProjectActivities.Find(id);
            if (projectActivity == null)
            {
                return HttpNotFound();
            }
            return View(projectActivity);
        }

        // POST: ProjectActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Report,ReportDate,UploadTime,TimeStamp,DayOftheWeek")] ProjectActivity projectActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectActivity);
        }

        // GET: ProjectActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectActivity projectActivity = db.ProjectActivities.Find(id);
            if (projectActivity == null)
            {
                return HttpNotFound();
            }
            return View(projectActivity);
        }

        // POST: ProjectActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectActivity projectActivity = db.ProjectActivities.Find(id);
            db.ProjectActivities.Remove(projectActivity);
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
