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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var id = Request.Cookies["user_cookie"].Value;
                    user = UserController.GetUserByID(Convert.ToInt32(id));
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                RoleLbl.Text = user.UserRole;
                UsernameLbl.Text = user.Username;

                if (user.UserRole.Equals("Admin"))
                {
                    CustomerListLbl.Visible = true;
                    CustomerList.Visible = true;
                    BindCustomerList();
                }
            }
        }

        private void BindCustomerList()
        {
            List<User> customerList = UserController.GetAllCustomerUser();
            CustomerList.DataSource = customerList;
            CustomerList.DataBind();
        }
    }
}