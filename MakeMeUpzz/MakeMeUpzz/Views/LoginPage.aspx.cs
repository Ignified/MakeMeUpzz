using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTB.Text;
            string password = UserPasswordTB.Text;
            bool remember = RememberMeCheckbox.Checked;

            User user = UserHandler.GetUserfromUsernamePassword(username, password);
            if (user == null)
            {
                lblError.Text = "User cannot be found";
            }
            else
            {
                Session["user"] = user;
                if (remember)
                { 
                    HttpCookie cookie = new HttpCookie("user_cookie"); 
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    cookie.Path = "/";
                    cookie.Secure = true;
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);                   
                }
                if (Application["user_count"] == null)
                { 
                    Application["user_count"] = 1;
                }
                else
                {
                    Application["user_count"] = ((int)Application["user_count"]) + 1;
                }
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }
    }
}