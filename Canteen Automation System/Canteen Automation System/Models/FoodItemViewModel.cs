using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Canteen_Automation_System.Models
{
    public class FoodItemViewModel
    {
        [Required(ErrorMessage = "Please Select Food Category")]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Enter Food Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Range(1, 1000, ErrorMessage = "Price must be between $1 and $1000")]
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}