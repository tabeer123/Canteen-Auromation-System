using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Canteen_Automation_System.Models;
using System.Net;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace Canteen_Automation_System.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            CanteenAutomationSystemDbEntities cas = new CanteenAutomationSystemDbEntities();
            List<Additem> allitems = new List<Additem>();
            foreach(FoodItem f in cas.FoodItems)
            {
                Additem f1 = new Additem();
                f1.FoodId = f.FoodId;
                f1.Category = f.Category;
                f1.Name = f.Name;
                f1.Price = f.Price;
                allitems.Add(f1);
            }
            return View(allitems);
        }


        public ActionResult ManageFoodItems()
        {
            return View();
        }
        public ActionResult AddFoodItems(Additem f)
        {
            try
            {
                FoodItem f1 = new FoodItem();
                f1.FoodId = f.FoodId;
                f1.Category = f.Category;
                f1.Name = f.Name;
                f1.Price = f.Price;
                CanteenAutomationSystemDbEntities cas = new CanteenAutomationSystemDbEntities();
                cas.FoodItems.Add(f1);
                cas.SaveChanges();
                return RedirectToAction("ManageFoodItems");
            }
            catch(Exception e)
            {
                return View();
            }
        }


        public ActionResult ManageFoodCategories()
        {
            return View();
        }
        public ActionResult DeleteFoodItem(int ID)
        {

            try
            {
                CanteenAutomationSystemDbEntities cas = new CanteenAutomationSystemDbEntities();
                FoodItem F = cas.FoodItems.Find(ID);
                cas.FoodItems.Remove(F);
                cas.SaveChanges();
                return RedirectToAction("ManageFoodItems");
            }
            catch
            {
                return View();
            }
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