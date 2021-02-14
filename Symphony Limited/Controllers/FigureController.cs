using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class FigureController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Figure
        public ActionResult Index()
        {
            return View(db.Figure_Tbl.ToList());
        }

        // GET: Figure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Figure_Tbl figure_Tbl = db.Figure_Tbl.Find(id);
            if (figure_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(figure_Tbl);
        }

        // GET: Figure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Figure/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Figure")] Figure_Tbl figure_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Figure_Tbl.Add(figure_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(figure_Tbl);
        }

        // GET: Figure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Figure_Tbl figure_Tbl = db.Figure_Tbl.Find(id);
            if (figure_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(figure_Tbl);
        }

        // POST: Figure/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Figure")] Figure_Tbl figure_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(figure_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(figure_Tbl);
        }

        // GET: Figure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Figure_Tbl figure_Tbl = db.Figure_Tbl.Find(id);
            if (figure_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(figure_Tbl);
        }

        // POST: Figure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Figure_Tbl figure_Tbl = db.Figure_Tbl.Find(id);
            db.Figure_Tbl.Remove(figure_Tbl);
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