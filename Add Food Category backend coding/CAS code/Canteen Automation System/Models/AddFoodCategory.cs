using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Canteen_Automation_System.Models
{
    public class AddFoodCategory
    {
        [Required]
        [Display(Name = "Name")]
        public int Categoryid { get; set; }
 
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string description { get; set; }


    }
}