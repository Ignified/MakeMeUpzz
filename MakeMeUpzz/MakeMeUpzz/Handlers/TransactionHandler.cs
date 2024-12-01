using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class TransactionHandler
    {
        // Cart 
        public static List<Cart> GetAllCarts()
        {
            return  CartRepository.getAllCarts();
        }

        public static int getLastCartID()
        {
            return CartRepository.getLastCartID();
        }

        public static void InsertCart(int CartID, int UserID, int MakeupID, int Quantity)
        {
            CartRepository.InsertCart(CartID, UserID, MakeupID, Quantity);
        }

        public static void RemoveCartItems()
        {
            CartRepository.RemoveCartItems();
        }

        public static int GenerateCartID()
        {
            return CartRepository.GenerateCartID();
        }

        // TransactionHeader
        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return TransactionHeaderRepository.GetAllTransactionHeaders();
        }

        public static int getLastTransactionHeaderID()
        {
            return TransactionHeaderRepository.GetLastTransactionHeaderID();
        }

        public static void InsertTransactionHeader(int TransactionID, int UserID, DateTime TransactionDate,
            String status)
        {
            TransactionHeaderRepository.InsertTransactionHeader(TransactionID, UserID, 
                TransactionDate, status);
        }

        public static List<TransactionHeader> GetAllTransactionByUserID(int UserID)
        {
            return TransactionHeaderRepository.GetAllTransactionByUserID(UserID);
        }
        public static TransactionHeader GetTransactionByID(int TransactionID)
        {
            return TransactionHeaderRepository.GetTransactionByID(TransactionID);
        }

        public static TransactionHeader FindTransactionbyID(int TransactionID)
        {
            return TransactionHeaderRepository.FindTransactionbyID(TransactionID);
        }

        public static void UpdateTransaction(int TransactionID, int UserID, DateTime TransactionDate,
            String Status)
        {
            TransactionHeaderRepository.UpdateTransaction(TransactionID, UserID, TransactionDate, Status);
        }

        public static int GenerateTransactionID()
        {
            return TransactionHeaderRepository.GenerateTransactionID();
        }

        //TransactionDetails 
        public static List<TransactionDetail> GetAllTransactionDetails()
        {
            return TransactionDetailRepository.GetAllTransactionDetails();
        }

        public static void InsertTransactionDetails(int TransactionID, int UserID)
        {
            TransactionDetailRepository.InsertTransactionDetails(TransactionID, UserID);
        }

        public static List<TransactionDetail> GetTransactionDetailsByID(int TransactionID)
        {
            return TransactionDetailRepository.GetTransactionDetailsByID(TransactionID);
        }
    }
}