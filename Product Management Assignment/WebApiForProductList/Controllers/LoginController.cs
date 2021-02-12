using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForProductList.Models;

namespace WebApiForProductList.Controllers
{
    public class LoginController : Controller
    {
        ProductManagementEntities db = new ProductManagementEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public LoginClass GetProductByID(string v)
        {
            throw new NotImplementedException();
        }
        // login for admin
        [HttpPost]
        public ActionResult Index(login s)
        {
            if(ModelState.IsValid == true)
            {
                //checking if login details matches the sql table details to authorize login
                var credentials = db.logins.Where(model => model.Username == s.Username && model.Password == s.Password).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return View();
                }
                else
                {
                    Session["Username"] = s.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        //logging out of the application
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
        //to reset the details entered in login page if they are entered incorrectly
        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}