using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test4.Models;

namespace test4.Controllers
{
    public class UserClubController : Controller
    {
        // GET: UserClub
        public ActionResult Index()
        {
            test4DBEntities2 db = new test4DBEntities2();

            return View();
        }


    }
}