using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canteen_Automation_System.Controllers
{
    public class Cart
    {
            private int quantity;
            private FoodItem NewFood = new FoodItem();

            public int Quantity
            {
                get
                {
                    return quantity;
                }

                set
                {
                    quantity = value;
                }
            }

            public FoodItem NewFood1
            {
                get
                {
                    return NewFood;
                }

                set
                {
                    NewFood = value;
                }
            }

            public Cart() { }
            public Cart(FoodItem newFood, int quantity)
            {
                this.NewFood1 = newFood;
                this.Quantity = quantity;
            }
        }
    }
