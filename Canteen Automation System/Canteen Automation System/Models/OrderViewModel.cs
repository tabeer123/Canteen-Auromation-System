using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canteen_Automation_System.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public System.DateTime Date { get; set; }
        public double Bill { get; set; }
        public int Items { get; set; }
        public string Status { get; set; }
    }
}