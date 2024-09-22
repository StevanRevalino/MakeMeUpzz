<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="MakeMeUpzz.Views.TransactionHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>| Transaction History |</h1>

    <div>

    </div>

    <asp:GridView ID="TransactionHistoryGrid" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="TransactionHistoryGrid_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" ReadOnly="True" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="TransactionDate" ReadOnly="True" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status"></asp:BoundField>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" ShowHeader="True" HeaderText="View Detail"></asp:CommandField>
        </Columns>
    </asp:GridView>
</asp:Content>
