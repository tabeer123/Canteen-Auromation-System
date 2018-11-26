using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Canteen_Automation_System.Models;

namespace Canteen_Automation_System.Controllers
{
    public class AdminController : Controller
    {
        private CanteenAutomationSystemDbEntities db = new CanteenAutomationSystemDbEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
      

        public ActionResult ManageFoodItems()
        {
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
                return RedirectToAction("OrdersReport");
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
        //public ActionResult AddFoodItems()
        //{
        //    return View();
        //}


        public ActionResult ManageFoodCategories()
        {
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
                return RedirectToAction("OrdersReport");
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


        //public ActionResult AddFoodCategories()
        //{
        //    return View();
        //}
        public ActionResult OrdersReport()
        {
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