<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="ViewTransactionReportPage.aspx.cs" Inherits="MakeMeUpzz.Viewss.ViewTransactionReportPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>View Transaction Report</h1>
        <hr />
        <CR:CrystalReportViewer ID="CrystalReportViewerTransaction" runat="server" AutoDataBind="true" />
    </div>
</asp:Content>
