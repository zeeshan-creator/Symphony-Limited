using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class FAQController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: FAQ
        public ActionResult Index()
        {
            return View(db.FAQ_Tbl.ToList());
        }

        // GET: FAQ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQ_Tbl fAQ_Tbl = db.FAQ_Tbl.Find(id);
            if (fAQ_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(fAQ_Tbl);
        }

        // GET: FAQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FAQ/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Question,Answer")] FAQ_Tbl fAQ_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.FAQ_Tbl.Add(fAQ_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fAQ_Tbl);
        }

        // GET: FAQ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQ_Tbl fAQ_Tbl = db.FAQ_Tbl.Find(id);
            if (fAQ_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(fAQ_Tbl);
        }

        // POST: FAQ/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Question,Answer")] FAQ_Tbl fAQ_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAQ_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAQ_Tbl);
        }

        // GET: FAQ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQ_Tbl fAQ_Tbl = db.FAQ_Tbl.Find(id);
            if (fAQ_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(fAQ_Tbl);
        }

        // POST: FAQ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAQ_Tbl fAQ_Tbl = db.FAQ_Tbl.Find(id);
            db.FAQ_Tbl.Remove(fAQ_Tbl);
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