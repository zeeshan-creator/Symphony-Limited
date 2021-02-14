using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Course
        public ActionResult Index()
        {
            return View(db.Course_Tbl.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Tbl course_Tbl = db.Course_Tbl.Find(id);
            if (course_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(course_Tbl);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Course_Name,Course_Number")] Course_Tbl course_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Course_Tbl.Add(course_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course_Tbl);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Tbl course_Tbl = db.Course_Tbl.Find(id);
            if (course_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(course_Tbl);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Course_Name,Course_Number")] Course_Tbl course_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course_Tbl);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Tbl course_Tbl = db.Course_Tbl.Find(id);
            if (course_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(course_Tbl);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Tbl course_Tbl = db.Course_Tbl.Find(id);
            db.Course_Tbl.Remove(course_Tbl);
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