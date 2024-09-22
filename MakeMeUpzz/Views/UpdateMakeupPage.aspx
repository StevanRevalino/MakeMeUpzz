<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Views.UpdateMakeupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>- Update Makeup <%=Request.QueryString["id"] %> -</h1>
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="< Back" OnClick="BackBtn_Click" />
    </div>
    <hr />

    <br />

    <div>
        <asp:Label ID="MakeupNameLbl" runat="server" Text="Makeup Name: "></asp:Label>
        <asp:TextBox ID="MakeupNameTB" runat="server"></asp:TextBox>
        <asp:Label ID="MakeupNameLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Label ID="MakeupPriceLbl" runat="server" Text="Makeup Price: "></asp:Label>
        <asp:TextBox ID="MakeupPriceTB" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="MakeupPriceLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Label ID="MakeupWeightLbl" runat="server" Text="Makeup Weight: "></asp:Label>
        <asp:TextBox ID="MakeupWeightTB" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="MakeupWeightLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Label ID="MakeupTypeIdLbl" runat="server" Text="Makeup Type Id: "></asp:Label>
        <asp:TextBox ID="MakeupTypeIdTB" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="MakeupTypeIdLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Label ID="MakeupBrandIdLbl" runat="server" Text="Makeup Brand Id: "></asp:Label>
        <asp:TextBox ID="MakeupBrandIdTB" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="MakeupBrandLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="UpdateMakeupBtn" runat="server" Text="Update" OnClick="UpdateMakeupBtn_Click" />
    </div>
</asp:Content>
