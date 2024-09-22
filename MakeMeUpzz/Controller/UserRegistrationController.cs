﻿using MakeMeUpzz.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class UserRegistrationController
    {
        public static String CheckUsername(String Username)
        {
            String response = "";
            if (Username.Equals(""))
            {
                response = "Username cannot be empty";
            }
            else if (Username.Length < 5 || Username.Length > 15)
            {
                response = "Username length must be between 5 and 15 characters";
            }
            else if (UserRegistHandler.DoesUsernameExist(Username))
            {
                response = "Username already existed";
            }
            return response;
        }

        public static String CheckEmail(String UserEmail)
        {
            String response = "";
            if (UserEmail.Equals(""))
            {
                response = "Email cannot be empty";
            }
            else if (!(UserEmail.EndsWith(".com")))
            {
                response = "Email must ends with .com";
            }
            return response;
        }

        public static String CheckGender(String UserGender)
        {
            String response = "";
            if (UserGender.Equals(""))
            {
                response = "Gender must be chosen";
            }
            return response;
        }

        public static String CheckPassword(String Password)
        {
            String response = "";
            if (Password.Equals(""))
            {
                response = "Password cannot be empty";
            }
            else if (!(Password.All(char.IsLetterOrDigit)))
            {
                response = "Password must be alphanumeric";
            }
            return response;
        }

        public static String CheckConfirmationPassword(String Password, String ConfirmationPassword)
        {
            String response = "";
            if (ConfirmationPassword.Equals(""))
            {
                response = "Confirmation Password cannot be empty";
            }
            else if (!(ConfirmationPassword.Equals(Password)))
            {
                response = "Password Not match";
            }
            return response;
        }

        public static String CheckDOB(DateTime UserDOB)
        {
            String response = "";
            if (UserDOB == DateTime.MinValue)
            {
                response = "Date of Birth cannot be empty";
            }
            return response;
        }

        public static bool IsEligible(String Username, String UserEmail, String UserGender, String Password, String ConfirmationPassword, DateTime UserDOB)
        {
            if (CheckUsername(Username).Equals("") &&
                CheckEmail(UserEmail).Equals("") &&
                CheckGender(UserGender).Equals("") &&
                CheckPassword(Password).Equals("") &&
                CheckConfirmationPassword(Password, ConfirmationPassword).Equals("") &&
                CheckDOB(UserDOB).Equals(""))
            {
                return true;
            }
            return false;
        }

        public static void Registrate(String Username, String UserEmail, String UserGender, String Password, DateTime UserDOB)
        {
            UserRegistHandler.RegistrateUser(Username, UserEmail, UserDOB, UserGender, "Customer", Password);
        }
    }
}