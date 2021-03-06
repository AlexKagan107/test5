﻿using System;
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
    public class UsersController : Controller
    {
        private test4DBEntities2 db = new test4DBEntities2();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.FavoriteClub = new SelectList(db.Clubs, "ClubName", "ClubName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Password,FavoriteClub")] Users users)
        {

            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                await db.SaveChangesAsync();
                await AddClubToUser2(users.Id, users.FavoriteClub);
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.FavoriteClub = new SelectList(db.Clubs, "ClubName", "ClubName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Password,FavoriteClub")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Users users = await db.Users.FindAsync(id);
        //    db.Users.Remove(users);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Users users = await db.Users.FindAsync(id);
            Clubs[] clubArray = users.Clubs.ToArray<Clubs>();
            for (int i = 0; i < clubArray.Length; i++)
            {
                users.Clubs.Remove(clubArray[i]);
            }
            db.Users.Remove(users);

            await db.SaveChangesAsync();
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

        public ActionResult AddClubToUser()
        {
            ViewBag.ClubName = new SelectList(db.Clubs, "ClubName", "ClubName");
            ViewBag.Id = new SelectList(db.Users, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddClubToUser([Bind(Include = "Id,ClubName")] UserClubModel mode)
        {
            if (ModelState.IsValid)
            {
                Clubs club = await db.Clubs.FindAsync(mode.ClubName);
                Users user = await db.Users.FindAsync(mode.Id);
                user.Clubs.Add(club);
                await db.SaveChangesAsync();
                return RedirectToAction("AddClubToUser");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddClubToUser2(int Id, string ClubName)
        {
            if (ModelState.IsValid)
            {
                Clubs club = await db.Clubs.FindAsync(ClubName);
                Users user = await db.Users.FindAsync(Id);
                user.Clubs.Add(club);
                await db.SaveChangesAsync();
                return RedirectToAction("AddClubToUser");
            }
            return View();
        }



        //סתם הערה
        //מצוין
    }
}
