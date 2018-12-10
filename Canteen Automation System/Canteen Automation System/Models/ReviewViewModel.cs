using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Canteen_Automation_System.Models
{
    public class ReviewViewModel
    {
        [Required(ErrorMessage = "Please Enter Review about Food")]

        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}