using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class CartRepository
    {
        private static MakeMeUpzzDatabaseEntities1 db = DatabaseSingleton.getInstance();

        public static List<Cart> getAllCarts()
        {
            return db.Carts.ToList();
        }

        public static List<Cart> getAllCartsbyUserID(int UserID)
        {
            return (from x in db.Carts where x.UserID == UserID select x).ToList();
        }

        public static int getLastCartID()
        {
            return (from x in db.Carts select x.CartID).ToList().LastOrDefault();
        }

        private static Boolean checkCartDuplicateItems(int MakeupID)
        {
            if (db.Carts.Find(MakeupID) != null)
            {
                return true;
            }
            return false;
        }

        public static void InsertCart(int CartID, int UserID, int MakeupID, int Quantity)
        {
            if (checkCartDuplicateItems(MakeupID))
            {
                db.Carts.Find(MakeupID).Quantity += Quantity;
            }
            else
            {
                Cart cart = CartFactory.Create(CartID, UserID, MakeupID, Quantity);
                db.Carts.Add(cart);
            }
            db.SaveChanges();
        }

        public static void RemoveCartItems()
        {
            var allCartItems = (from x in db.Carts select x);
            db.Carts.RemoveRange(allCartItems);
            db.SaveChanges();
        }

        public static int GenerateCartID()
        {
            int newID = 0;
            int lastID = getLastCartID();
            int? lastIDLogic = lastID;
            if (lastIDLogic == null)
            {
                newID = 1;
            }
            else
            {
                newID = lastID;
                newID++;
            }
            return newID;
        }
    }
}