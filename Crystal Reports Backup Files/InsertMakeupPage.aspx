<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="InsertMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Views.InsertMakeupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Insert Makeup </h1>
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="< Back" OnClick="BackBtn_Click" />
    </div>
    <hr />

    <div>
        <div>
            <asp:Label ID="MakeupNameLbl" runat="server" Text="NEW Makeup Name: "></asp:Label>
            <asp:TextBox ID="MakeupNameTB" runat="server"></asp:TextBox>
            <asp:Label ID="MakeupNameLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Label ID="MakeupPriceLbl" runat="server" Text="NEW Makeup Price: "></asp:Label>
            <asp:TextBox ID="MakeupPriceTB" runat="server" TextMode="Number"></asp:TextBox>
            <asp:Label ID="MakeupPriceLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Label ID="MakeupWeightLbl" runat="server" Text="NEW Makeup Weight: "></asp:Label>
            <asp:TextBox ID="MakeupWeightTB" runat="server" TextMode="Number"></asp:TextBox>
            <asp:Label ID="MakeupWeightLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Label ID="MakeupTypeIdLbl" runat="server" Text="NEW Makeup Type Id: "></asp:Label>
            <asp:TextBox ID="MakeupTypeIdTB" runat="server" TextMode="Number"></asp:TextBox>
            <asp:Label ID="MakeupTypeIdLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Label ID="MakeupBrandIdLbl" runat="server" Text="NEW Makeup Brand Id: "></asp:Label>
            <asp:TextBox ID="MakeupBrandIdTB" runat="server" TextMode="Number"></asp:TextBox>
            <asp:Label ID="MakeupBrandLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="InsertMakeupBtn" runat="server" Text="Insert" OnClick="InsertMakeupBtn_Click" />
        </div>
    </div>

</asp:Content>
