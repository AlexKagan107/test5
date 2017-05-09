using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test4.Models;

namespace test4.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> LoginUser(Users model)
        {
            test4DBEntities2 db = new test4DBEntities2();
            Users user = await db.Users.SingleOrDefaultAsync(x => x.Id == model.Id && x.Password == model.Password);
            string result = "fail";
            if (user != null)
            {
                Session["UserId"] = user.Id;
                Session["UserName"] = user.Name;

                result = "GeneralUser";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}