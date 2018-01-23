<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="FAQ.aspx.cs" Inherits="Final_Project_C_Sharp.FAQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FAQ page</title>
    <link rel="stylesheet" href="Styles/style.css" type="text/css"/>
    <meta charset="utf-8" />
</head>
<body>
    <div id="page">

        <header>
            <div id="logo"><img src="Images/Dryden-Regional-Health-Centre-Logo.jpg" alt="logo of drhc hospital"/></div>
        </header>

        <main>
            
            <h1>FAQ Page</h1>
            <div>
                <a href="Login.aspx">Go to Admin Panel</a>
                
                <form id="client_form" runat="server">

                    <div class="flex-nner">
                        <asp:Label ID="lbl_question_desc" runat="server">Please, enter your question:</asp:Label>
                        <asp:TextBox ID="txt_question_desc" runat="server" CssClass="inpt"></asp:TextBox>
                        <asp:Label ID="error_question_desc" runat="server"></asp:Label>
                    </div>

                    <div class="flex-nner">
                        <asp:Label ID="lbl_cat" runat="server">Please, select category:</asp:Label>
                        <asp:DropDownList ID="slc_cat" runat="server">
                            <asp:ListItem Value="1">Contact</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">About</asp:ListItem>
                            <asp:ListItem Value="3">General</asp:ListItem>
                            <asp:ListItem Value="4">Services</asp:ListItem>
                            <asp:ListItem Value="5">Programs</asp:ListItem>
                            <asp:ListItem Value="6">Finance</asp:ListItem>
                            <asp:ListItem Value="7">Employment</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="error_cat" runat="server"></asp:Label>
                    </div>
                                        
                    <div class="btn-cont">
                        <asp:Button ID="btn_client_add_new" runat="server" Text="Add This Question as New" OnClick="btn_client_add_new_Click" />
                        <asp:Button ID="btn_search" runat="server" Text="Search This Question" OnClick="btn_search_Click" />
                        <asp:Label ID="msg" runat="server"></asp:Label>
                    </div>

                </form>

                <!-- To show question if it was found -->
                <div id="found" runat="server"></div>

                <!-- This section shows all questions -->
                <h2>All FAQ Questions</h2>
                <div id="faq_list" runat="server"></div>
            </div>
        </main>

        <footer><p>Copyright 2017 Dryden Regional Health Centre | All Rights Reserved</p></footer>

    </div>
</body>
</html>
