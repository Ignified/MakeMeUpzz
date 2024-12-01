using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int TransactionID, int UserID, DateTime TransactionDate
            , String Status)
        {
            TransactionHeader transactionHeader = new TransactionHeader();  
            transactionHeader.TransactionID = TransactionID;
            transactionHeader.UserID = UserID;
            transactionHeader.TransactionDate = TransactionDate;
            transactionHeader.Status = Status;
            return transactionHeader;
        }
    }
}