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
        private CanteenAutomationSystemDbEntities3 db = new CanteenAutomationSystemDbEntities3();

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
            ViewBag.Filterthroughid = ""; ;
            //OrderProductView p = new OrderProductView();
            //p.Orderid = 0;
            //p.price =0;
            //p.Productid = 0;
            //p.Productname = "";
            //p.quantity = 0;
            //p.category = "";
            return View();

        }
        [HttpPost]
        public ActionResult TrackOrder(string id)
        {
            try
            {
                //return View(db.OrderProducts.Where(x => x.OrderId == Convert.ToInt32(id) || id == null).ToString());
                if (id == null)
                {
                    return HttpNotFound();

                }
                else
                {
                    List<OrderProduct> prodeuctlist = new List<OrderProduct>();
                    foreach (OrderProduct Order in db.OrderProducts)
                    {
                        if (Order.OrderId == Convert.ToInt32(id))
                        {
                            OrderProduct Oproduct = new OrderProduct();
                            //Oproduct.Order.Status = Order.Order.Status;
                            Oproduct.OrderId = Order.OrderId;
                            Oproduct.ProductId = Order.ProductId;
                            Oproduct.Price = Order.Price;
                            Oproduct.Category = Order.Category;
                            Oproduct.ProductName = Order.ProductName;
                            Oproduct.Quantity = Order.Quantity;
                            prodeuctlist.Add(Oproduct);


                        }

                    }
                    ViewBag.Filterthroughid = prodeuctlist;
                    return View(prodeuctlist.ToList());
                }

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
                review.Text = obj.Text;
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

        [HttpPost]
        public ActionResult Login(AccountViewModel user)
        {
            foreach (User u in db.Users)
            {
                if (u.Email == user.Email && u.Password == user.Password)
                {
                    if (u.RegisterAs == "Admin")
                    {
                        ViewBag.listProduct = db.FoodItems;
                        return View("../Admin/ManageFoodItems");
                    }
                    else
                    {
                        ViewBag.listProduct = db.Orders;
                        return View("../Chef/Index");
                    }
                }
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(AccountViewModel user)
        {
            try
            {
                User U = new User();
                U.Email = user.Email;
                U.Password = user.Password;
                U.RegisterAs = user.RegisterAs;
                db.Users.Add(U);
                db.SaveChanges();
                return View("Login");
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

        public ActionResult CheckOut()
        {
            try
            {
                ViewBag.listProduct = db.FoodItems.ToList();
                Order order = new Order();
                order.Date = DateTime.Now;
                order.Status = "pending";
                order.Bill = 1000;
                List<Cart> cart = (List<Cart>)Session["cart"];
                order.Items = cart.ToArray().Length;
                db.Orders.Add(order);
                db.SaveChanges();
                int r = order.OrderId;
                for (int j = 0; j < cart.Count; j++)
                {
                    FoodItem F = db.FoodItems.Find(cart[j].NewFood1.FoodId);
                    OrderProduct orderProduct = new OrderProduct();
                    orderProduct.OrderId = r;
                    orderProduct.ProductName = F.Name;
                    orderProduct.Quantity = cart[j].Quantity;
                    orderProduct.Price = F.Price;
                    orderProduct.Category = F.Category;
                    db.OrderProducts.Add(orderProduct);
                    db.SaveChanges();
                }
                Session["cart"] = null;
                return View("Index");
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
        public ActionResult Cart(int id, Cart cartB)


        {
            try
            {
                if (id == null && cartB == null)
                {
                    return View();
                }
                else
                {
                    if (Session["cart"] == null)
                    {
                        List<Cart> cart = new List<Cart>();
                        cart.Add(new Cart(db.FoodItems.Find(id), 1));
                        Session["cart"] = cart;
                    }
                    else
                    {
                        List<Cart> cart = (List<Cart>)Session["cart"];
                        int index = isPresent(id);
                        if (index == -1)
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
    }
}