using MakeMeUpzz.Controllers;
using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Viewss
{
    public partial class OrderMakeupPage : System.Web.UI.Page
    {
        List<Makeup> makeups = new List<Makeup>();
        List<Cart> carts = new List<Cart>();
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderMakeupView.Visible = false;

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
                if (user.UserRole.Equals("Customer"))
                {
                    makeups = MakeupHandler.GetAllMakeups();
                    MakeupGV.DataSource = makeups;
                    MakeupGV.DataBind();

                    carts = TransactionHandler.GetAllCarts();
                    CartGV.DataSource = carts;
                    CartGV.DataBind();

                    OrderMakeupView.Visible = true;
                }
            }
        }

        protected void OrderBtn_Click(object sender, EventArgs e)
        {
            TransactionController transactionController = new TransactionController();

            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.CommandArgument);
            GridViewRow row = MakeupGV.Rows[index];
            String MakeupName = row.Cells[0].Text;
            int MakeupPrice = Convert.ToInt32(row.Cells[1].Text);
            int MakeupWeight = Convert.ToInt32(row.Cells[2].Text);
            String MakeupTypeName = row.Cells[3].Text;
            int MakeupTypeID = MakeupHandler.getMakeupTypeIDbyName(MakeupTypeName);
            String MakeupBrandName = row.Cells[4].Text;
            int MakeupBrandID = MakeupHandler.GetMakeupBrandIDbyName(MakeupBrandName);
            TextBox quantityTextBox = (TextBox)row.FindControl("OrderMakeupQuantityTB");
            Label errorLabel = (Label)row.FindControl("ErrorLbl");

            int CartID = TransactionHandler.GenerateCartID();
            int MakeupID = MakeupHandler.GetMakeupID(MakeupName, MakeupPrice, MakeupWeight,
                MakeupTypeID, MakeupBrandID);
            User user = (User)Session["user"];
            int userID = user.UserID;
            int Quantity = Convert.ToInt32(quantityTextBox.Text);

            String validation = "Makeup order has been done";
            errorLabel.Text = transactionController.CartControl(Quantity);
            if (validation.Equals(errorLabel.Text))
            {
                TransactionHandler.InsertCart(CartID, userID, MakeupID, Quantity);

                makeups = MakeupHandler.GetAllMakeups();
                MakeupGV.DataSource = makeups;
                MakeupGV.DataBind();

                carts = TransactionHandler.GetAllCarts();
                CartGV.DataSource = carts;
                CartGV.DataBind();

                OrderMakeupView.Visible = true;
            }
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            TransactionHandler.RemoveCartItems();

            makeups = MakeupHandler.GetAllMakeups();
            MakeupGV.DataSource = makeups;
            MakeupGV.DataBind();

            carts = TransactionHandler.GetAllCarts();
            CartGV.DataSource = carts;
            CartGV.DataBind();

            OrderMakeupView.Visible = true;
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            carts = TransactionHandler.GetAllCarts();
            if (carts == null)
            {
                lblError.Text = "Currently there are no items in Cart, please check again";
                return;
            }
            int transactionID = TransactionHandler.GenerateTransactionID();
            User user = (User)Session["user"];
            int userID = user.UserID;
            DateTime transactionDate = DateTime.Now;
            string status = "UNHANDLED";
            TransactionHandler.InsertTransactionHeader(transactionID, userID, transactionDate, status);
            TransactionHandler.InsertTransactionDetails(transactionID, userID);

            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Order has been created successfully";

            TransactionHandler.RemoveCartItems();
            CartGV.DataSource = carts;
            CartGV.DataBind();

            OrderMakeupView.Visible = true;
        }
    }
}