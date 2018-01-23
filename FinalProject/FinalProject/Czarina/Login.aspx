<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="_5101BFinalProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1 id="login_portal" runat="server">Login portal</h1>
    <form id="form1" runat="server">
        <asp:Label ID="lbl_variable" runat="server"></asp:Label>
        <div>
            email: <asp:TextBox ID="email_log" runat="server"></asp:TextBox>
        </div>
        <div>
            password: <asp:TextBox ID="password_log" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_login" runat="server" OnClick="btn_login_Click" Text="Login" />
        </div>
        <div>
            <asp:Label ID="lbl_login_err" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
