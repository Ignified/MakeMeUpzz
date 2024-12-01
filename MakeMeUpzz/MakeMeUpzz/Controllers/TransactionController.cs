using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class TransactionController
    {
        public String CartControl(int Quantity)
        {
            String space;

            if(Quantity <= 0)
            {
                space = "Quantity must be more than 0";
                return space;
            }

            space = "Order Makeup has been made";
            return space;
        }
    }
}