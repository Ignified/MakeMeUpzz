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
    public partial class InsertMakeupBrandPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InsertMakeupBrandView.Visible = false;

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
                    InsertMakeupBrandView.Visible = true;
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        public int generateMakeupBrandID()
        {
            int newID = 0;
            int lastID = MakeupHandler.GetLastMakeupBrandID();
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

        protected void InsertMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            MakeupController makeupController = new MakeupController();
            int MakeupBrandID = generateMakeupBrandID();
            String MakeupBrandName = MakeupBrandNameTB.Text;
            int MakeupBrandRating = Convert.ToInt32(MakeupBrandRatingTB.Text);
            String validation = "Actions has been done!";
            ErrorLbl.Text = makeupController.MakeupBrandValidation(MakeupBrandName, MakeupBrandRating);

            if (validation.Equals(ErrorLbl.Text))
            {
                MakeupHandler.InsertMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
                Response.Redirect("~/Views/ManageMakeupPage.aspx");
            }
        }
    }
}