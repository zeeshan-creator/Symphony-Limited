using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class ContactFormsController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: ContactForms
        public ActionResult Index()
        {
            return View(db.ContactForm_Tbl.ToList());
        }

        // GET: ContactForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm_Tbl contactForm_Tbl = db.ContactForm_Tbl.Find(id);
            if (contactForm_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(contactForm_Tbl);
        }

        // GET: ContactForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LastName,Email,Message")] ContactForm_Tbl contactForm_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.ContactForm_Tbl.Add(contactForm_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactForm_Tbl);
        }

        // GET: ContactForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm_Tbl contactForm_Tbl = db.ContactForm_Tbl.Find(id);
            if (contactForm_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(contactForm_Tbl);
        }

        // POST: ContactForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LastName,Email,Message")] ContactForm_Tbl contactForm_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactForm_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactForm_Tbl);
        }

        // GET: ContactForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm_Tbl contactForm_Tbl = db.ContactForm_Tbl.Find(id);
            if (contactForm_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(contactForm_Tbl);
        }

        // POST: ContactForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactForm_Tbl contactForm_Tbl = db.ContactForm_Tbl.Find(id);
            db.ContactForm_Tbl.Remove(contactForm_Tbl);
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