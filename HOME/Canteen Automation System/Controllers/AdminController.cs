using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canteen_Automation_System.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
      

        public ActionResult ManageFoodItems()
        {
            return View();
        }
        public ActionResult AddFoodItems()
        {
            return View();
        }


        public ActionResult ManageFoodCategories()
        {
            return View();
        }
        public ActionResult AddFoodCategories()
        {
            return View();
        }
        public ActionResult OrdersReport()
        {
            return View();
        }
        public ActionResult Reviews()
        {
            return View();
        }
        
    }
}