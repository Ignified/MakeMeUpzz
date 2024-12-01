<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MakeMeUpzz.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login Page</h1>
            <hr />
            <div>
                <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="UserPasswordLbl" runat="server" Text="User Password"></asp:Label>
                <asp:TextBox ID="UserPasswordTB" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:CheckBox ID="RememberMeCheckbox" runat="server" Text="Remember Me" />
            </div>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
            <div>
                <asp:Label ID="lblError" runat="server" Text=" " ForeColor="Red"></asp:Label>
            </div>
            <a href="RegisterPage.aspx">Haven't Registered Yet? Click Here!</a>
        </div>
    </form>
</body>
</html>
