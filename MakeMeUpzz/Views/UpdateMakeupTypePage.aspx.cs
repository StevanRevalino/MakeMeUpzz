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
    public partial class UpdateMakeupTypePage : System.Web.UI.Page
    {
        private MakeupType makeupType = null;
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
                    getMakeupTypeData();
                }
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        private void getMakeupTypeData()
        {
            int makeupTypeId = Convert.ToInt32(Request.QueryString["id"]);
            makeupType = MakeupController.GetMakeupTypeById(makeupTypeId);
            MakeupTypeNameTB.Text = makeupType.MakeupTypeName;
        }

        protected void UpdateMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            int makeupTypeId = Convert.ToInt32(Request.QueryString["id"]);

            String makeupTypeName = MakeupTypeNameTB.Text;
            MakeupTypeNameLblError.Text = MakeupController.CheckName(makeupTypeName);

            if (MakeupController.CheckMakeupTypeInput(makeupTypeName))
            {
                MakeupController.UpdateMakeupTypeById(makeupTypeId, makeupTypeName);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('MakeupType Updated!');", true);
                
                getMakeupTypeData();
            }
        }
    }
}