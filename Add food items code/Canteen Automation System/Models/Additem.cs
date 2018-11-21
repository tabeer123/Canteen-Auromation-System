using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Canteen_Automation_System.Models
{
    public class Additem
    {
        [Required]
        [Display(Name = "Food ID")]
        public int FoodId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}