<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertMakeupTypePage.aspx.cs" Inherits="MakeMeUpzz.Viewss.InsertMakeupTypePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="InsertMakeupTypeView" runat="server">
        <h1>Insert Makeup Type</h1>
        <hr />
        <div>
            <asp:Label ID="MakeupTypeNameLbl" runat="server" Text="Makeup Type Name"></asp:Label>
            <asp:TextBox ID="MakeupTypeNameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="InsertMakeupTypeBtn" runat="server" Text="Insert" OnClick="InsertMakeupTypeBtn_Click" />
        </div>
        <div>
            <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
