using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class Course_OfferinglController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Course_Offeringl
        public ActionResult Index()
        {
            var course_Offering_Tbl = db.Course_Offering_Tbl.Include(c => c.Course_Tbl).Include(c => c.Lab_Tbl).Include(c => c.Semester_Tbl_).Include(c => c.Student_Tbl);
            return View(course_Offering_Tbl.ToList());
        }

        // GET: Course_Offeringl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Offering_Tbl course_Offering_Tbl = db.Course_Offering_Tbl.Find(id);
            if (course_Offering_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(course_Offering_Tbl);
        }

        // GET: Course_Offeringl/Create
        public ActionResult Create()
        {
            ViewBag.Course_ID = new SelectList(db.Course_Tbl, "ID", "Course_Name");
            ViewBag.Lab_ID = new SelectList(db.Lab_Tbl, "Lab_ID", "Lab_ID");
            ViewBag.Semester_ID = new SelectList(db.Semester_Tbl_, "ID", "Semester");
            ViewBag.Student_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name");
            return View();
        }

        // POST: Course_Offeringl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Day,Time,Location,Sec_tion,Student_ID,Lab_ID,Course_ID,Semester_ID")] Course_Offering_Tbl course_Offering_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Course_Offering_Tbl.Add(course_Offering_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_ID = new SelectList(db.Course_Tbl, "ID", "Course_Name", course_Offering_Tbl.Course_ID);
            ViewBag.Lab_ID = new SelectList(db.Lab_Tbl, "Lab_ID", "Lab_ID", course_Offering_Tbl.Lab_ID);
            ViewBag.Semester_ID = new SelectList(db.Semester_Tbl_, "ID", "Semester", course_Offering_Tbl.Semester_ID);
            ViewBag.Student_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name", course_Offering_Tbl.Student_ID);
            return View(course_Offering_Tbl);
        }

        // GET: Course_Offeringl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Offering_Tbl course_Offering_Tbl = db.Course_Offering_Tbl.Find(id);
            if (course_Offering_Tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_ID = new SelectList(db.Course_Tbl, "ID", "Course_Name", course_Offering_Tbl.Course_ID);
            ViewBag.Lab_ID = new SelectList(db.Lab_Tbl, "Lab_ID", "Lab_ID", course_Offering_Tbl.Lab_ID);
            ViewBag.Semester_ID = new SelectList(db.Semester_Tbl_, "ID", "Semester", course_Offering_Tbl.Semester_ID);
            ViewBag.Student_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name", course_Offering_Tbl.Student_ID);
            return View(course_Offering_Tbl);
        }

        // POST: Course_Offeringl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Day,Time,Location,Sec_tion,Student_ID,Lab_ID,Course_ID,Semester_ID")] Course_Offering_Tbl course_Offering_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Offering_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_ID = new SelectList(db.Course_Tbl, "ID", "Course_Name", course_Offering_Tbl.Course_ID);
            ViewBag.Lab_ID = new SelectList(db.Lab_Tbl, "Lab_ID", "Lab_ID", course_Offering_Tbl.Lab_ID);
            ViewBag.Semester_ID = new SelectList(db.Semester_Tbl_, "ID", "Semester", course_Offering_Tbl.Semester_ID);
            ViewBag.Student_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name", course_Offering_Tbl.Student_ID);
            return View(course_Offering_Tbl);
        }

        // GET: Course_Offeringl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Offering_Tbl course_Offering_Tbl = db.Course_Offering_Tbl.Find(id);
            if (course_Offering_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(course_Offering_Tbl);
        }

        // POST: Course_Offeringl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Offering_Tbl course_Offering_Tbl = db.Course_Offering_Tbl.Find(id);
            db.Course_Offering_Tbl.Remove(course_Offering_Tbl);
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