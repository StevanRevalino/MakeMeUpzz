using MakeMeUpzz.Controller;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class UserProfilePage : System.Web.UI.Page
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

                if (!IsPostBack)
                {
                    UsernameTB.Text = user.Username;
                    EmailTB.Text = user.UserEmail;
                    UserDOBCalendar.SelectedDate = user.UserDOB;
                    DobTB.Text = user.UserDOB.ToString("dd MMMM yyyy");
                    GenderRB.SelectedValue = user.UserGender;
                    RoleTB.Text = user.UserRole;
                }
            }
        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            String newUsername = UsernameTB.Text;
            String newEmail = EmailTB.Text;
            DateTime newDOB = UserDOBCalendar.SelectedDate;
            String newGender = GenderRB.SelectedValue;

            if (newUsername.Equals(user.Username) == false)
            {
                usernameErr.Text = UserRegistrationController.CheckUsername(newUsername);
            }

            emailErr.Text = UserRegistrationController.CheckEmail(newEmail);
            DOBErr.Text = UserRegistrationController.CheckDOB(newDOB);
            genderErr.Text = UserRegistrationController.CheckGender(newGender);

            if (UserController.IsEligibleToUpdate(usernameErr.Text, newEmail, newDOB, newGender))
            {
                UserController.UpdateUserProfileByID(user.UserID, newUsername, newEmail, newDOB, newGender);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Profile Updated!');", true);
            }
        }

        protected void UserDOBCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DobTB.Text = UserDOBCalendar.SelectedDate.ToString("dd MMMM yyyy");
        }

        protected void UpdatePasswordBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            String oldPassword = OldPasswordTB.Text;
            String newPassword = NewPasswordTB.Text;

            if (UserController.ValidPassBeforeUpdate(user.UserID, oldPassword) == false)
            {
                OldPasswordErr.Text = "Incorrect password";
            }
            else if (string.IsNullOrWhiteSpace(newPassword))
            {
                NewPasswordErr.Text = "New password cannot be empty";
            }
            else if (UserController.ValidPassBeforeUpdate(user.UserID, newPassword) == true)
            {
                NewPasswordErr.Text = "The new password cannot be the same as Old password";
            }
            else
            {
                UserController.UpdateUserPasswordById(user.UserID, newPassword);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Password Updated!');", true);

            }
        }
    }
}