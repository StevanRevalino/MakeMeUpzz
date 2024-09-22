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
    public partial class UpdateMakeupPage : System.Web.UI.Page
    {
        private Makeup makeup = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null &&
                Request.Cookies["user_cookie"] == null ||
                Request.QueryString["id"] == null)
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
                    getMakeupData();
                }
            }
        }

        private void getMakeupData()
        {
            int MakeupId = Convert.ToInt32(Request.QueryString["id"]);
            makeup = MakeupController.GetMakeupById(MakeupId);

            MakeupNameTB.Text = makeup.MakeupName;
            MakeupPriceTB.Text = makeup.MakeupPrice.ToString();
            MakeupWeightTB.Text = makeup.MakeupWeight.ToString();
            MakeupTypeIdTB.Text = makeup.MakeupTypeID.ToString();
            MakeupBrandIdTB.Text = makeup.MakeupBrandID.ToString();
        }

        protected void UpdateMakeupBtn_Click(object sender, EventArgs e)
        {
            int updateMakeupId = Convert.ToInt32(Request.QueryString["id"]);
            String name = MakeupNameTB.Text;

            int price = int.TryParse(MakeupPriceTB.Text, out int priceResult) ? priceResult : 0;
            int weight = int.TryParse(MakeupWeightTB.Text, out int weightResult) ? weightResult : 0;
            int typeId = int.TryParse(MakeupTypeIdTB.Text, out int typeIdResult) ? typeIdResult : 0;
            int brandId = int.TryParse(MakeupBrandIdTB.Text, out int brandIdResult) ? brandIdResult : 0;

            MakeupNameLblError.Text = MakeupController.CheckName(name);
            MakeupPriceLblError.Text = MakeupController.CheckPrice(price);
            MakeupWeightLblError.Text = MakeupController.CheckWeight(weight);
            MakeupTypeIdLblError.Text = MakeupController.CheckTypeID(typeId);
            MakeupBrandLblError.Text = MakeupController.CheckBrandID(brandId);

            if (MakeupController.CheckMakeupInput(name, price, weight, typeId, brandId))
            {
                MakeupController.UpdateMakeupById(updateMakeupId, name, price, weight, typeId, brandId);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Makeup Updated!');", true);
                
                getMakeupData();
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }
    }
}