using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MakeMeUpzz.Controller;
using MakeMeUpzz.Dataset;
using MakeMeUpzz.Models;
using MakeMeUpzz.Report;

namespace MakeMeUpzz.Views
{
    public partial class TransactionReportPage : System.Web.UI.Page
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

                CrystalReport1 report = new CrystalReport1();
                CrystalReportViewer1.ReportSource = report;
                DataSet1 data = getData(TransactionController.GetAllTransactionHeader());
                report.SetDataSource(data);
            }
        }

        private DataSet1 getData(List<TransactionHeader> transactions)
        {
            DataSet1 data = new DataSet1();
            var Header = data.transactions;
            var Detail = data.transaction_details;
            foreach (TransactionHeader th in transactions)
            {
                var grandTotal = th.TransactionDetails.Sum(td => td.Quantity * td.Makeup.MakeupPrice);
                var hRow = Header.NewRow();

                hRow["transaction_id"] = th.TransactionID;
                hRow["user_id"] = th.UserID;
                hRow["transaction_date"] = th.TransactionDate;
                hRow["grand_total"] = grandTotal;

                Header.Rows.Add(hRow);

                foreach (TransactionDetail td in th.TransactionDetails)
                {
                    var subTotal = td.Quantity * td.Makeup.MakeupPrice;
                    var dRow = Detail.NewRow();

                    dRow["transaction_id"] = td.TransactionID;
                    dRow["item_id"] = td.MakeupID;
                    dRow["quantity"] = td.Quantity;
                    dRow["item_price"] = td.Makeup.MakeupPrice;
                    dRow["sub_total"] = subTotal;

                    Detail.Rows.Add(dRow);
                }
            }

            return data;
        }
    }
}