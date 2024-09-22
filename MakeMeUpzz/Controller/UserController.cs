using MakeMeUpzz.Handler;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class UserController
    {
        public static User GetUserByUsernameAndPassword(String username, String password)
        {
            return UserHandler.GetUserByUsernameAndPassword(username, password);
        }

        public static List<User> GetAllCustomerUser()
        {
            return UserHandler.GetAllCustomerUser();
        }

        public static User GetUserByID(int id)
        {
            return UserHandler.GetUserByID(id);
        }

        public static String GetUserPasswordById(int UserID)
        {
            return UserHandler.GetUserPasswordById(UserID);
        }

        public static void UpdateUserProfileByID(int UserID, String UserName, String UserEmail, DateTime UserDOB, String UserGender)
        {
            UserHandler.UpdateUserProfileByID(UserID, UserName, UserEmail, UserDOB, UserGender);
        }

        public static void UpdateUserPasswordById(int UserID, String NewPassword)
        {
            UserHandler.UpdateUserPasswordById(UserID, NewPassword);
        }

        public static bool ValidPassBeforeUpdate(int UserID, string OldPassword)
        {
            return GetUserPasswordById(UserID).Equals(OldPassword);
        }

        public static string CheckPassword(String password)
        {
            String response = "";
            if (password.Equals(""))
            {
                response = "Please input your Old Password";
            }
            return response;
        }

        public static bool IsEligibleToUpdate(String UserName, String UserEmail, DateTime UserDOB, String UserGender)
        {
            if (UserName.Equals("") &&
                UserRegistrationController.CheckEmail(UserEmail).Equals("") &&
                UserRegistrationController.CheckDOB(UserDOB).Equals("") &&
                UserRegistrationController.CheckGender(UserGender).Equals(""))
            {
                return true;
            }
            return false;
        }
    }
}