using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnockoutSeatReservation.Models;

namespace KnockoutSeatReservation.Controllers
{
    public class SeatReservationsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: SeatReservations
        public ActionResult Index()
        {
            var seatReservations = db.SeatReservations.Include(s => s.Meal);
            return View(seatReservations.ToList());
        }

        // GET: SeatReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatReservation seatReservation = db.SeatReservations.Find(id);
            if (seatReservation == null)
            {
                return HttpNotFound();
            }
            return View(seatReservation);
        }

        // GET: SeatReservations/Create
        public ActionResult Create()
        {
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name");
            return View();
        }

        // POST: SeatReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MealId")] SeatReservation seatReservation)
        {
            if (ModelState.IsValid)
            {
                db.SeatReservations.Add(seatReservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", seatReservation.MealId);
            return View(seatReservation);
        }

        // GET: SeatReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatReservation seatReservation = db.SeatReservations.Find(id);
            if (seatReservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", seatReservation.MealId);
            return View(seatReservation);
        }

        // POST: SeatReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MealId")] SeatReservation seatReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seatReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MealId = new SelectList(db.Meals, "Id", "Name", seatReservation.MealId);
            return View(seatReservation);
        }

        // GET: SeatReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatReservation seatReservation = db.SeatReservations.Find(id);
            if (seatReservation == null)
            {
                return HttpNotFound();
            }
            return View(seatReservation);
        }

        // POST: SeatReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeatReservation seatReservation = db.SeatReservations.Find(id);
            db.SeatReservations.Remove(seatReservation);
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
