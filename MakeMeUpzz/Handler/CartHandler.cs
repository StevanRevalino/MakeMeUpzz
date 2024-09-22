using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class CartHandler
    {
        //Create
        public static void CreateCartItem(int UserID, int MakeupID, int Quantity)
        {
            CartRepository cartRepository = new CartRepository();

            if (cartRepository.IsItemInCart(UserID, MakeupID))
            {
                Cart currCart = cartRepository.GetCartByUserIDMakeupID(UserID, MakeupID);
                int newQuantity = currCart.Quantity + Quantity;
                cartRepository.UpdateCartQuantity(UserID, MakeupID, newQuantity);
            }
            else
            {
                cartRepository.CreateCart(GenerateCartId(), UserID, MakeupID, Quantity);
            }
        }

        public static int GenerateCartId()
        {
            CartRepository cartRepository = new CartRepository();
            int lastId = cartRepository.GetLastCardID();
            if (lastId == 0) lastId = 1;
            else lastId++;
            return lastId;
        }

        //Delete
        public static void DeleteUserCart(int UserID)
        {
            CartRepository cartRepository = new CartRepository();
            cartRepository.DeleteUserCart(UserID);
        }

        public static List<Cart> GetUserCart(int UserID)
        {
            CartRepository cartRepository = new CartRepository();
            return cartRepository.GetUserCart(UserID);
        }
    }
}