using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Canteen_Automation_System.Models;

namespace Canteen_Automation_System.Controllers
{
    public class HomeController : Controller
    {
        private CanteenAutomationSystemDbEntities db = new CanteenAutomationSystemDbEntities();

        public ActionResult Index()
        {
            ViewBag.listProduct = db.FoodItems.ToList();

            return View();
        }
        public ActionResult About()
        {
            
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TrackOrder()
        {

            return View();
        }

        public ActionResult Review()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Review(ReviewViewModel obj)
        {
            try
            {
                Review review = new Review();
                review.Text= obj.Text;
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Login");
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

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        private int isPresent(int id)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            for (int j = 0; j < cart.Count; j++)
            {
                if (cart[j].NewFood1.FoodId == id)
                {
                    return j;
                }
               
            }
            return -1;

        }
        public ActionResult Cart(int id)


        { 

            if (Session["cart"] == null)
            {
                List<Cart> cart = new List<Cart>();
        cart.Add(new Cart(db.FoodItems.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Cart> cart = (List < Cart > )Session["cart"];
                int index = isPresent(id);
                if(index == -1)
                {
                    cart.Add(new Cart(db.FoodItems.Find(id), 1));
                   
                }
                else
                {
                    cart[index].Quantity++;
                }
                
                Session["cart"] = cart;
            }

            return View("Cart");
        }
    }
}