<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="InsertMakeupTypePage.aspx.cs" Inherits="MakeMeUpzz.Views.InsertMakeupTypePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Insert Makeup Type</h1>
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
         <asp:Button ID="InsertMakeupTypeBtn" runat="server" Text="Insert" OnClick="InsertMakeupTypeBtn_Click" />
     </div>
</asp:Content>
