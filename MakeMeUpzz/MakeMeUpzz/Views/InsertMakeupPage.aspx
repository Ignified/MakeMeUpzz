﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Viewss.InsertMakeupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="InsertMakeupView" runat="server">
        <h1>Insert Makeup</h1>
        <hr />
        <div>
            <asp:Label ID="MakeupNameLbl" runat="server" Text="Makeup Name"></asp:Label>
            <asp:TextBox ID="MakeupNameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupPriceLbl" runat="server" Text="Makeup Price"></asp:Label>
            <asp:TextBox ID="MakeupPriceTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupWeightLbl" runat="server" Text="Makeup Weight"></asp:Label>
            <asp:TextBox ID="MakeupWeightTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupTypeIDLbl" runat="server" Text="Makeup Type ID"></asp:Label>
            <asp:TextBox ID="MakeupTypeIDTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupBrandIDLbl" runat="server" Text="Makeup Brand ID"></asp:Label>
            <asp:TextBox ID="MakeupBrandIDTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="InsertMakeupBtn" runat="server" Text="Insert" OnClick="InsertMakeupBtn_Click" />
        </div>
        <div>
            <asp:Label ID="ErrorLbl" runat="server" Text=" " ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
