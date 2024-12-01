<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="MakeMeUpzz.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Register Page</h1>
        <hr />
        <div>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Genderlbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButton ID="RadioButtonMale" runat="server" Text="Male" GroupName="GenderGroup" />
            <asp:RadioButton ID="RadioButtonFemale" runat="server" Text="Female" GroupName="GenderGroup" />
        </div>
        <div>
            <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ConfirmPasswordLbl" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="ConfirmPasswordTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="DOBTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
        </div>
        <div>
            <asp:Label ID="ErrorLbl" runat="server" Text=" " ForeColor ="Red"></asp:Label>
        </div>
        <div>
            <a href="LoginPage.aspx">Already Have an Account? Click Here</a>
        </div>
    </form>
</body>
</html>
