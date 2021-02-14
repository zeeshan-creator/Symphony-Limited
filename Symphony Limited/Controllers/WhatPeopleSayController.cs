using SymphonyLimited.DbContext;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    [Authorize]
    public class WhatPeopleSayController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: WhatPeopleSay
        public ActionResult Index()
        {
            return View(db.WhatPeopleSay_Tbl.ToList());
        }

        // GET: WhatPeopleSay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhatPeopleSay_Tbl whatPeopleSay_Tbl = db.WhatPeopleSay_Tbl.Find(id);
            if (whatPeopleSay_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(whatPeopleSay_Tbl);
        }

        // GET: WhatPeopleSay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhatPeopleSay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Role")] WhatPeopleSay_Tbl whatPeopleSay_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.WhatPeopleSay_Tbl.Add(whatPeopleSay_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(whatPeopleSay_Tbl);
        }

        // GET: WhatPeopleSay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhatPeopleSay_Tbl whatPeopleSay_Tbl = db.WhatPeopleSay_Tbl.Find(id);
            if (whatPeopleSay_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(whatPeopleSay_Tbl);
        }

        // POST: WhatPeopleSay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Role")] WhatPeopleSay_Tbl whatPeopleSay_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whatPeopleSay_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whatPeopleSay_Tbl);
        }

        // GET: WhatPeopleSay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhatPeopleSay_Tbl whatPeopleSay_Tbl = db.WhatPeopleSay_Tbl.Find(id);
            if (whatPeopleSay_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(whatPeopleSay_Tbl);
        }

        // POST: WhatPeopleSay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WhatPeopleSay_Tbl whatPeopleSay_Tbl = db.WhatPeopleSay_Tbl.Find(id);
            db.WhatPeopleSay_Tbl.Remove(whatPeopleSay_Tbl);
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