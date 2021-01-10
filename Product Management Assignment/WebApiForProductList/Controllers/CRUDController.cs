using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiForProductList.Models;
using System.Net.Http;
using System.IO;
using PagedList;

namespace WebApiForProductList.Controllers
{
    public class CRUDController : Controller
    {
        ProductManagementEntities db = new ProductManagementEntities();
        // GET: CRUD
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            IEnumerable<ProductDetail> proobj = null;
            HttpClient h = new HttpClient();
            h.BaseAddress = new Uri("https://localhost:44366/api/ProductCrud");

            var consumeapi = h.GetAsync("ProductCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<ProductDetail>>();
                displaydata.Wait();

                proobj = displaydata.Result;
            }

            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.ProductName = String.IsNullOrEmpty(Sorting_Order) ? "ProductName" : "";
            ViewBag.CategoryName = String.IsNullOrEmpty(Sorting_Order) ? "CategoryName" : "";
            

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            var prod = from prodt in db.ProductDetails select prodt;

            if (!String.IsNullOrEmpty(Search_Data))
            {
                prod = prod.Where(prodt => prodt.ProductName.ToUpper().Contains(Search_Data.ToUpper())
                    || prodt.CategoryName.ToUpper().Contains(Search_Data.ToUpper()));
            }

            switch (Sorting_Order)
            {
                case "ProductName":
                    prod = prod.OrderByDescending(x => x.ProductName);
                    break;
                case "CategoryName":
                    prod = prod.OrderByDescending(x => x.CategoryName);
                    break;
                case "Category":
                    prod = prod.OrderBy(x => x.CategoryName);
                    break;
                default:
                    prod = prod.OrderBy(prodt => prodt.ID);
                    break;
            }

            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);

            return View(prod.ToPagedList(No_Of_Page, Size_Of_Page));
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

            if (extension.ToLower() == ".jpeg" || extension.ToLower() == ".jpg" || extension.ToLower() == ".png")
            {
                if (file.ContentLength <= 2000000)
                {
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("https://localhost:44366/api/ProductCrud");

                    var insertrecord = hc.PostAsJsonAsync<ProductDetail>("ProductCrud", insertproduct);
                    insertrecord.Wait();

                    var savedata = insertrecord.Result;
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
            if (readdata.IsSuccessStatusCode)
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

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> ID)
        {
            int delsuccessfully = 0, delFailed = 0;
            foreach (var item in ID)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44366/api/ProductCrud");

                var delrecord = hc.DeleteAsync("ProductCrud/" + item);
                delrecord.Wait();

                var displaydata = delrecord.Result;
                if (displaydata.IsSuccessStatusCode)
                {
                    delsuccessfully++;
                    TempData["SuccessCount"] = delsuccessfully + "records deleted successfully";

                }
                else
                {
                    delFailed++;
                }
            
            if( delsuccessfully == ID.Count())
            {
                TempData["SuccessCount"] = delsuccessfully + "records deleted successfully";
             }
            else
            {
                TempData["FailedCount"] = delsuccessfully + "records failed to delete successfully";
            }
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Deleteone(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44366/api/ProductCrud");

            var delrecord = hc.DeleteAsync("ProductCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        
    }
}