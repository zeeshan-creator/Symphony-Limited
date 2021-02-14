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
    public class StudentController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Student_Tbl.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Tbl student_Tbl = db.Student_Tbl.Find(id);
            if (student_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(student_Tbl);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Student_Name,Student_Lastname,GPA,Grade,Address,Roll_Number,Password2,Email2")] Student_Tbl student_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Student_Tbl.Add(student_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_Tbl);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Tbl student_Tbl = db.Student_Tbl.Find(id);
            if (student_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(student_Tbl);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Student_Name,Student_Lastname,GPA,Grade,Address,Roll_Number,Password2,Email2")] Student_Tbl student_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_Tbl);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Tbl student_Tbl = db.Student_Tbl.Find(id);
            if (student_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(student_Tbl);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Tbl student_Tbl = db.Student_Tbl.Find(id);
            db.Student_Tbl.Remove(student_Tbl);
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
