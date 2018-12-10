using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Canteen_Automation_System.Models
{
    public class FoodCategoryViewModel
    {
        [Required(ErrorMessage = "Please Enter Name of Food Category")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Food Category Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}