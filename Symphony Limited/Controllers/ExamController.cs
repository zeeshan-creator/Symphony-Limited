using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Exam
        public ActionResult Index()
        {
            var exam_Tbl = db.Exam_Tbl.Include(e => e.Faculty_Tbl).Include(e => e.Student_Tbl);
            return View(exam_Tbl.ToList());
        }

        // GET: Exam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Tbl exam_Tbl = db.Exam_Tbl.Find(id);
            if (exam_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(exam_Tbl);
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            ViewBag.Faculty_ID = new SelectList(db.Faculty_Tbl, "ID", "Name");
            ViewBag.Student_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name");
            return View();
        }

        // POST: Exam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Exam,Exam_Date,Faculty_ID,Student_ID")] Exam_Tbl exam_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Exam_Tbl.Add(exam_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Faculty_ID = new SelectList(db.Faculty_Tbl, "ID", "Name", exam_Tbl.Faculty_ID);
            ViewBag.Student_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name", exam_Tbl.Student_ID);
            return View(exam_Tbl);
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Tbl exam_Tbl = db.Exam_Tbl.Find(id);
            if (exam_Tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Faculty_ID = new SelectList(db.Faculty_Tbl, "ID", "Name", exam_Tbl.Faculty_ID);
            ViewBag.Student_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name", exam_Tbl.Student_ID);
            return View(exam_Tbl);
        }

        // POST: Exam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Exam,Exam_Date,Faculty_ID,Student_ID")] Exam_Tbl exam_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Faculty_ID = new SelectList(db.Faculty_Tbl, "ID", "Name", exam_Tbl.Faculty_ID);
            ViewBag.Student_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name", exam_Tbl.Student_ID);
            return View(exam_Tbl);
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Tbl exam_Tbl = db.Exam_Tbl.Find(id);
            if (exam_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(exam_Tbl);
        }

        // POST: Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam_Tbl exam_Tbl = db.Exam_Tbl.Find(id);
            db.Exam_Tbl.Remove(exam_Tbl);
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