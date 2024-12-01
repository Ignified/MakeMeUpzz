<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="MakeMeUpzz.Viewss.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 id="pageID" runat="server">Transaction [ID]</h2>
    <h3 id="pageDate" runat="server">Transaction Date: [date]</h3>
    <hr />
    <table>
        <tr>
            <th>Makeup Name</th>
            <th>Makeup Type</th>
            <th>Makeup Brand</th>
            <th> Quantity </th>
            <th>Total Weight</th>
            <th>Total Price</th>
        </tr>

        <%foreach (var det in tran)
            { %>
        <tr>
            <td><%= det.Makeup.MakeupName%></td>
            <td><%= det.Makeup.MakeupType.MakeupTypeName%></td>
            <td><%= det.Makeup.MakeupBrand.MakeupBrandName%></td>
            <td><%= det.Quantity%></td>
            <td><%= det.Quantity * det.Makeup.MakeupWeight%></td>
            <td><%= det.Quantity * det.Makeup.MakeupPrice%></td>
        </tr>
        <%  } %>

        <tr>
            <td colspan="3">Total</td>
            <td><%= tran.Sum(detail => detail.Quantity) %></td>
            <td><%= tran.Sum(detail => detail.Quantity * detail.Makeup.MakeupWeight) %></td>
            <td><%= tran.Sum(detail => detail.Quantity * detail.Makeup.MakeupPrice) %></td>
        </tr>
    </table>
    <hr />
</asp:Content>
