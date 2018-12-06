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
        private CanteenAutomationSystemDbEntities3 db = new CanteenAutomationSystemDbEntities3();
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
            List<Order> po = new List<Order>();
            foreach(Order p in db.Orders)
            {
                if(p.Status == "pending")
                {
                    Order p1 = new Order();
                    p1.OrderId = p.OrderId;
                    p1.Date = p.Date;
                    p1.Items = p.Items;
                    p1.Status = p.Status;
                    po.Add(p1);
                }
            }
            ViewBag.listProduct = po;
            return View();

        }
        public ActionResult CompleteOrderList(int Id)
        {
            Order f = db.Orders.Find(Id);
            f.Status = "Completed";
            db.SaveChanges();
            List<Order> po = new List<Order>();
            foreach (Order p in db.Orders)
            {
                if (p.Status == "Completed")
                {
                    Order p1 = new Order();
                    p1.OrderId = p.OrderId;
                    p1.Date = p.Date;
                    p1.Items = p.Items;
                    p1.Status = p.Status;
                    po.Add(p1);
                }
            }
            ViewBag.listProduct = po;
            return View();
        }

    
    public ActionResult CompletedOrders()
        {
            List<Order> po = new List<Order>();
            foreach (Order p in db.Orders)
            {
                if (p.Status == "Completed")
                {
                    Order p1 = new Order();
                    p1.OrderId = p.OrderId;
                    p1.Date = p.Date;
                    p1.Items = p.Items;
                    p1.Status = p.Status;
                    po.Add(p1);
                }
            }
            ViewBag.listProduct = po;
            return View();

        }

    }
}