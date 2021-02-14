using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class LabController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Lab
        public ActionResult Index()
        {
            return View(db.Lab_Tbl.ToList());
        }

        // GET: Lab/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_Tbl lab_Tbl = db.Lab_Tbl.Find(id);
            if (lab_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(lab_Tbl);
        }

        // GET: Lab/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lab/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lab_ID,Lab")] Lab_Tbl lab_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Lab_Tbl.Add(lab_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lab_Tbl);
        }

        // GET: Lab/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_Tbl lab_Tbl = db.Lab_Tbl.Find(id);
            if (lab_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(lab_Tbl);
        }

        // POST: Lab/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lab_ID,Lab")] Lab_Tbl lab_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lab_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lab_Tbl);
        }

        // GET: Lab/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_Tbl lab_Tbl = db.Lab_Tbl.Find(id);
            if (lab_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(lab_Tbl);
        }

        // POST: Lab/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lab_Tbl lab_Tbl = db.Lab_Tbl.Find(id);
            db.Lab_Tbl.Remove(lab_Tbl);
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