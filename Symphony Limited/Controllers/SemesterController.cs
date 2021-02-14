using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SymphonyLimited.DbContext;

namespace Symphony_Limited.Controllers
{
    public class SemesterController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Semester
        public ActionResult Index()
        {
            return View(db.Semester_Tbl_.ToList());
        }

        // GET: Semester/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Tbl_ semester_Tbl_ = db.Semester_Tbl_.Find(id);
            if (semester_Tbl_ == null)
            {
                return HttpNotFound();
            }
            return View(semester_Tbl_);
        }

        // GET: Semester/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semester/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Semester,Semester_number")] Semester_Tbl_ semester_Tbl_)
        {
            if (ModelState.IsValid)
            {
                db.Semester_Tbl_.Add(semester_Tbl_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semester_Tbl_);
        }

        // GET: Semester/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Tbl_ semester_Tbl_ = db.Semester_Tbl_.Find(id);
            if (semester_Tbl_ == null)
            {
                return HttpNotFound();
            }
            return View(semester_Tbl_);
        }

        // POST: Semester/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Semester,Semester_number")] Semester_Tbl_ semester_Tbl_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semester_Tbl_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semester_Tbl_);
        }

        // GET: Semester/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester_Tbl_ semester_Tbl_ = db.Semester_Tbl_.Find(id);
            if (semester_Tbl_ == null)
            {
                return HttpNotFound();
            }
            return View(semester_Tbl_);
        }

        // POST: Semester/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semester_Tbl_ semester_Tbl_ = db.Semester_Tbl_.Find(id);
            db.Semester_Tbl_.Remove(semester_Tbl_);
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
