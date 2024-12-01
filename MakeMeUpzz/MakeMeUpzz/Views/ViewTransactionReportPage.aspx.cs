using MakeMeUpzz.Dataset;
using System;
using MakeMeUpzz.Report;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MakeMeUpzz.Models;
using System.Web.Util;
using MakeMeUpzz.Handlers;
using System.Data;
using CrystalDecisions.Shared;

namespace MakeMeUpzz.Viewss
{
    public partial class ViewTransactionReportPage : System.Web.UI.Page
    {
        List<TransactionHeader> transactions = TransactionHandler.GetAllTransactionHeaders();
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
                if (!user.UserRole.Equals("Admin"))
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
            TransactionDataset data = getData(transactions);
            TransactionCrystalReport transactionReport = new TransactionCrystalReport();
            CrystalReportViewerTransaction.ReportSource = transactionReport;
            transactionReport.SetDataSource(data);
        }

        public TransactionDataset getData(List<TransactionHeader> transactions)
        {
            TransactionDataset data = new TransactionDataset();
            var HeaderTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach (TransactionHeader t in transactions)
            {
                decimal subtotal = 0;
                var hrow = HeaderTable.NewRow();
                hrow["transaction_id"] = t.TransactionID;
                hrow["user_id"] = t.UserID;
                hrow["username"] = t.User.Username;
                hrow["transaction_date"] = t.TransactionDate;
                hrow["status"] = t.Status;

                HeaderTable.Rows.Add(hrow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    decimal totalprice = 0;
                    var drow = detailTable.NewRow();
                    totalprice += d.Quantity * d.Makeup.MakeupPrice;
                    drow["transaction_id"] = d.TransactionID;
                    drow["makeup_name"] = d.Makeup.MakeupName;
                    drow["makeup_type_name"] = d.Makeup.MakeupType.MakeupTypeName;
                    drow["makeup_brand_name"] = d.Makeup.MakeupBrand.MakeupBrandName;
                    drow["quantity"] = d.Quantity;
                    drow["makeup_price"] = d.Makeup.MakeupPrice;
                    drow["makeup_weight"] = d.Makeup.MakeupWeight;
                    drow["total_price"] = totalprice;
                    detailTable.Rows.Add(drow);
                    subtotal += totalprice;
                }
                hrow["subtotal"] = subtotal;
            }
            return data;
        }
    }
}