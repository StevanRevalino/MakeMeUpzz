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
    public partial class OrderMakeupPage : System.Web.UI.Page
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

                if (!IsPostBack)
                {
                    List<Makeup> makeupList = MakeupController.GetAllMakeup();
                    MakeupList.DataSource = makeupList;
                    MakeupList.DataBind();

                    MakeupList.Columns[0].Visible = false;
                }

                getShoppingSummary(user.UserID);
            }
        }

        private void getShoppingSummary(int UserID)
        {
            List<Cart> userCartSummary = CartController.GetUserCart(UserID);

            ShoppingSummary.DataSource = userCartSummary;
            ShoppingSummary.DataBind();
        }

        protected void MakeupList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIdx = Convert.ToInt32(e.CommandArgument);
            TextBox quantityTb = (TextBox)MakeupList.Rows[rowIdx].FindControl("QuantityTB");
            Label errLabel = (Label)MakeupList.Rows[rowIdx].FindControl("QuantityErrLbl");

            GridViewRow row = MakeupList.Rows[rowIdx];
            if (quantityTb.Text.Equals(""))
            {
                errLabel.Visible = true;
                errLabel.Text = "Quantity cannot be empty";
            }
            else
            {
                int quantity = Convert.ToInt32(quantityTb.Text);
                if (quantity <=0)
                {
                    errLabel.Visible = true;
                    errLabel.Text = "Quantity must be bigger than 0";
                }
                else
                {
                    errLabel.Visible = false;

                    User currUser = (User)Session["user"];
                    int userId = currUser.UserID;
                    int choosenMakeupId = Convert.ToInt32(row.Cells[0].Text);

                    CartController.CreateCartItem(userId, choosenMakeupId, quantity);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Item(s) added to cart!');", true);

                    //reset Textbox
                    quantityTb.Text = "";
                    getShoppingSummary(userId);
                }
            }
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            int userID = user.UserID;

            CartController.DeleteUserCart(userID);
            getShoppingSummary(userID);
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            int userID = user.UserID;

            int transactionId = TransactionController.GenerateTransactionHeaderId();
            List<Cart> userCart = CartController.GetUserCart(userID);
            
            //new Header
            TransactionController.CreateTransactionHeader(userID);
            //new Detail
            foreach (Cart item in userCart)
            {
                TransactionController.CreateTransactionDetail(transactionId, item.MakeupID, item.Quantity);
            }

            CartController.DeleteUserCart(userID);

            getShoppingSummary(userID);

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Order Created!');", true);
        }
    }
}