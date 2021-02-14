using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Gallery
        public ActionResult Index()
        {
            return View(db.Gallery_Tbl.ToList());
        }

        // GET: Gallery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Tbl gallery_Tbl = db.Gallery_Tbl.Find(id);
            if (gallery_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Tbl);
        }

        // GET: Gallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Image")] Gallery_Tbl gallery_Tbl, HttpPostedFileBase Picture)
        {
            if (ModelState.IsValid)
            {
                gallery_Tbl.Image = Picture.FileName;
                db.Gallery_Tbl.Add(gallery_Tbl);
                var path = Server.MapPath("~/images/Gallery/" + Picture.FileName + ".jpg");
                Picture.SaveAs(path);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallery_Tbl);
        }

        // GET: Gallery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Tbl gallery_Tbl = db.Gallery_Tbl.Find(id);
            if (gallery_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Tbl);
        }

        // POST: Gallery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Image")] Gallery_Tbl gallery_Tbl, HttpPostedFileBase Picture)
        {
            if (ModelState.IsValid)
            {
                if (Picture != null)
                {
                    gallery_Tbl.Image = Picture.FileName;
                    db.Entry(gallery_Tbl).State = EntityState.Modified;
                    var path = Server.MapPath("~/images/Gallery/" + Picture.FileName + ".jpg");
                    Picture.SaveAs(path);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(gallery_Tbl);
        }

        // GET: Gallery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Tbl gallery_Tbl = db.Gallery_Tbl.Find(id);
            if (gallery_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Tbl);
        }

        // POST: Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery_Tbl gallery_Tbl = db.Gallery_Tbl.Find(id);
            db.Gallery_Tbl.Remove(gallery_Tbl);
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