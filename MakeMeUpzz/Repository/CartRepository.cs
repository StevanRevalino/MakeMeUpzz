using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class CartRepository
    {
        private static MakeMeUpzzDBEntities2 db = DatabaseSingleton.GetInstance();

        public void CreateCart(int CartID, int UserID, int MakeupID, int Quantity)
        {
            Cart cart = CartFactory.Create(CartID, UserID, MakeupID, Quantity);
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public int GetLastCardID()  
        {
            return (from u
                    in db.Carts
                    select u.CartID).ToList().LastOrDefault();
        }

        public void UpdateCartQuantity(int UserID, int MakeupID, int newQty)
        {
            Cart updateCart = GetCartByUserIDMakeupID(UserID, MakeupID);
            updateCart.Quantity = newQty;
            db.SaveChanges();
        }

        public void DeleteUserCart(int UserID)
        {
            List<Cart> toRemove = GetUserCart(UserID);
            foreach (Cart item in toRemove)
            {
                db.Carts.Remove(item);
            }
            db.SaveChanges();
        }

        public Cart GetCartByUserIDMakeupID(int UserID, int MakeupID)
        {
            return (from c
                    in db.Carts 
                    where c.UserID.Equals(UserID) && c.MakeupID.Equals(MakeupID) 
                    select c).FirstOrDefault();
        }

        public List<Cart> GetUserCart(int UserID)
        {
            return (from c 
                    in db.Carts 
                    where c.UserID.Equals(UserID) 
                    select c).ToList();
        }

        public bool IsItemInCart(int UserID, int MakeupID)
        {
            return db.Carts.Any(cart => cart.UserID.Equals(UserID) && cart.MakeupID.Equals(MakeupID));
        }
    }
}