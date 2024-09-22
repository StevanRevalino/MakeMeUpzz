<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="MakeMeUpzz.Views.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>| Transaction <%=Request.QueryString["id"] %> |</h1>
    <hr />

    <table style="width: 500px" border="2">
        <tr>
            <td>Date</td>
            <td><%=TransactionHeader.TransactionDate %></td>
        </tr>
        <tr>
            <td>Buyer</td>
            <td><%=TransactionHeader.User.Username %></td>
        </tr>
        <tr>
            <td>Total Product</td>
            <td><%=TransactionHeader.TransactionDetails.Count() %></td>
        </tr>
        <tr>
            <td>Total Money Spent</td>
            <td><%=TransactionHeader.TransactionDetails.Sum(tran => tran.Quantity * tran.Makeup.MakeupPrice) %></td>
        </tr>
    </table>

    <br />   
    
    <div>
         <table style="width: 1000px" border="2">
         <tr>
             <th>Makeup</th>
             <th>MakeupPrice</th>
             <th>MakeupType</th>
             <th>MakeupBrand</th>
             <th>Quantity</th>
             <th>Subtotal</th>
         </tr>

         <%foreach (var x in TransactionHeader.TransactionDetails)
             {%>
         <tr>
             <td><%=x.Makeup.MakeupName %></td>
             <td><%=x.Makeup.MakeupPrice %></td>
             <td><%=x.Makeup.MakeupType.MakeupTypeName %></td>
             <td><%=x.Makeup.MakeupBrand.MakeupBrandName%></td>
             <td><%=x.Quantity %></td>
             <td><%=x.Makeup.MakeupPrice * x.Quantity%></td>
         </tr>
         <%} %>
         <tr>
             <td colspan="5">Total</td>
             <td colspan="1"><%=TransactionHeader.TransactionDetails.Sum(tran => tran.Quantity * tran.Makeup.MakeupPrice) %></td>
         </tr>
     </table>
    </div>
   
        
</asp:Content>
