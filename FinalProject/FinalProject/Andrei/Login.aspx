<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="Final_Project_C_Sharp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login page for FAQ admin</title>
    <link rel="stylesheet" href="Styles/style.css" type="text/css"/>
    <meta charset="utf-8" />
</head>
<body>
    <div id="page">

        <header>
            <div id="logo"><img src="Images/Dryden-Regional-Health-Centre-Logo.jpg" alt="logo of drhc hospital"/></div>
        </header>

        <main>
            <h1>Login into Admin Panel</h1>
            <a href="FAQ.aspx">Go to User Page</a>
            <div id="flex-container">
                <form id="login_form" runat="server">

                    <div class="flex-nner">
                        <asp:Label ID="lbl_email" runat="server">Email:</asp:Label>
                        <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
                        <asp:Label ID="error_email" runat="server"></asp:Label> <!-- This field is for error message if email is empty -->
                    </div>
                    
                    <div class="flex-nner">
                        <asp:Label ID="lbl_password" runat="server">Password:</asp:Label>
                        <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="error_password" runat="server"></asp:Label> <!-- This field is for error message if password is empty -->
                    </div>

                    <div class="flex-nner">
                        <asp:Label ID="error_login" runat="server"></asp:Label> <!-- This field is for error message if login credentils are wrong -->
                        <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click"/>
                    </div>

                    <p>Hint: Enter email 'andrei@humber.ca' and password '1' to login.</p>

                </form>
            </div>
        </main>

        <footer><p>Copyright 2017 Dryden Regional Health Centre | All Rights Reserved</p></footer>

    </div>
</body>
</html>
