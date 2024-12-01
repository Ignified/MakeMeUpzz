<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderMakeupPage.aspx.cs" Inherits="MakeMeUpzz.Viewss.OrderMakeupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="OrderMakeupView" runat="server">
        <h1>Order Makeup</h1>
        <hr />
        <div>
            <h2>Makeup Table</h2>
            <asp:GridView ID="MakeupGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
                    <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
                    <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight" SortExpression="MakeupWeight" />
                    <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="MakeupType.MakeupTypeName" />
                    <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Makeup Brand Name" SortExpression="MakeupBrand.MakeupBrandName" />
                    <asp:TemplateField HeaderText="Enter Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="OrderMakeupQuantityTB" runat="server" Text=" "></asp:TextBox>
                            <asp:Button ID="OrderBtn" runat="server" Text="Order" OnClick="OrderBtn_Click" CommandArgument="<%# Container.DataItemIndex %>" />
                            <asp:Label ID="ErrorLbl" runat="server" Text=" " ForeColor="Red"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <h2>Cart Table</h2>
            <asp:GridView ID="CartGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Makeup Name" SortExpression="Makeup.MakeupName" />
                    <asp:BoundField DataField="Makeup.MakeupPrice" HeaderText="Makeup Price" SortExpression="Makeup.MakeupPrice" />
                    <asp:BoundField DataField="Makeup.MakeupWeight" HeaderText="Makeup Weight" SortExpression="Makeup.MakeupWeight" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                </Columns>
            </asp:GridView>
            <hr />
        </div>
        <div>
            <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" Style="margin-right: 15px" OnClick="ClearCartBtn_Click" />
            <asp:Button ID="CheckoutBtn" runat="server" Text="Check Out" OnClick="CheckoutBtn_Click" />
        </div>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
