using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBS.Data;

namespace SBS.Admin.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetVehicle(string sidx, string sort, int page, int rows)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var VehicleList = db.Vehicles.Select(
                    t => new
                    {
                        t.ID,
                        t.LicensePlate,
                        t.Make,
                        t.Model,
                        t.RegistrationDate,
                        t.ChassisNumber,
                        t.OwnerName,
                        t.CustomerID,
                        
                    });
            int totalRecords = VehicleList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                VehicleList = VehicleList.OrderByDescending(t => t.RegistrationDate);
                VehicleList = VehicleList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                VehicleList = VehicleList.OrderBy(t => t.RegistrationDate);
                VehicleList = VehicleList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = VehicleList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Vehicle Model)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.LicensePlate = Guid.NewGuid().ToString();
                    db.Vehicles.Add(Model);
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfully";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public string Edit(Vehicle Model)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Model).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfully";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Delete(string Id)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            Vehicle vehicle = db.Vehicles.Find(Id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }
}