using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerWebapp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace SBS.Web.Controllers
{
    public class HomeController : Controller
    {
 

            ServiceBookingEntities db = new ServiceEntities3();

            public ActionResult Index()
            {
                return View();

            }

            // GET: User
            public ActionResult Login()
            {
                return View();

            }


            [HttpPost]
            public ActionResult Login(Customer s)
            {
                var User = db.Customers.Where(model => model.EmailId == s.EmailId && model.Password == s.Password).FirstOrDefault();
                if (User != null)
                {

                    ViewBag.customerId = s.Id.ToString();
                    Session["Username"] = s.EmailId.ToString();


                    TempData["loginstatus"] = "<script>alert('login succefully !!')</script>";

                    return RedirectToAction("Create", "appoinments");

                }
                else
                {

                    ViewBag.ErrorMeassage = "<script>alert('email and password does not match !!')</script>";
                }
                return View();
            }


            // Get Register
            public ActionResult register()
            {
                return View();
            }
            [HttpPost]
            public ActionResult register(Customer s)
            {


                if (ModelState.IsValid == true)
                {

                    db.Customers.Add(s);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.InsertMeassage = "<script>alert('register succefully !!')</script>";
                        ModelState.Clear();

                        return RedirectToAction("Vehicle");
                    }
                    else
                    {

                        ViewBag.InsertMeassage = "<script>alert('not register succefully !!')</script>";
                    }

                }
                return View();
            }
            public ActionResult Vehicle()
            {
                ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
                return View();
            }
            [HttpPost]
            public ActionResult Vehicle(Vehicle v)
            {


                if (ModelState.IsValid == true)
                {

                    db.Vehicles.Add(v);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.InsertMeassage = "<script>alert('Vehicle add succefully !!')</script>";
                        ModelState.Clear();
                        ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", v.CustomerId);

                        return RedirectToAction("Login");
                    }
                    else
                    {

                        ViewBag.InsertMeassage = "<script>alert('not add vehicle succefully !!')</script>";
                    }


                }
                return View();
            }

        }
    }
}
}
