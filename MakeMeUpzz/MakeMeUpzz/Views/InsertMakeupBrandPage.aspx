<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertMakeupBrandPage.aspx.cs" Inherits="MakeMeUpzz.Viewss.InsertMakeupBrandPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="InsertMakeupBrandView" runat="server">
    <h1>Insert Makeup Brand</h1>
    <hr />
    <div>
        <asp:Label ID="MakeupBrandNameLbl" runat="server" Text="Makeup Brand Name"></asp:Label>
        <asp:TextBox ID="MakeupBrandNameTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="MakeupBrandRatingLbl" runat="server" Text="Makeup Brand Rating"></asp:Label>
        <asp:TextBox ID="MakeupBrandRatingTB" runat="server"></asp:TextBox>
    </div>            
    <div>
        <asp:Button ID="InsertMakeupBrandBtn" runat="server" Text="Insert" OnClick="InsertMakeupBrandBtn_Click"/>
    </div>
    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text=" " ForeColor="Red"></asp:Label>
    </div>
</div>
</asp:Content>
