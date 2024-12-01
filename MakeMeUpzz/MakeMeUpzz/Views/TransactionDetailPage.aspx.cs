using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace MakeMeUpzz.Viewss
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected List<TransactionDetail> tran = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                User user = new User();
                if (Session["user"] == null)
                {
                    int userID = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    user = UserHandler.FindUserbyID(userID);
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }
                
                string transactionID = Request.QueryString["id"];
                tran = TransactionHandler.GetTransactionDetailsByID(Convert.ToInt32(transactionID));
                TransactionHeader transaction = TransactionHandler.GetTransactionByID(Convert.ToInt32(transactionID));

                pageID.InnerText = "Transaction " + transactionID;
                pageDate.InnerText = "Transaction Date: " + transaction.TransactionDate.ToString("yyyy-MM-dd");
                
                if (transactionID == null || tran == null)
                {
                    Response.Redirect("~/Views/TransactionHistoryPage.aspx");
                }
            }
        }
    }
}