using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBS.Data;

namespace SBS.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCustomer(string sidx, string sort, int page, int rows)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var CustomerList = db.Customers.Select(
                    t => new
                    {
                        t.ID,
                        t.Name,
                        t.Address,
                        t.Contact,
                        t.Zipcode,
                        t.HomeContact,
                        t.EmailID,
                        t.Password,
                        t.Problem,
                    }) ;
            int totalRecords = CustomerList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                CustomerList = CustomerList.OrderByDescending(t => t.Name);
                CustomerList = CustomerList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                CustomerList = CustomerList.OrderBy(t => t.Name);
                CustomerList = CustomerList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = CustomerList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Customer Model)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.Name = Guid.NewGuid().ToString();
                    db.Customers.Add(Model);
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

        public string Edit(Customer Model)
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
            Customer customer = db.Customers.Find(Id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }
}