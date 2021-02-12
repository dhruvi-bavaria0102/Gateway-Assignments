using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiForProductList.Models;
namespace WebApiForProductList.Controllers
{
    public class ProductCrudController : ApiController
    {
        //fetching data
        ProductManagementEntities p = new ProductManagementEntities();
        public IHttpActionResult getproduct()
        {
            var results = p.ProductDetails.ToList();
            return Ok(results);
        }
        //saving data to database
        [HttpPost]
        public IHttpActionResult proinsert(ProductDetail proinsert)
        {
            p.ProductDetails.Add(proinsert);
            p.SaveChanges();
            return Ok();
        }
        //Get product information
        public IHttpActionResult GetProductID(int id)
        {
            Product productdetails = null;
            productdetails = p.ProductDetails.Where(x => x.ID == id).Select(x => new Product()
            {
                ID = x.ID,
                Product_image = x.Product_image,
                CategoryName = x.CategoryName,
                ProductName = x.ProductName,
                Price = x.Price,
                Description = x.Description,
                Quantity = x.Quantity,
            }).FirstOrDefault<Product>();
            if(productdetails == null)
            {
                return NotFound();
            }
            return Ok(productdetails);
        }
        // Inserting product information
        public IHttpActionResult Put(Product pd)
        {
            var updateProduct = p.ProductDetails.Where(x => x.ID == pd.ID).FirstOrDefault<ProductDetail>();
            if ( updateProduct!= null)
            {
                updateProduct.ID = pd.ID;
                updateProduct.Product_image = pd.Product_image;
                updateProduct.CategoryName = pd.CategoryName;
                updateProduct.ProductName = pd.ProductName;
                updateProduct.Price = pd.Price;
                updateProduct.Description = pd.Description;
                updateProduct.Quantity = pd.Quantity;
                p.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var productdel = p.ProductDetails.Where(x => x.ID == id).FirstOrDefault();
            p.Entry(productdel).State = System.Data.Entity.EntityState.Deleted;
            p.SaveChanges();
            return Ok();

        }

    }
}
