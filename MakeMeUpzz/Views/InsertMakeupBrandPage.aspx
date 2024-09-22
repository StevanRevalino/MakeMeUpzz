<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="InsertMakeupBrandPage.aspx.cs" Inherits="MakeMeUpzz.Views.InsertMakeupBrandPage" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Insert Makeup Brand </h1>
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="< Back" OnClick="BackBtn_Click" />
    </div>

    <hr />
    <br />

    <div>
        <asp:Label ID="MakeupBrandNameLbl" runat="server" Text="NEW Makeup Brand Name: "></asp:Label>
        <asp:TextBox ID="MakeupBrandNameTB" runat="server"></asp:TextBox>
        <asp:Label ID="MakeupBrandNameLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Label ID="MakeupBrandRatingLbl" runat="server" Text="NEW Makeup Brand Rating: "></asp:Label>
        <asp:TextBox ID="MakeupBrandRatingTB" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="MakeupBrandRatingLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="InsertMakeupBrandBtn" runat="server" Text="Insert" OnClick="InsertMakeupBrandBtn_Click" />
        <asp:Label ID="InsertMBStat" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
