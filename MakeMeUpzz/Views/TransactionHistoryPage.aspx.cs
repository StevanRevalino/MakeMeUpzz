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
    public partial class TransactionHistoryPage : System.Web.UI.Page
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
                    user = UserController.GetUserByID(Convert.ToInt32(id));
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                if (user.UserRole.Equals("Admin"))
                {
                    getTransactionHistory(TransactionController.GetAllTransactionHeader());
                }
                else if (user.UserRole.Equals("Customer"))
                {
                    getTransactionHistory(TransactionController.GetUserTransactionHeader(user.UserID));
                    TransactionHistoryGrid.Columns[1].Visible = false;
                }
                else
                {
                    return;
                }
            }
        }

        private void getTransactionHistory(List<TransactionHeader> transactionList)
        {
            TransactionHistoryGrid.DataSource = transactionList;
            TransactionHistoryGrid.DataBind();
        }

        protected void TransactionHistoryGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int transactionId = Convert.ToInt32(TransactionHistoryGrid.SelectedRow.Cells[0].Text);
            Response.Redirect("~/Views/TransactionDetailPage.aspx?id=" + transactionId);
        }
    }
}