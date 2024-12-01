using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class UserHandler
    {
        public static List<User> GetAllUsers()
        {
            return UserRepository.GetAllUsers();
        }

        public static List<String> GetAllUsernames()
        {
            return UserRepository.GetAllUsernames();
        }

        public static int GetLastUserID()
        {
            return UserRepository.GetLastUserID();
        }

        public static User FindUserbyID(int userID)
        {
            return UserRepository.FindUserbyID(userID);
        }

        public static User GetUserfromUsernamePassword(String username, String password) { 
            return UserRepository.GetUserfromUsernamePassword(username, password);
        }

        public static void InsertUser(int UserID, String Username, String UserEmail, DateTime UserDOB,
            String UserGender, String UserRole, String UserPassword)
        {
            UserRepository.InsertUser(UserID, Username, UserEmail, UserDOB, UserGender,
                UserRole, UserPassword);
        }

        public static User GetUserfromID(int UserID)
        {
            return UserRepository.GetUserfromID(UserID);
        }

        public static String GetPasswordfromID(int UserID)
        {
            return UserRepository.GetPasswordfromID(UserID);
        }

        public static void UpdateUser(int UserID, String Username, String UserEmail, DateTime UserDOB,
            String UserGender, String UserRole, String UserPassword)
        {
            UserRepository.UpdateUser(UserID, Username, UserEmail, UserDOB, UserGender, 
                UserRole, UserPassword);
        }
    }
}