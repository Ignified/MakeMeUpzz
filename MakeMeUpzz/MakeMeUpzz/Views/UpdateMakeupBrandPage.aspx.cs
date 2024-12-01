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
    public partial class UpdateMakeupBrandPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateMakeupBrandView.Visible = false;

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
                if (user.UserRole.Equals("Admin") && !IsPostBack)
                {
                    UpdateMakeupBrandView.Visible = true;
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    MakeupBrand makeupBrand = MakeupHandler.FindMakeupBrandByID(id);

                    if (makeupBrand != null)
                    {
                        MakeupBrandNameTB.Text = makeupBrand.MakeupBrandName;
                        MakeupBrandRatingTB.Text = makeupBrand.MakeupBrandRating.ToString();
                    }
                    else
                    {
                        Response.Redirect("~/Views/ManageMakeupPage.aspx");
                    }
                }
            }
        }

        protected void UpdateMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            MakeupController makeupController = new MakeupController();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            String MakeupBrandName = MakeupBrandNameTB.Text;
            int MakeupBrandRating = Convert.ToInt32(MakeupBrandRatingTB.Text);

            String validation = "Actions has been done";
            ErrorLbl.Text = makeupController.MakeupBrandValidation(MakeupBrandName, MakeupBrandRating);
            if (validation.Equals(ErrorLbl.Text))
            {
                MakeupHandler.UpdateMakeupBrand(id, MakeupBrandName, MakeupBrandRating);
                Response.Redirect("~/Views/ManageMakeupPage.aspx");
            }
        }
    }
}