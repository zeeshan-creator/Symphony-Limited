using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class OurTeamController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: OurTeam
        public ActionResult Index()
        {
            return View(db.OurTeam_Tbl.ToList());
        }

        // GET: OurTeam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam_Tbl ourTeam_Tbl = db.OurTeam_Tbl.Find(id);
            if (ourTeam_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(ourTeam_Tbl);
        }

        // GET: OurTeam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OurTeam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Role")] OurTeam_Tbl ourTeam_Tbl, HttpPostedFileBase ProfilePicture)
        {
            if (ProfilePicture == null)
            {
                if (ModelState.IsValid)
                {
                    db.OurTeam_Tbl.Add(ourTeam_Tbl);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.OurTeam_Tbl.Add(ourTeam_Tbl);
                    var path = Server.MapPath("~/images/Profiles/" + "_" + ourTeam_Tbl.Title + "_" + ".jpg");
                    ProfilePicture.SaveAs(path);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(ourTeam_Tbl);
        }

        // GET: OurTeam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam_Tbl ourTeam_Tbl = db.OurTeam_Tbl.Find(id);
            if (ourTeam_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(ourTeam_Tbl);
        }

        // POST: OurTeam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Role")] OurTeam_Tbl ourTeam_Tbl, HttpPostedFileBase ProfilePicture)
        {
            if (ProfilePicture == null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ourTeam_Tbl).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ourTeam_Tbl).State = EntityState.Modified;
                    var path = Server.MapPath("~/images/Profiles/" + "_" + ourTeam_Tbl.Title + "_" + ".jpg");
                    ProfilePicture.SaveAs(path);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(ourTeam_Tbl);
        }

        // GET: OurTeam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeam_Tbl ourTeam_Tbl = db.OurTeam_Tbl.Find(id);
            if (ourTeam_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(ourTeam_Tbl);
        }

        // POST: OurTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurTeam_Tbl ourTeam_Tbl = db.OurTeam_Tbl.Find(id);
            db.OurTeam_Tbl.Remove(ourTeam_Tbl);
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