using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: History
        public ActionResult Index()
        {
            return View(db.History_Tbl.ToList());
        }

        // GET: History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History_Tbl history_Tbl = db.History_Tbl.Find(id);
            if (history_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(history_Tbl);
        }

        // GET: History/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: History/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,History_Title,Since")] History_Tbl history_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.History_Tbl.Add(history_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(history_Tbl);
        }

        // GET: History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History_Tbl history_Tbl = db.History_Tbl.Find(id);
            if (history_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(history_Tbl);
        }

        // POST: History/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,History_Title,Since")] History_Tbl history_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(history_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(history_Tbl);
        }

        // GET: History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            History_Tbl history_Tbl = db.History_Tbl.Find(id);
            if (history_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(history_Tbl);
        }

        // POST: History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            History_Tbl history_Tbl = db.History_Tbl.Find(id);
            db.History_Tbl.Remove(history_Tbl);
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