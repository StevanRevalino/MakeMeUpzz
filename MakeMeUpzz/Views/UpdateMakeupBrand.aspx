<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupBrand.aspx.cs" Inherits="MakeMeUpzz.Views.UpdateMakeupBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>| Update Makeup Brand <%=Request.QueryString["id"] %> |</h1>
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="< Back" OnClick="BackBtn_Click" />
    </div>
    <hr />

    <div>
        <asp:Label ID="MakeupBrandNameLbl" runat="server" Text="Makeup Brand Name: "></asp:Label>
        <asp:TextBox ID="MakeupBrandNameTB" runat="server"></asp:TextBox>
        <asp:Label ID="MakeupBrandNameLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Label ID="MakeupBrandRatingLbl" runat="server" Text="Makeup Brand Rating: "></asp:Label>
        <asp:TextBox ID="MakeupBrandRatingTB" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="MakeupBrandRatingLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="UpdateMakeupBrandBtn" runat="server" Text="Insert" OnClick="UpdateMakeupBrandBtn_Click" />
    </div>
</asp:Content>
