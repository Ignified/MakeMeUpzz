using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class UserRepository
    {
        private static MakeMeUpzzDatabaseEntities1 db = DatabaseSingleton.getInstance();

        public static List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public static List<String> GetAllUsernames()
        {
            return(from x in db.Users select x.Username).ToList();
        }

        public static List<String> GetAllPasswords()
        {
            return(from x in db.Users select x.UserPassword).ToList();
        }

        public static User GetUserfromUsernamePassword(String username, String password)
        {
            return (from x in db.Users where x.Username.Equals(username) && x.UserPassword.Equals(password) select x).FirstOrDefault();
        }

        public static int GetLastUserID()
        {
            return(from x in db.Users select x.UserID).ToList().LastOrDefault();
        }

        public static void InsertUser(int UserID, String Username, String UserEmail, DateTime UserDOB,
            String UserGender, String UserRole, String UserPassword)
        {
            User user = UserFactory.Create(UserID, Username, UserEmail, UserDOB, UserGender,
                UserRole, UserPassword);
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static User FindUserbyID(int UserID)
        {
            User user = db.Users.Find(UserID);
            return user;
        }

        public static User GetUserfromID(int UserID)
        {
            return (from x in db.Users where x.UserID.Equals(UserID) select x).FirstOrDefault();
        }

        public static String GetPasswordfromID(int UserID)
        {
            return (from x in db.Users where x.UserID.Equals(UserID) select x.UserPassword).ToList().FirstOrDefault();
        }

        public static void UpdateUser(int UserID, String Username, String UserEmail, DateTime UserDOB,
            String UserGender, String UserRole, String UserPassword)
        {
            User updateUser = FindUserbyID(UserID);
            updateUser.UserID = UserID;
            updateUser.Username = Username;
            updateUser.UserEmail = UserEmail;
            updateUser.UserDOB = UserDOB;
            updateUser.UserGender = UserGender;
            updateUser.UserRole = UserRole;
            updateUser.UserPassword = UserPassword;
            db.SaveChanges();
        }
    }
}