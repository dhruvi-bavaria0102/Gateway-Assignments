using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerWebapp1.Models;
using SBS.Data;

namespace CustomerWebapp1.Controllers
{
    public class appoinmentsController : Controller
    {
        ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();

        // GET: appoinments
        public ActionResult Index()
        {
            var appoinments = db.appoinments.Include(a => a.Customer).Include(a => a.Mechanic).Include(a => a.Service1).Include(a => a.Vehicle);
            return View(appoinments.ToList());
        }

        // GET: appoinments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appoinment appoinment = db.appoinments.Find(id);
            if (appoinment == null)
            {
                return HttpNotFound();
            }
            return View(appoinment);
        }

        // GET: appoinments/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.MechanicId = new SelectList(db.Mechanics, "Id", "MechanicName");
            ViewBag.ServiceId = new SelectList(db.Service1, "Id", "ServiceName");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "License_Plate", "Chassis_No");
            return View();
        }

        // POST: appoinments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CustomerId,Customercontact,ServiceId,VehicleId,MechanicId")] appoinment appoinment)
        {
            if (ModelState.IsValid)
            {
                db.appoinments.Add(appoinment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", appoinment.CustomerId);
            ViewBag.MechanicId = new SelectList(db.Mechanics, "Id", "MechanicName", appoinment.MechanicId);
            ViewBag.ServiceId = new SelectList(db.Service1, "Id", "ServiceName", appoinment.ServiceId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "License_Plate", "Chassis_No", appoinment.VehicleId);
            return View(appoinment);
        }

        // GET: appoinments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appoinment appoinment = db.appoinments.Find(id);
            if (appoinment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", appoinment.CustomerId);
            ViewBag.MechanicId = new SelectList(db.Mechanics, "Id", "MechanicName", appoinment.MechanicId);
            ViewBag.ServiceId = new SelectList(db.Service1, "Id", "ServiceName", appoinment.ServiceId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "License_Plate", "Chassis_No", appoinment.VehicleId);
            return View(appoinment);
        }

        // POST: appoinments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CustomerId,Customercontact,ServiceId,VehicleId,MechanicId")] appoinment appoinment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appoinment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", appoinment.CustomerId);
            ViewBag.MechanicId = new SelectList(db.Mechanics, "Id", "MechanicName", appoinment.MechanicId);
            ViewBag.ServiceId = new SelectList(db.Service1, "Id", "ServiceName", appoinment.ServiceId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "License_Plate", "Chassis_No", appoinment.VehicleId);
            return View(appoinment);
        }

        // GET: appoinments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appoinment appoinment = db.appoinments.Find(id);
            if (appoinment == null)
            {
                return HttpNotFound();
            }
            return View(appoinment);
        }

        // POST: appoinments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appoinment appoinment = db.appoinments.Find(id);
            db.appoinments.Remove(appoinment);
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