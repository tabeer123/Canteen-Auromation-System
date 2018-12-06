using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canteen_Automation_System.Models
{
    public class AccountViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RegisterAs { get; set; }
    }
}