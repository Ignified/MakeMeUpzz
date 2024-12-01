<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Viewss.ManageMakeupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridview-header a {
            text-decoration: none;
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ManageMakeupView" runat="server">
        <h1>Manage Makeup</h1>
        <hr />
        <h2>Makeup Table</h2>
        <asp:GridView ID="MakeupGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupGV_RowDeleting" OnRowEditing="MakeupGV_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="MakeupID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="MakeupName" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="MakeupPrice" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="MakeupWeight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupType.MakeupTypeID" HeaderText="MakeupTypeID" SortExpression="MakeupType.MakeupTypeID" />
                <asp:BoundField DataField="MakeupBrand.MakeupBrandID" HeaderText="MakeupBrandID" SortExpression="MakeupBrand.MakeupBrandID" />
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <h2>Makeup Type Table</h2>
        <asp:GridView ID="MakeupTypeGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupTypeGV_RowDeleting" OnRowEditing="MakeupTypeGV_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="MakeupTypeID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="MakeupTypeName" SortExpression="MakeupTypeName" />
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <h2>Makeup Brand Table</h2>
        <asp:GridView ID="MakeupBrandGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupBrandGV_RowDeleting" OnRowEditing="MakeupBrandGV_RowEditing"
            AllowSorting="true" OnSorting="MakeupBrandGV_Sorting" HeaderStyle-CssClass="gridview-header">
            <Columns>
                <asp:BoundField DataField="MakeupBrandID" HeaderText="MakeupBrandID" SortExpression="MakeupBrandID" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="MakeupBrandName" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="MakeupBrandRating" SortExpression="MakeupBrandRating" />
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="InsertMakeupBtn" runat="server" Text="Insert Makeup" Style="margin-right: 40px" OnClick="InsertMakeupBtn_Click" />
        <asp:Button ID="InsertMakeupTypeBtn" runat="server" Text="Insert Makeup Type" Style="margin-right: 40px" OnClick="InsertMakeupTypeBtn_Click" />
        <asp:Button ID="InsertMakeupBrandBtn" runat="server" Text="Insert Makeup Brand" OnClick="InsertMakeupBrandBtn_Click" />
    </div>
</asp:Content>
