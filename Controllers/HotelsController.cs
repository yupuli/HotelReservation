using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    public class HotelsController : Controller
    {
        private FIT5032_Model db = new FIT5032_Model();

        // GET: Hotels
        public ActionResult Index()
        {
            var hotels = db.Hotels.Include(h => h.Owners);
            return View(hotels.ToList());
        }

        // GET: Hotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "FirstName");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Address,Description,OwnerId")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "FirstName", hotels.OwnerId);
            return View(hotels);
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "FirstName", hotels.OwnerId);
            return View(hotels);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Address,Description,OwnerId")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "FirstName", hotels.OwnerId);
            return View(hotels);
        }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotels hotels = db.Hotels.Find(id);
            db.Hotels.Remove(hotels);
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
