using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class OtherBranchesController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: OtherBranches
        public ActionResult Index()
        {
            return View(db.OtherBranches_Tbl.ToList());
        }

        // GET: OtherBranches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherBranches_Tbl otherBranches_Tbl = db.OtherBranches_Tbl.Find(id);
            if (otherBranches_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(otherBranches_Tbl);
        }

        // GET: OtherBranches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtherBranches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Branch,Location,Telephone")] OtherBranches_Tbl otherBranches_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.OtherBranches_Tbl.Add(otherBranches_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(otherBranches_Tbl);
        }

        // GET: OtherBranches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherBranches_Tbl otherBranches_Tbl = db.OtherBranches_Tbl.Find(id);
            if (otherBranches_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(otherBranches_Tbl);
        }

        // POST: OtherBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Branch,Location,Telephone")] OtherBranches_Tbl otherBranches_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherBranches_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otherBranches_Tbl);
        }

        // GET: OtherBranches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherBranches_Tbl otherBranches_Tbl = db.OtherBranches_Tbl.Find(id);
            if (otherBranches_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(otherBranches_Tbl);
        }

        // POST: OtherBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OtherBranches_Tbl otherBranches_Tbl = db.OtherBranches_Tbl.Find(id);
            db.OtherBranches_Tbl.Remove(otherBranches_Tbl);
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