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
    public partial class ManageMakeupPage : System.Web.UI.Page
    {
        public List<Makeup> makeups = null;
        public List<MakeupType> makeupsType = null;
        public List<MakeupBrand> makeupsBrand = null;
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
                    user = UserController.GetUserByID(Convert.ToInt32(id));
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                if (!IsPostBack)
                {
                    getMakeupGV();
                    getMakeupTGV();
                    getMakeupBGV();
                }
            }
        }

        private void getMakeupGV()
        {
            makeups = MakeupController.GetAllMakeup();
            MakeupGV.DataSource = makeups;
            MakeupGV.DataBind();
        }

        private void getMakeupTGV()
        {
            makeupsType = MakeupController.GetAllMakeupType();
            MakeupTypeGV.DataSource = makeupsType;
            MakeupTypeGV.DataBind();
        }

        private void getMakeupBGV()
        {
            makeupsBrand = MakeupController.GetAllMakeupBrand();
            MakeupBrandGV.DataSource = makeupsBrand.OrderByDescending(makeupsBrand => makeupsBrand.MakeupBrandRating);
            MakeupBrandGV.DataBind();
        }

        protected void MakeupGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupGV.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("~/Views/UpdateMakeupPage.aspx?id=" + id);
        }

        protected void MakeupGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            MakeupController.RemoveMakeupByID(id);
            getMakeupGV();
        }

        protected void MakeupInsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupPage.aspx");
        }

        protected void MakeupTypeGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupTypeGV.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("~/Views/UpdateMakeupTypePage.aspx?id=" + id);
        }

        protected void MakeupTypeGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupTypeGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            MakeupController.RemoveMakeupTypeById(id);
            getMakeupTGV();
        }

        protected void MakeupTypeInsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupTypePage.aspx");
        }

        protected void MakeupBrandGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupBrandGV.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("~/Views/UpdateMakeupBrandPage.aspx?id=" + id);
        }

        protected void MakeupBrandGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupBrandGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            MakeupController.DeleteMakeupBrandById(id);
            getMakeupBGV();
        }

        protected void MakeupBrandInsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupBrandPage.aspx");
        }
    }
}