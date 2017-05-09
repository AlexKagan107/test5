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
    public class UserClubController : Controller
    {
        private test4DBEntities2 db = new test4DBEntities2();
        // GET: UserClub

        public async Task<ActionResult> Index()
        {
            //ViewBag.userclub = db.UserClubModels.ToArray();
            //HttpContext.Session.Add("userclub", db.UserClubModels.ToArray());
            return View(await db.UserClubModels.ToListAsync());
        }


    }
}