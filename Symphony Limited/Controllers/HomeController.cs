using SymphonyLimited.DbContext;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Symphony_Limited.Controllers
{
    public class HomeController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        //[Route("Home")]
        //[Route("Index")]
        //[Route("")]
        public ActionResult Index()
        {
            ViewBag.ourTeam = db.OurTeam_Tbl.ToList();
            ViewBag.Figure = db.Figure_Tbl.ToList();
            ViewBag.ContactPage = db.ContactPage_Tbl.ToList();
            ViewBag.Gallery = db.Gallery_Tbl.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.whyChooseUs = db.About_Tbl.ToList();
            ViewBag.History = db.History_Tbl.ToList();
            ViewBag.ContactPage = db.ContactPage_Tbl.ToList();
            ViewBag.Gallery = db.Gallery_Tbl.ToList();
            ViewBag.WhatPeopleSay = db.WhatPeopleSay_Tbl.ToList();
            ViewBag.OtherBranches = db.OtherBranches_Tbl.ToList();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.ContactPage = db.ContactPage_Tbl.ToList();
            ViewBag.Gallery = db.Gallery_Tbl.ToList();
            ViewBag.ContactPage = db.ContactPage_Tbl.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactForm_Tbl data)
        {
            if (ModelState.IsValid)
            {
                db.ContactForm_Tbl.Add(data);
                db.SaveChanges();
                ViewBag.ContactPage = db.ContactPage_Tbl.ToList();
                ViewBag.Msg = true;
                ViewBag.ContactPage = db.ContactPage_Tbl.ToList();

                return View();
            }

            return View(data);
        }

        public ActionResult Courses()
        {
            ViewBag.Gallery = db.Gallery_Tbl.ToList();
            ViewBag.ContactPage = db.ContactPage_Tbl.ToList();
            ViewBag.Courses = db.Course_Tbl.ToList();
            ViewBag.Course_Offering = db.Course_Offering_Tbl.ToList();

            ViewBag.whyChooseUs = db.About_Tbl.ToList();
            return View(db.Course_Offering_Tbl.ToList());
        }

        public ActionResult Login()
        {
            ViewBag.ContactPage = db.ContactPage_Tbl.ToList();
            return View();
        }

        public ActionResult searchwork(int id)
        {
            int myid = id;
            Session["myexamid"] = myid;
            var res = db.Result_Tbl.Where(a => a.Exam_ID == id).ToList();
            return View(res);
        }

        //[HttpPost]
        //public ActionResult searchwork(int id,Result_Tbl result,int search)

        //{
        //    int myid = id;
        //    result.Exam_ID = myid;
        //    result.Srudent_ID = search;

        // var res=db.Result_Tbl.Where(a => a.Srudent_ID == search).ToList();

        //    return View(res);
        //}

        public ActionResult exam()
        {
            int stuexamid = Convert.ToInt32(Session["id"]);
            var res = db.Exam_Tbl.Where(a => a.Student_ID == stuexamid);

            return View(res);
        }

        [HttpPost]
        public ActionResult Login(Student_Tbl data)
        {
            if (ModelState.IsValid)
            {
                var email = db.Student_Tbl.Where(x => x.Email2 == data.Email2).SingleOrDefault();
                var password = db.Student_Tbl.Where(x => x.Email2 == data.Email2 && x.Password2 == data.Password2).SingleOrDefault();

                if (email == null)
                {
                    TempData["err"] = "Email Doesn't Exist";
                    return View();
                }

                if (email != null)
                {
                    if (password == null)
                    {
                        TempData["err"] = "Password Is Wrong..!";

                        return View();
                    }

                    var userName = db.Student_Tbl.Where(x => x.Email2 == data.Email2).SingleOrDefault();

                    Session["user"] = userName.Student_Name;
                    Session["id"] = userName.ID;
                    return RedirectToAction("Index");
                }
            }

            TempData["err"] = "Something Went Wrong";

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}