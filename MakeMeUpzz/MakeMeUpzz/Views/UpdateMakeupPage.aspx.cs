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
    public partial class UpdateMakeupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateMakeupView.Visible = false;

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
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Makeup makeup = MakeupHandler.FindMakeupByID(id);
                    UpdateMakeupView.Visible = true;

                    if (makeup != null)
                    {
                        MakeupNameTB.Text = makeup.MakeupName;
                        MakeupPriceTB.Text = makeup.MakeupPrice.ToString();
                        MakeupWeightTB.Text = makeup.MakeupWeight.ToString();
                        MakeupTypeIDTB.Text = makeup.MakeupTypeID.ToString();
                        MakeupBrandIDTB.Text = makeup.MakeupBrandID.ToString();
                    }
                    else
                    {
                        Response.Redirect("~/Views/ManageMakeupPage.aspx");
                    }
                }
            }
        }

        protected void UpdateMakeupBtn_Click(object sender, EventArgs e)
        {
            MakeupController makeupController = new MakeupController();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            String MakeupName = MakeupNameTB.Text;
            int MakeupPrice = Convert.ToInt32(MakeupPriceTB.Text);
            int MakeupWeight = Convert.ToInt32(MakeupWeightTB.Text);
            int MakeupTypeID = Convert.ToInt32(MakeupTypeIDTB.Text);
            int MakeupBrandID = Convert.ToInt32(MakeupBrandIDTB.Text);

            String validation = "Actions has been done";
            ErrorLbl.Text = makeupController.MakeupValidation(MakeupName, MakeupPrice, MakeupWeight,
                MakeupTypeID, MakeupBrandID);
            if (validation.Equals(ErrorLbl.Text))
            {
                MakeupHandler.UpdateMakeup(id, MakeupName, MakeupPrice, MakeupWeight,
                    MakeupTypeID, MakeupBrandID);
                Response.Redirect("~/Views/ManageMakeupPage.aspx");
            }
        }
    }
}