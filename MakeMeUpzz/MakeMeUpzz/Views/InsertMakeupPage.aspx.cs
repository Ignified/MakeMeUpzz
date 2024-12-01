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
    public partial class InsertMakeupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InsertMakeupView.Visible = false;

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
                    InsertMakeupView.Visible = true;
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        public int generateMakeupID()
        {
            int newID = 0;
            int lastID = MakeupHandler.GetLastMakeupID();
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

        protected void InsertMakeupBtn_Click(object sender, EventArgs e)
        {
            MakeupController makeupController = new MakeupController();
            int MakeupID = generateMakeupID();
            String MakeupName = MakeupNameTB.Text;
            int MakeupPrice = Convert.ToInt32(MakeupPriceTB.Text);
            int MakeupWeight = Convert.ToInt32(MakeupWeightTB.Text);
            int MakeupTypeID = Convert.ToInt32(MakeupTypeIDTB.Text);
            int MakeupBrandID = Convert.ToInt32(MakeupBrandIDTB.Text);

            String validation = "Operation Successful!";
            ErrorLbl.Text = makeupController.MakeupValidation(MakeupName, MakeupPrice, MakeupWeight,
                MakeupTypeID, MakeupBrandID);
            if (validation.Equals(ErrorLbl.Text))
            {
                MakeupHandler.InsertMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID
                    , MakeupBrandID);
                Response.Redirect("~/Views/ManageMakeupPage.aspx");
            }
        }
    }
}