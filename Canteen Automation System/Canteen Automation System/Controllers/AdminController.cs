using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Canteen_Automation_System.Models;
using System.Net;

namespace Canteen_Automation_System.Controllers
{
    public class AdminController : Controller
    {
        private CanteenAutomationSystemDbEntities3 db = new CanteenAutomationSystemDbEntities3();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
      

        public ActionResult ManageFoodItems()
        {
            List<string> categories = new List<string>();
            foreach(Category c in db.Categories)
            {
                categories.Add(c.Name);
            }
            categories.Sort();
            ViewBag.Categories = categories;
            ViewBag.listProduct = db.FoodItems.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult ManageFoodItems(FoodItemViewModel obj)
        {
            try
            {
                FoodItem food = new FoodItem();
                food.Name = obj.Name;
                food.Price = obj.Price;
                food.Category = obj.Category;
                db.FoodItems.Add(food);
                db.SaveChanges();
                return RedirectToAction("ManageFoodItems");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage); 
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
        public ActionResult DeleteFoodItems(int id)
        {
            FoodItem f = db.FoodItems.Find(id);
            db.FoodItems.Remove(f);
            db.SaveChanges();
            ViewBag.listProduct = db.FoodItems.ToList();

            return View();

        }

        public ActionResult ManageFoodCategories()
        {
            ViewBag.listProduct = db.Categories.ToList();

            return View();
        }

        public ActionResult DeleteFoodCategories(int id)
        { 
            Category c = db.Categories.Find(id);
            db.Categories.Remove(c);
            db.SaveChanges();
            // return RedirectToAction("ManageFoodCategory");
            ViewBag.listProduct = db.Categories.ToList();

            return View();
           
        }

       
       

        [HttpPost]
        public ActionResult ManageFoodCategories(FoodCategoryViewModel obj)
        {
            try
            {
                Category C = new Category();
                C.Name = obj.Name;
                C.Description = obj.Description;
                db.Categories.Add(C);
                db.SaveChanges();
                return RedirectToAction("ManageFoodCategories");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        
        public ActionResult OrdersReport()
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
        public ActionResult Reviews()
        {
            List<Review> ReviewList = new List<Review>();
            ReviewList = db.Reviews.ToList();
            ViewBag.ReviewList = ReviewList;
            return View();
        }
        
    }
}