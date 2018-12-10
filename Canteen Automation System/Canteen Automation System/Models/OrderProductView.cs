using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Canteen_Automation_System.Models
{
    public class OrderProductView
    {
        
        public int Productid { get; set; }
        public int Orderid { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        [Display(Name = "Product Name")]
        public string Productname { get; set; }
        [Required(ErrorMessage = "Please Select Food Category")]
        [Display(Name = "Category")]
        public string category { get; set; }

        public int quantity { get; set; }
        [Range(1, 1000, ErrorMessage = "Price must be between $1 and $1000")]
        [Display(Name = "Price")]
        public double price { get; set; }

        public virtual Order order { get; set; }
    }
}