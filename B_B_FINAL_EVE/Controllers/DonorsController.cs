using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using B_B_FINAL_EVE.Models;

namespace B_B_FINAL_EVE.Controllers
{
    public class DonorsController : Controller
    {
        private BloodBankEveningEntities db = new BloodBankEveningEntities();

        // GET: Donors
        public ActionResult Index()
        {
            var donors = db.Donors.Include(d => d.BloodGroup).Include(d => d.District).Include(d => d.Thana);
            return View(donors.ToList());
        }

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // GET: Donors/Create
        public ActionResult Create()
        {
            ViewBag.Group_ID = new SelectList(db.BloodGroups, "ID", "Name");
            ViewBag.District_ID = new SelectList(db.Districts, "DistrictID", "DistrictName");
            ViewBag.Thana_ID = new SelectList(db.Thanas, "Thana_ID", "ThanaName");
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Donor_ID,DonorName,Group_ID,District_ID,Thana_ID,ContactNumber,Email,LastDonationDate,Status")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(donor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Group_ID = new SelectList(db.BloodGroups, "ID", "Name", donor.Group_ID);
            ViewBag.District_ID = new SelectList(db.Districts, "DistrictID", "DistrictName", donor.District_ID);
            ViewBag.Thana_ID = new SelectList(db.Thanas, "Thana_ID", "ThanaName", donor.Thana_ID);
            return View(donor);
        }

        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Group_ID = new SelectList(db.BloodGroups, "ID", "Name", donor.Group_ID);
            ViewBag.District_ID = new SelectList(db.Districts, "DistrictID", "DistrictName", donor.District_ID);
            ViewBag.Thana_ID = new SelectList(db.Thanas, "Thana_ID", "ThanaName", donor.Thana_ID);
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Donor_ID,DonorName,Group_ID,District_ID,Thana_ID,ContactNumber,Email,LastDonationDate,Status")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Group_ID = new SelectList(db.BloodGroups, "ID", "Name", donor.Group_ID);
            ViewBag.District_ID = new SelectList(db.Districts, "DistrictID", "DistrictName", donor.District_ID);
            ViewBag.Thana_ID = new SelectList(db.Thanas, "Thana_ID", "ThanaName", donor.Thana_ID);
            return View(donor);
        }

        // GET: Donors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor donor = db.Donors.Find(id);
            db.Donors.Remove(donor);
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
