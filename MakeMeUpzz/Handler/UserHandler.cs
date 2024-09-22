using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class UserHandler
    {
        public static User GetUserByUsernameAndPassword(String username, String password)
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.GetUserByUsernameAndPassword(username, password);
        }

        public static List<User> GetAllCustomerUser()
        {
            UserRepository customerRepo = new UserRepository();
            return customerRepo.GetAllCustomerUser();
        }

        public static User GetUserByID(int id)
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.GetUserByID(id);
        }

        public static String GetUserPasswordById(int UserID)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetUserPasswordById(UserID);
        }

        public static void UpdateUserProfileByID(int UserID, String UserName, String UserEmail, DateTime UserDOB, String UserGender)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.UpdateUserProfileByID(UserID, UserName, UserEmail, UserDOB, UserGender);
        }

        public static void UpdateUserPasswordById(int UserID, String NewPassword)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.UpdateUserPasswordById(UserID, NewPassword);
        }
    }
}