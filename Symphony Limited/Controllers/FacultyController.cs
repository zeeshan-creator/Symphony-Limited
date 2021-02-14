using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class FacultyController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Faculty
        public ActionResult Index()
        {
            var faculty_Tbl = db.Faculty_Tbl.Include(f => f.Course_Tbl);
            return View(faculty_Tbl.ToList());
        }

        // GET: Faculty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Tbl faculty_Tbl = db.Faculty_Tbl.Find(id);
            if (faculty_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Tbl);
        }

        // GET: Faculty/Create
        public ActionResult Create()
        {
            ViewBag.Course_ID = new SelectList(db.Course_Tbl, "ID", "Course_Name");
            return View();
        }

        // POST: Faculty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Course_ID")] Faculty_Tbl faculty_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Faculty_Tbl.Add(faculty_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_ID = new SelectList(db.Course_Tbl, "ID", "Course_Name", faculty_Tbl.Course_ID);
            return View(faculty_Tbl);
        }

        // GET: Faculty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Tbl faculty_Tbl = db.Faculty_Tbl.Find(id);
            if (faculty_Tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_ID = new SelectList(db.Course_Tbl, "ID", "Course_Name", faculty_Tbl.Course_ID);
            return View(faculty_Tbl);
        }

        // POST: Faculty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Course_ID")] Faculty_Tbl faculty_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_ID = new SelectList(db.Course_Tbl, "ID", "Course_Name", faculty_Tbl.Course_ID);
            return View(faculty_Tbl);
        }

        // GET: Faculty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Tbl faculty_Tbl = db.Faculty_Tbl.Find(id);
            if (faculty_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Tbl);
        }

        // POST: Faculty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty_Tbl faculty_Tbl = db.Faculty_Tbl.Find(id);
            db.Faculty_Tbl.Remove(faculty_Tbl);
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