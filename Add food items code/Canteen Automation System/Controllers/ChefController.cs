using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canteen_Automation_System.Controllers
{
    public class ChefController : Controller
    {
        // GET: Chef
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetailsOrder()
        {

            return View();
        }
        public ActionResult PendingOrders()
        {

            return View();
        }
        public ActionResult CompletedOrders()
        {

            return View();
        }

    }
}