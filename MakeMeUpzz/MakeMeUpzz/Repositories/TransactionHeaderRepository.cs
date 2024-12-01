using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class TransactionHeaderRepository
    {
        private static MakeMeUpzzDatabaseEntities1 db = DatabaseSingleton.getInstance();

        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public static int GetLastTransactionHeaderID()
        {
            return (from x in db.TransactionHeaders select x.TransactionID).ToList().LastOrDefault();
        }

        public static List<TransactionHeader> GetAllTransactionByUserID(int userID)
        {
            return (from x in db.TransactionHeaders where userID == x.UserID select x).ToList();
        }

        public static TransactionHeader GetTransactionByID(int transactionID)
        {
            return (from x in db.TransactionHeaders where transactionID == x.TransactionID select x).FirstOrDefault();
        }

        public static void InsertTransactionHeader(int TransactionID, int UserID, DateTime TransactionDate,
            String status)
        {
            TransactionHeader transactionHeader = TransactionHeaderFactory.Create(TransactionID,
                UserID, TransactionDate, status);
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
        }

        public static TransactionHeader FindTransactionbyID(int TransactionID)
        {
            TransactionHeader transactionHeader = db.TransactionHeaders.Find(TransactionID);
            return transactionHeader;
        }

        public static void UpdateTransaction(int TransactionID, int UserID, DateTime TransactionDate,
            String Status)
        {
            TransactionHeader updateTransactionHeader = FindTransactionbyID(TransactionID);
            updateTransactionHeader.TransactionID = TransactionID;
            updateTransactionHeader.UserID = UserID;
            updateTransactionHeader.TransactionDate = TransactionDate;
            updateTransactionHeader.Status = Status;
            db.SaveChanges();
        }

        public static int GenerateTransactionID()
        {
            int newID = 0;
            int lastID = GetLastTransactionHeaderID();
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