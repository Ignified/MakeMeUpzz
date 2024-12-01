<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="MakeMeUpzz.Viewss.TransactionHistoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="TransactionHistoryView" runat="server">
        <h1>Transaction History</h1>
        <hr />
        <div>
            <h2>Transaction List</h2>
            <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="TransactionGV_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID" />
                    <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:CommandField ButtonType="Button" HeaderText="Details" ShowHeader="True" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <hr />
        </div>
    </div>
</asp:Content>
