using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canteen_Automation_System.Models
{
    public class OrderProductView
    {
        public int Productid { get; set; }
        public int Orderid { get; set; }
        public string Productname { get; set; }
        public string category { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public virtual Order order { get; set; }
    }
}