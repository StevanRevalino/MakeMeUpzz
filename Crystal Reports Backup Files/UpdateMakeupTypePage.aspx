<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupTypePage.aspx.cs" Inherits="MakeMeUpzz.Views.UpdateMakeupTypePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>- Update Makeup Type <%=Request.QueryString["id"] %> -</h1>
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="< Back" OnClick="BackBtn_Click" />
    </div>
    <hr />

    <br />

    <div>
        <asp:Label ID="MakeupTypeNameLbl" runat="server" Text="Makeup Type Name: "></asp:Label>
        <asp:TextBox ID="MakeupTypeNameTB" runat="server"></asp:TextBox>
        <asp:Label ID="MakeupTypeNameLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="UpdateMakeupTypeBtn" runat="server" Text="Update" OnClick="UpdateMakeupTypeBtn_Click" />
    </div>
</asp:Content>
