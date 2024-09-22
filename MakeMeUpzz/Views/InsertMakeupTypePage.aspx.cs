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
    public partial class InsertMakeupTypePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var id = Request.Cookies["user_cookie"].Value;
                    user = UserController.GetUserByID(int.Parse(id));
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        protected void InsertMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            String makeupTypeName = MakeupTypeNameTB.Text;
            MakeupTypeNameLblError.Text = MakeupController.CheckName(makeupTypeName);

            if (MakeupController.CheckMakeupTypeInput(makeupTypeName))
            {
                MakeupController.CreateNewMakeupType(makeupTypeName);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Makeup Type Added!');", true);

                // reset isi textbox
                MakeupTypeNameTB.Text = "";
            }
        }
    }
}