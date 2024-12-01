<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="HandleTransactionPage.aspx.cs" Inherits="MakeMeUpzz.Viewss.HandleTransactionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="HandleTransactionView" runat="server">
        <h1>Handle Transaction</h1>
        <hr />
        <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="HandleBtn" runat="server" Text="Handle" OnClick="HandleBtn_Click" CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
