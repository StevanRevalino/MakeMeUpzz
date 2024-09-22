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
    public partial class InsertMakeupBrandPage : System.Web.UI.Page
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

        protected void InsertMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            String makeupBrandName = MakeupBrandNameTB.Text;
            int makeupBrandRating = int.TryParse(MakeupBrandRatingTB.Text, out int priceResult) ? priceResult : -1;

            MakeupBrandNameLblError.Text = MakeupController.CheckName(makeupBrandName);
            MakeupBrandRatingLblError.Text = MakeupController.CheckRating(makeupBrandRating);

            if (MakeupController.CheckMakeupBrandInput(makeupBrandName, makeupBrandRating))
            {
                MakeupController.CreateNewMakeupBrand(makeupBrandName, makeupBrandRating);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Makeup Brand Added!');", true);

                MakeupBrandNameTB.Text = "";
                MakeupBrandRatingTB.Text = "";
            }
        }
    }
}