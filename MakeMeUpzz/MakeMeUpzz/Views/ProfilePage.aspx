<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="MakeMeUpzz.Viewss.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Change Profile</h1>
    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="UserEmailLbl" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="UserEmailTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="UserDOBLbl" runat="server" Text="Date of Birth"></asp:Label>
        <asp:TextBox ID="UserDOBTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Genderlbl" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButton ID="RadioButtonMale" runat="server" Text="Male" GroupName="GenderGroup" />
        <asp:RadioButton ID="RadioButtonFemale" runat="server" Text="Female" GroupName="GenderGroup" />
    </div>
    <asp:Button ID="UpdateProfileBtn" runat="server" Text="Update" OnClick="UpdateProfileBtn_Click" />
    <asp:Label ID="ErrorLblUpdateProfile" runat="server" Text=" " ForeColor="Red"></asp:Label>

    <h1>Change Password</h1>
    <div>
        <asp:Label ID="OldPasswordLbl" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="OldPasswordTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="NewPasswordLbl" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="NewPasswordTB" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="ChangePasswordBtn" runat="server" Text="Update" OnClick="ChangePasswordBtn_Click" />
    <asp:Label ID="ErrorLblUpdatePassword" runat="server" Text=" " ForeColor="Red"></asp:Label>
</asp:Content>
