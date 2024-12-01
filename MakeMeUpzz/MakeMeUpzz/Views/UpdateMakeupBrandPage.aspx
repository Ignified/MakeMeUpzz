<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupBrandPage.aspx.cs" Inherits="MakeMeUpzz.Viewss.UpdateMakeupBrandPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="UpdateMakeupBrandView" runat="server">
    <h1>Update Makeup Brand</h1>
    <h2>Makeup Brand <%=Request.QueryString["id"]%></h2>
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
        <asp:Button ID="UpdateMakeupBrandBtn" runat="server" Text="Update" OnClick="UpdateMakeupBrandBtn_Click"/>
    </div>
    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text=" " ForeColor="Red"></asp:Label>
    </div>
</div>
</asp:Content>
