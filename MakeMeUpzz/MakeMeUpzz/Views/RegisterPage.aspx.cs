using MakeMeUpzz.Controllers;
using MakeMeUpzz.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public int generateUserID()
        {
            int newID = 0;
            int lastID = UserHandler.GetLastUserID();
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

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            UserController userRegisterController = new UserController();
            ErrorLbl.Text = "";
            String gender = "";
            int ID = generateUserID();
            String Username = UsernameTB.Text;
            String Email = EmailTB.Text;
            if (!RadioButtonFemale.Checked && !RadioButtonMale.Checked)
            {
                gender = "";
            }
            else if (RadioButtonMale.Checked)
            {
                gender = "Male";
            }
            else if (RadioButtonFemale.Checked)
            {
                gender = "Female";
            }
            String password = PasswordTB.Text;
            String confirmPassword = ConfirmPasswordTB.Text;
            DateTime DOB = Convert.ToDateTime(DOBTB.Text);
            String validate = "Registration has been done!";
            ErrorLbl.Text = userRegisterController.Register(Username, Email, gender, password, confirmPassword,
                DOB);
            String UserRole = "Customer";
            if (validate.Equals(ErrorLbl.Text))
            {
                UserHandler.InsertUser(ID, Username, Email, DOB, gender, UserRole, password);
                Response.Redirect("~/Views/LoginPage.aspx");
            }                     
        }
    }
}