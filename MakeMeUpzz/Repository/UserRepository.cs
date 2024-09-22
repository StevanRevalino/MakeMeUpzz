using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class UserRepository
    {

        private static MakeMeUpzzDBEntities2 db = DatabaseSingleton.GetInstance();

        //create
        public void CreateUser(int UserID, String Username, String UserEmail, DateTime UserDOB, String UserGender, String UserRole, String UserPassword)
        {
            User user = UserFactory.Create(UserID,Username,UserEmail,UserDOB,UserGender,UserRole,UserPassword);
            db.Users.Add(user);
            db.SaveChanges();
        }
           
        //updateProfile
        public void UpdateUserProfileByID(int UserID, String UserName, String UserEmail, DateTime UserDOB, String UserGender)
        {
            User UpdateUser = GetUserByID(UserID);
            UpdateUser.Username = UserName;
            UpdateUser.UserEmail = UserEmail;
            UpdateUser.UserDOB = UserDOB;
            UpdateUser.UserGender = UserGender;
            db.SaveChanges();
        }

        //updatePass
        public void UpdateUserPasswordById(int UserID, String NewPassword)
        {
            User UpdateUser = GetUserByID(UserID);
            UpdateUser.UserPassword = NewPassword;
            db.SaveChanges();
        }

        public User GetUserByID(int id)
        {
            return (from u in db.Users where u.UserID == id select u).FirstOrDefault();
        }

        public List<User> GetAllUser()
        {
            return (from u in db.Users select u).ToList();
        }

        public List<User> GetAllCustomerUser()
        {
            return db.Users.Where(user => user.UserRole.Equals("Customer")).ToList();
        }

        public User GetUserByUsernameAndPassword(String Username, String Password)
        {
            return (from u
                    in db.Users
                    where u.Username.Equals(Username) && u.UserPassword.Equals(Password)
                    select u).FirstOrDefault();
        }

        public bool DoesUsernameExist(String Username)
        {
            return GetAllUser().Any(u => u.Username == Username);
        }

        public String GetUserPassword(String Username)
        {
            return (from u
                    in db.Users
                    where u.Username.Equals(Username)
                    select u.UserPassword).FirstOrDefault();
        }

        public String GetUserPasswordById(int id)
        {
            return (from u
                    in db.Users
                    where u.UserID.Equals(id)
                    select u.UserPassword).FirstOrDefault();
        }

        public int GetLastUserID()
        {
            return (from u
                    in db.Users
                    select u.UserID).ToList().LastOrDefault();
        }

    }
}