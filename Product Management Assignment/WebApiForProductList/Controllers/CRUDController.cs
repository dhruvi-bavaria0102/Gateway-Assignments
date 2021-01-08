using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForProductList.Models;
using System.Net.Http;
using System.IO;

namespace WebApiForProductList.Controllers
{
    public class CRUDController : Controller
    {
        ProductManagementEntities db = new ProductManagementEntities();
        // GET: CRUD
        public ActionResult Index(string Sorting_Order)
        {
            
            IEnumerable<ProductDetail> proobj = null;
            HttpClient h = new HttpClient();
            h.BaseAddress = new Uri("https://localhost:44366/api/ProductCrud");

            var consumeapi = h.GetAsync("ProductCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if(readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<ProductDetail>>();
                displaydata.Wait();

                proobj = displaydata.Result;
             }
             return View(proobj);
        }
       public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, ProductDetail insertproduct)
        {

            string filename = Path.GetFileName(file.FileName);

            //string _filename = DateTime.Now.ToString("yymmssff") + filename;
            string extension = Path.GetExtension(file.FileName);

            string path = Path.Combine(Server.MapPath("~/images/"), filename);
            insertproduct.Product_image = "~/images/" + filename;

            if(extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png")
            {
                if(file.ContentLength<=2000000)
                {
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("https://localhost:44366/api/ProductCrud");

                    var insertrecord = hc.PostAsJsonAsync<ProductDetail>("ProductCrud", insertproduct);
                    insertrecord.Wait();

                    var savedata= insertrecord.Result;
                    if (savedata.IsSuccessStatusCode)
                    {
                        file.SaveAs(path);
                        TempData["inserted product successfully"] = "New Record Added";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["failed to add product"] = "Failed to add product try again";
                        return RedirectToAction("Create");
                    }

                }
            }
            return View("Create");

        }

        public ActionResult Details(int id)
        {
            Product proobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44366/api/");

            var consumeapi = hc.GetAsync("ProductCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if(readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<Product>();
                displaydata.Wait();
                proobj = displaydata.Result;
            }
            return View(proobj);

        }

        public ActionResult Edit(int id)
        {
            Product proobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44366/api/");

            var consumeapi = hc.GetAsync("ProductCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<Product>();
                displaydata.Wait();
                proobj = displaydata.Result;
            }
            return View(proobj);
        }
        [HttpPost]
        public ActionResult Edit(Product pd)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44366/api/ProductCrud");

            var insertrecord = hc.PutAsJsonAsync<Product>("ProductCrud", pd);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Employee Record not updated....";
            }
            return View(pd);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44366/api/ProductCrud");

            var delrecord = hc.DeleteAsync("ProductCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if( displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            
            }
            return View("Index");

        }
    }
}