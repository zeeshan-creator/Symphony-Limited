using SymphonyLimited.DbContext;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Symphony_Limited.Controllers
{
    public class AdminController : Controller
    {
        private Symphony_LimitedEntities db = new Symphony_LimitedEntities();

        // GET: Admin
        //[Route("Dashboard")]
        [Authorize]
        public ActionResult Index() => View();

        public ActionResult About() => View();

        public ActionResult Contact() => View();

        [AllowAnonymous]
        //[Route("Login")]
        public ActionResult Login() => View();

        //[Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Admin_Tbl data)
        {
            var email = db.Admin_Tbl.Where(x => x.Email == data.Email).SingleOrDefault();
            var password = db.Admin_Tbl.Where(x => x.Email == data.Email && x.Password == data.Password).SingleOrDefault();

            if (email == null)
            {
                TempData["msg"] = "Email Doesn't Exist";
                return View();
            }

            if (email != null)
            {
                if (password == null)
                {
                    TempData["msg"] = "Password Is Wrong..!";

                    return View();
                }

                var AdminName = db.Admin_Tbl.Where(x => x.Email == data.Email).SingleOrDefault();

                Session["user"] = AdminName.Admin;

                FormsAuthentication.SetAuthCookie(AdminName.Admin, false);

                return RedirectToAction("Index");
            }

            TempData["msg"] = "Something Went Wrong";

            return View();
        }

        public ActionResult logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}