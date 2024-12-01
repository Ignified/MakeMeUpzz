using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int TransactionID, int MakeupID, int Quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = TransactionID;
            transactionDetail.MakeupID = MakeupID;
            transactionDetail.Quantity = Quantity;
            return transactionDetail;
        }
    }
}