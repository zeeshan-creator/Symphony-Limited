using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class ResultController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Result
        public ActionResult Index()
        {
            var result_Tbl = db.Result_Tbl.Include(r => r.Exam_Tbl).Include(r => r.Student_Tbl);
            return View(result_Tbl.ToList());
        }

        // GET: Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result_Tbl result_Tbl = db.Result_Tbl.Find(id);
            if (result_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(result_Tbl);
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            ViewBag.Exam_ID = new SelectList(db.Exam_Tbl, "ID", "Exam");
            ViewBag.Srudent_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name");
            return View();
        }

        // POST: Result/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Exam_ID,Srudent_ID,GPA,Grade,Status")] Result_Tbl result_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Result_Tbl.Add(result_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Exam_ID = new SelectList(db.Exam_Tbl, "ID", "Exam", result_Tbl.Exam_ID);
            ViewBag.Srudent_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name", result_Tbl.Srudent_ID);
            return View(result_Tbl);
        }

        // GET: Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result_Tbl result_Tbl = db.Result_Tbl.Find(id);
            if (result_Tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Exam_ID = new SelectList(db.Exam_Tbl, "ID", "Exam", result_Tbl.Exam_ID);
            ViewBag.Srudent_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name", result_Tbl.Srudent_ID);
            return View(result_Tbl);
        }

        // POST: Result/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Exam_ID,Srudent_ID,GPA,Grade,Status")] Result_Tbl result_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Exam_ID = new SelectList(db.Exam_Tbl, "ID", "Exam", result_Tbl.Exam_ID);
            ViewBag.Srudent_ID = new SelectList(db.Student_Tbl, "ID", "Student_Name", result_Tbl.Srudent_ID);
            return View(result_Tbl);
        }

        // GET: Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result_Tbl result_Tbl = db.Result_Tbl.Find(id);
            if (result_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(result_Tbl);
        }

        // POST: Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Result_Tbl result_Tbl = db.Result_Tbl.Find(id);
            db.Result_Tbl.Remove(result_Tbl);
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