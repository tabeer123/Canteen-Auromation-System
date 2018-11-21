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
            CanteenAutomationSystemDbEntities1 cas = new CanteenAutomationSystemDbEntities1();
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
                CanteenAutomationSystemDbEntities1 cas = new CanteenAutomationSystemDbEntities1();
                cas.FoodItems.Add(f1);
                cas.SaveChanges();
                return RedirectToAction("ManageFoodItems");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        //Manage Food Category
        public ActionResult ManageFoodCategories()
        {
            CanteenAutomationSystemDbEntities1 CAS = new CanteenAutomationSystemDbEntities1();
            List<AddFoodCategory> AllfCategory = new List<AddFoodCategory>();
            foreach (Category C in CAS.Categories)
            {
                AddFoodCategory FC1 = new AddFoodCategory();
                FC1.Categoryid = C.CategoryId;
                FC1.name = C.Name;
                FC1.description = C.Description;
                AllfCategory.Add(FC1);
            }
            return View(AllfCategory);
        }
        public ActionResult DeleteFoodItem(int ID)
        {

            try
            {
                CanteenAutomationSystemDbEntities1 cas = new CanteenAutomationSystemDbEntities1();
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
        // Add Food Category
        public ActionResult AddFoodCategories(AddFoodCategory FC)
        {
            try
            {
               
                
                Category FC1 = new Category();
                FC1.CategoryId = FC.Categoryid;
                FC1.Name = FC.name;
                FC1.Description = FC.description;
               
                CanteenAutomationSystemDbEntities1 CAS = new CanteenAutomationSystemDbEntities1();
                CAS.Categories.Add(FC1);
                CAS.SaveChanges();
                return RedirectToAction("ManageFoodCategories");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        //Delete Food Category
        public ActionResult DeleteFoodCategory(int cID)
        {

            try
            {
                CanteenAutomationSystemDbEntities1 CAS = new CanteenAutomationSystemDbEntities1();
                Category FC = CAS.Categories.Find(cID);
                CAS.Categories.Remove(FC);
                CAS.SaveChanges();
                return RedirectToAction("ManageFoodCategories");
            }
            catch
            {
                return View();
            }
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