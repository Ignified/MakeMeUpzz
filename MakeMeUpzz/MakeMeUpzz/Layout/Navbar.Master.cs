using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Layout
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerRole.Visible = false;
            AdminRole.Visible = false;

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
                    user = UserHandler.GetUserfromID(userID);
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }
                if (user != null)
                {
                    if (Application["user_count"] != null)
                    {
                        ActiveUserCountLabel.Text = Application["user_count"].ToString();
                    }
                    if (user.UserRole.Equals("Admin"))
                    {
                        AdminRole.Visible = true;
                    }
                    if (user.UserRole.Equals("Customer"))
                    {
                        CustomerRole.Visible = true;
                    }
                    WelcomeLabel.Text = user.Username;
                }
                else
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }
            }
        }
        protected void OrderMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderMakeupPage.aspx");
        }

        protected void HistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistoryPage.aspx");
        }

        protected void ProfileCustomerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void LogoutCustomerBtn_Click(object sender, EventArgs e)
        {
            string[] cookie_keys = Request.Cookies.AllKeys;
            foreach (string key in cookie_keys)
            {
                HttpCookie cookie = new HttpCookie(key);
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Session.Remove("user");
            Application["user_count"] = ((int)Application["user_count"]) - 1;
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void ManageMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        protected void OrderQueueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HandleTransactionPage.aspx");
        }

        protected void ProfileAdminBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void TransactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ViewTransactionReportPage.aspx");
        }

        protected void LogoutAdminBtn_Click(object sender, EventArgs e)
        {
            string[] cookie_keys = Request.Cookies.AllKeys;
            foreach (string key in cookie_keys)
            {
                HttpCookie cookie = new HttpCookie(key);
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Session.Remove("user");
            Application["user_count"] = ((int)Application["user_count"]) - 1;
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}