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
    public partial class UpdateMakeupTypePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateMakeupTypeView.Visible = false;

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
                    UpdateMakeupTypeView.Visible = true;
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    MakeupType makeupType = MakeupHandler.FindMakeupTypeByID(id);

                    if (makeupType != null)
                    {
                        MakeupTypeNameTB.Text = makeupType.MakeupTypeName;
                    }
                    else
                    {
                        Response.Redirect("~/Views/ManageMakeupPage.aspx");
                    }
                }
            }
        }

        protected void UpdateMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            MakeupController makeupController = new MakeupController();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            String MakeupTypeName = MakeupTypeNameTB.Text;

            String validation = "Actions has been done!";
            ErrorLbl.Text = makeupController.MakeupTypeValidation(MakeupTypeName);
            if (validation.Equals(ErrorLbl.Text))
            {
                MakeupHandler.updateMakeupType(id, MakeupTypeName);
                Response.Redirect("~/Views/ManageMakeupPage.aspx");
            }
        }
    }
}