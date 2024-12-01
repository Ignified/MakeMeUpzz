<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MakeMeUpzz.Viewss.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home Page</h1>
<hr />
<div>
    <div>
        <h1 runat="server" id="UserRoleLbl"></h1>
        <h3 runat="server" id="UserNameLbl"></h3>
    </div>
    <asp:GridView ID="UserGV" runat="server" AutoGenerateColumns ="False">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" SortExpression="UserEmail" />
            <asp:BoundField DataField="UserDOB" HeaderText="UserDOB" SortExpression="UserDOB" />
            <asp:BoundField DataField="UserGender" HeaderText="UserGender" SortExpression="UserGender" />
            <asp:BoundField DataField="UserRole" HeaderText="UserRole" SortExpression="UserRole" />
            <asp:BoundField DataField="UserPassword" HeaderText="UserPassword" SortExpression="UserPassword" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
