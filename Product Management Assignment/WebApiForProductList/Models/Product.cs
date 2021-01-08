using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiForProductList.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Product_image { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
    }
}