<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MakeMeUpzz.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>| Homepage |</h1>
    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text=""></asp:Label>
    </div>
        <asp:Label ID="Label1" runat="server" Text="----as----"></asp:Label>
    <div>
        <asp:Label ID="RoleLbl" runat="server" Text=""></asp:Label>
    </div>


    <hr />

    <asp:Label ID="CustomerListLbl" runat="server" Text="CustomerList" Visible="false"></asp:Label>
    <asp:GridView ID="CustomerList" runat="server" AutoGenerateColumns="false" Visible="false">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username"></asp:BoundField>
            <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" ReadOnly="True" SortExpression="UserEmail"></asp:BoundField>
            <asp:BoundField DataField="UserDOB" HeaderText="UserDOB" ReadOnly="True" SortExpression="UserDOB"></asp:BoundField>
            <asp:BoundField DataField="UserGender" HeaderText="UserGender" ReadOnly="True" SortExpression="UserGender"></asp:BoundField>
        </Columns>
    </asp:GridView>

</asp:Content>
