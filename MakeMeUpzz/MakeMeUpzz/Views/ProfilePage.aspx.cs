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
    public partial class ProfilePage : System.Web.UI.Page
    {
        List<User> users = new List<User>();
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
                if (!IsPostBack)
                {
                    User currentUser = (User)Session["user"];
                    int userID = currentUser.UserID;
                    User checkUser = UserHandler.GetUserfromID(userID);

                    if (checkUser != null)
                    {
                        UsernameTB.Text = checkUser.Username;
                        UserEmailTB.Text = checkUser.UserEmail;
                        UserDOBTB.Text = checkUser.UserDOB.ToString();
                        String userGender = checkUser.UserGender;
                        if (userGender.Equals("Male"))
                        {
                            RadioButtonMale.Checked = true;
                        }
                        else if (userGender.Equals("Female"))
                        {
                            RadioButtonFemale.Checked = true;
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }
                }
            }
        }

        protected void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            UserController userRegisterController = new UserController();
            User currentUser = (User)Session["user"];
            int userID = currentUser.UserID;
            User checkUser = UserHandler.GetUserfromID(userID);
            String oldPassword = OldPasswordTB.Text;
            String newPassword = NewPasswordTB.Text;
            String Username = checkUser.Username;
            String UserEmail = checkUser.UserEmail;
            DateTime UserDOB = checkUser.UserDOB;
            String UserGender = checkUser.UserGender;
            String UserRole = checkUser.UserRole;

            String validation = "Password has been updated";
            ErrorLblUpdatePassword.Text = userRegisterController.UpdatePassword(oldPassword, newPassword, userID);
            if (validation.Equals(ErrorLblUpdatePassword.Text))
            {
                UserHandler.UpdateUser(userID, Username, UserEmail, UserDOB, UserGender, UserRole
                    , newPassword);
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            UserHandler userHandler = new UserHandler();
            UserController userRegisterController = new UserController();
            User currentUser = (User)Session["user"];
            int userID = currentUser.UserID;
            String Username = UsernameTB.Text;
            String UserEmail = UserEmailTB.Text;
            String gender = "";
            if (RadioButtonMale.Checked)
            {
                gender = "Male";
            }
            else if (RadioButtonFemale.Checked)
            {
                gender = "Female";
            }
            User checkUser = UserHandler.GetUserfromID(userID);
            String UserRole = checkUser.UserRole;
            String UserPassword = checkUser.UserPassword;
            DateTime UserDOB = Convert.ToDateTime(UserDOBTB.Text);

            String validation = "Update has been done";
            ErrorLblUpdateProfile.Text = userRegisterController.Update(Username, UserEmail, gender, UserDOB);
            if (validation.Equals(ErrorLblUpdateProfile.Text))
            {
                UserHandler.UpdateUser(userID, Username, UserEmail, UserDOB, gender, UserRole, UserPassword);
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }
    }
}