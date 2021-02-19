using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBS.Data;
using System.Data.Entity;

namespace SBS.Admin.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetService(string sidx, string sort, int page, int rows)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var ServiceList = db.Services.Select(
                    t => new
                    {
                        t.ID,
                        t.ServiceName,
                        t.Price,
                        t.Duration,
                        t.Active

                    });
            int totalRecords = ServiceList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                ServiceList = ServiceList.OrderByDescending(t => t.ServiceName);
                ServiceList = ServiceList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                ServiceList = ServiceList.OrderBy(t => t.ServiceName);
                ServiceList = ServiceList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = ServiceList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Service Model)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.ServiceName = Guid.NewGuid().ToString();
                    db.Services.Add(Model);
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

        public string Edit(Service Model)
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
           Service service = db.Services.Find(Id);
            db.Services.Remove(service);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }
}