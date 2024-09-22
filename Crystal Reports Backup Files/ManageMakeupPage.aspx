    <%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Site1.Master" AutoEventWireup="true" CodeBehind="ManageMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Views.ManageMakeupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>| Manage Makeup |</h1>
    <hr />

    <div>
        <h2>Makeup Table</h2>

        <asp:GridView ID="MakeupGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupGV_RowDeleting" OnRowEditing="MakeupGV_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupTypeID" HeaderText="Type ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupBrandID" HeaderText="Brand ID" SortExpression="MakeupBrandID" />
                <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <br />
        <div>
            <asp:Button ID="MakeupInsertBtn" runat="server" Text="Insert Makeup" Width="155px" OnClick="MakeupInsertBtn_Click" />
        </div>
    </div>

    <hr />

    <div>
        <h2>MakeupType Table</h2>
        
        <asp:GridView ID="MakeupTypeGV" runat="server" AutoGenerateColumns="False" OnRowEditing="MakeupTypeGV_RowEditing" OnRowDeleting="MakeupTypeGV_RowDeleting">
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Name" SortExpression="MakeupTypeName" />
                <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>

        <br />
        <div>
            <asp:Button ID="MakeupTypeInsertBtn" runat="server" Text="Insert Makeup Type" Width="208px" OnClick="MakeupTypeInsertBtn_Click" />
        </div>
    </div>

    <hr />

    <div>
        <h2>MakeupBrand Table</h2>
        
        <asp:GridView ID="MakeupBrandGV" runat="server" AutoGenerateColumns="False" OnRowEditing="MakeupBrandGV_RowEditing" OnRowDeleting="MakeupBrandGV_RowDeleting">
            <Columns>
                <asp:BoundField DataField="MakeupBrandID" HeaderText="ID" SortExpression="MakeupBrandID" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Name" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="Rating" SortExpression="MakeupBrandRating" />
                <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <br />
        <div>
            <asp:Button ID="MakeupBrandInsertBtn" runat="server" Text="Insert Makeup Brand" Width="208px" OnClick="MakeupBrandInsertBtn_Click" />
        </div>
    </div>

</asp:Content>
