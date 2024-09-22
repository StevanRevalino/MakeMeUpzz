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
    public partial class UpdateMakeupBrand : System.Web.UI.Page
    {
        private MakeupBrand makeupBrand = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null || Request.QueryString["id"] == null)
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

                if (!IsPostBack)
                {
                    getMakeupBrandData();
                }
            }
        }

        private void getMakeupBrandData()
        {
            int MakeupBrandId = Convert.ToInt32(Request.QueryString["id"]);

            makeupBrand = MakeupController.GetMakeupBrandById(MakeupBrandId);
            MakeupBrandNameTB.Text = makeupBrand.MakeupBrandName;
            MakeupBrandRatingTB.Text = makeupBrand.MakeupBrandRating.ToString();
        }

        protected void UpdateMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            int updateMakeupBrandId = Convert.ToInt32(Request.QueryString["id"]);
            String makeupBrandName = MakeupBrandNameTB.Text;
            int makeupBrandRating = int.TryParse(MakeupBrandRatingTB.Text, out int ratingResult) ? ratingResult : -1;

            MakeupBrandNameLblError.Text = MakeupController.CheckName(makeupBrandName);
            MakeupBrandRatingLblError.Text = MakeupController.CheckRating(makeupBrandRating);

            if (MakeupController.CheckMakeupBrandInput(makeupBrandName, makeupBrandRating))
            {
                MakeupController.UpdateMakeupBrandById(updateMakeupBrandId, makeupBrandName, makeupBrandRating);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Makeup Brand Updated!');", true);
                
                getMakeupBrandData();
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }
    }
}