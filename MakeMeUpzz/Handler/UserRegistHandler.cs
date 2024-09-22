using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class UserRegistHandler
    {
        public static bool DoesUsernameExist(String username)
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.DoesUsernameExist(username);
        }

        public static int GetLastUserID()
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.GetLastUserID();
        }

        public static void RegistrateUser(String UserName, String UserEmail, DateTime UserDOB, String UserGender, String UserRole, String UserPassword)
        {
            UserRepository userRepo = new UserRepository();
            userRepo.CreateUser(GenerateUserID(), UserName, UserEmail, UserDOB, UserGender, UserRole, UserPassword);
        }

        public static int GenerateUserID()
        {
            int id = UserRegistHandler.GetLastUserID();
            
            if(id == 0 )
            {
                id = 1;
            }
            else
            {
                id++;
            }

            return id;
        }
    }

}
