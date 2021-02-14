using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class ContactPageController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: ContactPage
        public ActionResult Index()
        {
            return View(db.ContactPage_Tbl.ToList());
        }

        // GET: ContactPage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPage_Tbl contactPage_Tbl = db.ContactPage_Tbl.Find(id);
            if (contactPage_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(contactPage_Tbl);
        }

        // GET: ContactPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Telephone,Address,Email")] ContactPage_Tbl contactPage_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.ContactPage_Tbl.Add(contactPage_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactPage_Tbl);
        }

        // GET: ContactPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPage_Tbl contactPage_Tbl = db.ContactPage_Tbl.Find(id);
            if (contactPage_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(contactPage_Tbl);
        }

        // POST: ContactPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Telephone,Address,Email")] ContactPage_Tbl contactPage_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactPage_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactPage_Tbl);
        }

        // GET: ContactPage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPage_Tbl contactPage_Tbl = db.ContactPage_Tbl.Find(id);
            if (contactPage_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(contactPage_Tbl);
        }

        // POST: ContactPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactPage_Tbl contactPage_Tbl = db.ContactPage_Tbl.Find(id);
            db.ContactPage_Tbl.Remove(contactPage_Tbl);
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