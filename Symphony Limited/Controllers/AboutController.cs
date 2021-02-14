using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: About
        public ActionResult Index()
        {
            ;
            return View(db.About_Tbl.ToList());
        }

        // GET: About/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About_Tbl about_Tbl = db.About_Tbl.Find(id);
            if (about_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(about_Tbl);
        }

        // GET: About/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: About/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description")] About_Tbl about_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.About_Tbl.Add(about_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about_Tbl);
        }

        // GET: About/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About_Tbl about_Tbl = db.About_Tbl.Find(id);
            if (about_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(about_Tbl);
        }

        // POST: About/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description")] About_Tbl about_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(about_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about_Tbl);
        }

        // GET: About/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About_Tbl about_Tbl = db.About_Tbl.Find(id);
            if (about_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(about_Tbl);
        }

        // POST: About/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            About_Tbl about_Tbl = db.About_Tbl.Find(id);
            db.About_Tbl.Remove(about_Tbl);
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