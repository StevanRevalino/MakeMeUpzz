﻿using MakeMeUpzz.Controller;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.ForeColor = System.Drawing.Color.Red;
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            String Status = "";
            String Username = UsernameTB.Text;
            String Password = PasswordTB.Text;
            bool isRemember = RememberMeCB.Checked;

            Status = UserAuthenticationController.Login(Username, Password);

            if (Status.Equals("Login Success"))
            {
                User user = UserController.GetUserByUsernameAndPassword(Username, Password);
                Session["user"] = user;
                if (isRemember)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                ErrorLbl.Text = Status;
            }
        }

        protected void RegisterNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }
    }
}