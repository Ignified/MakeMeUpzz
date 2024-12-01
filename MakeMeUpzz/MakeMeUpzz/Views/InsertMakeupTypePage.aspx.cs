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
    public partial class InsertMakeupTypePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InsertMakeupTypeView.Visible = false;

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
                if (user.UserRole.Equals("Admin"))
                {
                    InsertMakeupTypeView.Visible = true;
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        public int generateMakeupTypeID()
        {
            int newID = 0;
            int lastID = MakeupHandler.GetLastMakeupTypeID();
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

        protected void InsertMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            MakeupHandler MakeupHandler = new MakeupHandler();
            MakeupController makeupController = new MakeupController();
            int MakeupTypeID = generateMakeupTypeID();
            String MakeupName = MakeupTypeNameTB.Text;

            String validation = "Operation Successful!";
            ErrorLbl.Text = makeupController.MakeupTypeValidation(MakeupName);
            if (validation.Equals(ErrorLbl.Text))
            {
                MakeupHandler.InsertMakeupType(MakeupTypeID, MakeupName);
                Response.Redirect("~/Views/ManageMakeupPage.aspx");
            }
        }
    }
}