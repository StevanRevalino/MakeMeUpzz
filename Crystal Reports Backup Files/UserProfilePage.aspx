<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfilePage.aspx.cs" Inherits="MakeMeUpzz.Views.UserProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>| Profile |</h1>
    <div>
        <h2>Update Profile</h2>

        <div>
            <asp:Label ID="Usernamelbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
            <asp:Label ID="usernameErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <asp:Label ID="Emaillbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTB" runat="server"></asp:TextBox>
            <asp:Label ID="emailErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <asp:Label ID="Doblbl" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar ID="UserDOBCalendar" runat="server" OnSelectionChanged="UserDOBCalendar_SelectionChanged"></asp:Calendar>
            <asp:TextBox ID="DobTB" runat="server" Enabled="false"></asp:TextBox>
            <asp:Label ID="DOBErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <asp:Label ID="Genderlbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="GenderRB" runat="server">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="genderErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <asp:Label ID="Rolelbl" runat="server" Text="Role"></asp:Label>
            <asp:TextBox ID="RoleTB" runat="server" Enabled="false"></asp:TextBox>
        </div>

        <asp:Button ID="UpdateProfileBtn" runat="server" Text="Update Profile" OnClick="UpdateProfileBtn_Click" />
    </div>

    <hr />

    <div>
        <h2>Change Password</h2>
        <div>
            <asp:Label ID="OldPasswordlbl" runat="server" Text="Old Password"></asp:Label>
            <asp:TextBox ID="OldPasswordTB" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="OldPasswordErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Label ID="NewPasswordlbl" runat="server" Text="New Password"></asp:Label>
            <asp:TextBox ID="NewPasswordTB" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="NewPasswordErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="UpdatePasswordBtn" runat="server" Text="Update Password" OnClick="UpdatePasswordBtn_Click" />
        </div>
    </div>
</asp:Content>
