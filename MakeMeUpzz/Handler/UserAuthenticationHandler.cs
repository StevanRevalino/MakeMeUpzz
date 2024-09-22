using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class UserAuthenticationHandler
    {
        public static String AuthenticateLogin(String username, String password)
        {
            String response = "";
            UserRepository userRepo = new UserRepository();
            User user = userRepo.GetUserByUsernameAndPassword(username, password);

            if (userRepo.DoesUsernameExist(username) == false)
            {
                response = "Username does not exist";
            }
            else if (!(userRepo.GetUserPassword(username).Equals(password)))
            {
                response = "Password Incorrect";
            }
            else if (user == null)
            {
                response = "Login Failed";
            }
            else
            {
                response = "Login Success";
            }
            return response;

        }
    }
}