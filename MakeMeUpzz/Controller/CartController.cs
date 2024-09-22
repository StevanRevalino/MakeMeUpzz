using MakeMeUpzz.Handler;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class CartController
    {
        public static void CreateCartItem(int UserID, int MakeupID, int Quantity)
        {
            CartHandler.CreateCartItem(UserID, MakeupID, Quantity);
        }

        public static void DeleteUserCart(int UserID)
        {
            CartHandler.DeleteUserCart(UserID);
        }


        public static List<Cart> GetUserCart(int UserID)
        {
            return CartHandler.GetUserCart(UserID);
        }
    }
}