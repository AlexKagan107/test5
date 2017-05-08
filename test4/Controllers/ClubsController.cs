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
    public class ClubsController : Controller
    {
        private test4DBEntities2 db = new test4DBEntities2();

        // GET: Clubs
        public async Task<ActionResult> Index()
        {
            return View(await db.Clubs.ToListAsync());
        }

        // GET: Clubs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubs clubs = await db.Clubs.FindAsync(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ClubName,LigaName,HomeStad")] Clubs clubs)
        {
            if (ModelState.IsValid)
            {
                db.Clubs.Add(clubs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clubs);
        }

        // GET: Clubs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubs clubs = await db.Clubs.FindAsync(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClubName,LigaName,HomeStad")] Clubs clubs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clubs);
        }

        // GET: Clubs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubs clubs = await db.Clubs.FindAsync(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Clubs clubs = await db.Clubs.FindAsync(id);
            db.Clubs.Remove(clubs);
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
    }
}
