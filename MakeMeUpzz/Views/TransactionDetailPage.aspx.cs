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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        public TransactionHeader TransactionHeader = null;
        public List<TransactionDetail> items = null;
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
                    user = UserController.GetUserByID(Convert.ToInt32(id));
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                int transactionId = Convert.ToInt32(Request.QueryString["id"]);
                TransactionHeader = TransactionController.GetTransactionHeaderById(transactionId);

                if (TransactionHeader.UserID != user.UserID && user.UserRole.Equals("Customer"))
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
                else
                {
                    items = TransactionController.GetTransactionDetailById(transactionId);
                }
            }
        }
    }
}