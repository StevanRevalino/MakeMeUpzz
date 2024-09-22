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
    public partial class TransactionHandlePage : System.Web.UI.Page
    {
        private List<TransactionHeader> transactionList = null;
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

                getTransactionList();
            }
        }

        private void getTransactionList()
        {
            transactionList = TransactionController.GetAllTransactionHeader();
            TransactionHistoryList.DataSource = transactionList;
            TransactionHistoryList.DataBind();
        }

        protected void TransactionHistoryList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = TransactionHistoryList.Rows[e.NewEditIndex];
            int transactionId = Convert.ToInt32(row.Cells[0].Text);
            TransactionController.HandleTransaction(transactionId);
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Transaction Handled!');", true);

            getTransactionList();

        }

        protected void TransactionHistoryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Button handleButton = e.Row.Cells[4].Controls[0] as Button;

                if (status.Equals("handled"))
                {
                    handleButton.Visible = false;
                }
            }

        }
    }
}