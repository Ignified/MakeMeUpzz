using MakeMeUpzz.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

namespace MakeMeUpzz.Controllers
{
    public class UserController
    {
        public Boolean UsernameUnique(String username)
        {
            List<String> usernames = UserHandler.GetAllUsernames();
            for (int i = 0; i < usernames.Count; i++)
            {
                if (username.Equals(usernames[i])) { return false; }
            }
            return true;
        }
        public static Boolean AlphaNumeric(String password)
        {
            return Regex.IsMatch(password, "^[a-zA-Z0-9]+$");
        }
        
        public String Register(String username, String email, String gender, 
            String password, String confirmPassword, DateTime DOB)
        {
            String lbl;
            // Username
            if (username == null || username.Length == 0)
            {
                lbl = "Username must be written";
                return lbl;
            }
            else if (username.Length < 5 || username.Length > 15)
            {
                lbl = "Username length must be between 5 and 15";
                return lbl;
            }
            else if (!UsernameUnique(username))
            {
                lbl = "Username isn't unique";
                return lbl;
            }

            // Email
            if (email == null || email.Length == 0)
            {
                lbl = "Email must be written";
                return lbl;
            }
            else if (!email.EndsWith(".com"))
            {
                lbl = "Email must end with .com";
                return lbl;
            }

            // Gender
            if (gender != "Male" && gender != "Female")
            {
                lbl = "Gender must be either Male or Female";
                return lbl;
            }

            //Validasi Password
            if (password == null || password.Length == 0)
            {
                lbl = "Password must be written";
                return lbl;
            }
            else if (!AlphaNumeric(password))
            {
                lbl = "Password must be alphanumeric";
                return lbl;
            }
            else if (!password.Equals(confirmPassword))
            {
                lbl = "Password doesn't match";
                return lbl;
            }

            //Validasi ConfirmPassword
            if (confirmPassword == null || confirmPassword.Length == 0)
            {
                lbl = "Please Verify your password again";
                return lbl;
            }
            else if (!confirmPassword.Equals(password))
            {
                lbl = "Current Password doens't match with the first Password";
                return lbl;
            }           

            // DOB
            if (DOB == null)
            {
                lbl = "Date of Birth must be written";
                return lbl;
            }

            lbl = "Actions have been done";
            return lbl;
        }

        public String Update(String username, String email, String gender, DateTime DOB)
        {
            String lbl;

            // Username
            if (username == null || username.Length == 0)
            {
                lbl = "Username must be written";
                return lbl;
            }
            else if (username.Length < 5 || username.Length > 15)
            {
                lbl = "Username length must be between 5 and 15!";
                return lbl;
            }
            else if (!UsernameUnique(username))
            {
                lbl = "Username isn't unique";
                return lbl;
            }

            //Email
            if (email == null || email.Length == 0)
            {
                lbl = "Email must be written";
                return lbl;
            }
            else if (!email.EndsWith(".com"))
            {
                lbl = "Email must end with .com";
                return lbl;
            }

            //Gender
            if (gender != "Male" && gender != "Female")
            {
                lbl = "Gender must be either Male or Female";
                return lbl;
            }

            // DOB
            if (DOB == null)
            {
                lbl = "Date of Birth must be written";
                return lbl;
            }

            lbl = "Actions have been done";
            return lbl;
        }

        public String UpdatePassword(String oldPassword, String newPassword, int ID)
        {
            String lbl;

            //Validasi Old Password
            if (!oldPassword.Equals(UserHandler.GetPasswordfromID(ID)))
            {
                lbl = "Password doesn't match";
                return lbl;
            }
            else if (oldPassword == null || oldPassword.Length == 0)
            {
                lbl = "Old Password must be written";
                return lbl;
            }

            //Validasi New Password
            if (newPassword == null || newPassword.Length == 0)
            {
                lbl = "New Password must be written";
                return lbl;
            }
            else if (!AlphaNumeric(newPassword))
            {
                lbl = "New Password must be alphanumeric";
                return lbl;
            }
            else if (newPassword.Equals(oldPassword))
            {
                lbl = "Cannot be the same as the old password";
                return lbl;
            }
        
            lbl = "Actions have been done";
            return lbl;
        }
    }
}