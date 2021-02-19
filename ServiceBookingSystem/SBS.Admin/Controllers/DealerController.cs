using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBS.Data;

namespace SBS.Admin.Controllers
{
    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDealer(string sidx, string sort, int page, int rows)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var DealerList = db.Dealers.Select(
                    t => new
                    {
                        t.ID,
                        t.DealerName,
                        t.Address,
                        t.Contact,
                        t.Zipcode,
                        t.DealerNumber,
                        t.EmailID,
                        
                    });
            int totalRecords = DealerList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                DealerList = DealerList.OrderByDescending(t => t.DealerName);
                DealerList = DealerList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                DealerList = DealerList.OrderBy(t => t.DealerName);
                DealerList = DealerList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = DealerList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Dealer Model)
        {
            ServiceBookingSystemEntities db = new ServiceBookingSystemEntities();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.DealerName = Guid.NewGuid().ToString();
                    db.Dealers.Add(Model);
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

        public string Edit(Dealer Model)
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
            Dealer dealer = db.Dealers.Find(Id);
            db.Dealers.Remove(dealer);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }
}