using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Canteen_Automation_System.Models;
using Microsoft.AspNet.Identity;

namespace Canteen_Automation_System.Controllers
{
    public class ChefController : Controller
    {
        private CanteenAutomationSystemDbEntities2 db = new CanteenAutomationSystemDbEntities2();
        // GET: Chef
        public ActionResult Index()
        {
            ViewBag.listProduct = db.Orders.ToList();

            return View();
        }
        public ActionResult DetailsOrder(int Id)
        {
            List<OrderProduct> list = new List<OrderProduct>();
            foreach (OrderProduct p in db.OrderProducts)
            {
                if (p.OrderId == Id)
                {
                    OrderProduct p1 = new OrderProduct();
                    p1.OrderId = p.OrderId;
                    p1.ProductId = p.ProductId;
                    p1.ProductName = p.ProductName;
                    p1.Price = p.Price;
                    p1.Quantity = p.Quantity;

                    list.Add(p1);

                }
            }
            ViewBag.ListProduct = list;

            return View();
        

    }
        // for all the data displaying
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