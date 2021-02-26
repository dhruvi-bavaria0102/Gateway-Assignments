using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBS.Data;
using System.Data.Entity;

namespace SBS.Admin.Controllers
{
    public class MechanicController : Controller
    {
        // GET: Mechanic
        public class DealerController : Controller
        {
            // GET: Dealer
            public ActionResult Index()
            {
                return View();
            }
            public JsonResult GetMechanic(string sidx, string sort, int page, int rows)
            {
                ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
                sort = (sort == null) ? "" : sort;
                int pageIndex = Convert.ToInt32(page) - 1;
                int pageSize = rows;

                var MechanicList = db.Mechanics.Select(
                        t => new
                        {
                            t.ID,
                            t.Name,
                            t.MechanicNumber,
                            t.Contact,
                            t.ServiceID,
                            t.EmailID,

                        });
                int totalRecords = MechanicList.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sort.ToUpper() == "DESC")
                {
                    MechanicList = MechanicList.OrderByDescending(t => t.Name);
                    MechanicList = MechanicList.Skip(pageIndex * pageSize).Take(pageSize);
                }
                else
                {
                    MechanicList = MechanicList.OrderBy(t => t.Name);
                    MechanicList = MechanicList.Skip(pageIndex * pageSize).Take(pageSize);
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = MechanicList
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            [HttpPost]
            public string Create([Bind(Exclude = "Id")] Mechanic Model)
            {
                ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
                string msg;
                try
                {
                    if (ModelState.IsValid)
                    {
                        Model.Name = Guid.NewGuid().ToString();
                        db.Mechanics.Add(Model);
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

            public string Edit(Mechanic Model)
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
                Mechanic mechanic = db.Mechanics.Find(Id);
                db.Mechanics.Remove(mechanic);
                db.SaveChanges();
                return "Deleted successfully";
            }
        }
}