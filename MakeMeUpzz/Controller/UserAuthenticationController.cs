﻿using MakeMeUpzz.Handler;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class UserAuthenticationController
    {
        public static String CheckUsername(string Username)
        {
            String response = "";
            if (Username.Equals(""))
            {
                response = "Username cannot be empty";
            }
            return response;
        }

        public static String CheckPassword(string Password)
        {
            String response = "";
            if (Password.Equals(""))
            {
                response = "Password cannot be empty";
            }
            return response;
        }

        public static String Login(String Username, String Password)
        {
            String response = CheckUsername(Username);
            if (response.Equals(""))
            {
                response = CheckPassword(Password);
            }
            if (response.Equals(""))
            {
                response = UserAuthenticationHandler.AuthenticateLogin(Username, Password);
            }
            return response;
        }
    }
}