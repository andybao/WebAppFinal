<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="NewQuestion.aspx.cs" Inherits="Final_Project_C_Sharp.NewQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin page for Adding a New FAQ question</title>
    <link rel="stylesheet" href="../Styles/style.css" type="text/css"/>
    <meta charset="utf-8" />
</head>
<body>
    <div id="page">

        <header>
            <div id="logo"><img src="../Images/Dryden-Regional-Health-Centre-Logo.jpg" alt="logo of drhc hospital"/></div>
        </header>

        <main>
            
            <h1>Add New FAQ Question</h1>
            <div>
                
                <form id="new_form" runat="server">

                    <div class="flex-nner">
                        <asp:Label ID="lbl_question_desc" runat="server">Question:</asp:Label>
                        <asp:TextBox ID="txt_question_desc" runat="server" CssClass="inpt"></asp:TextBox>
                        <asp:Label ID="error_question_desc" runat="server"></asp:Label>
                    </div>

                    <div class="flex-nner">
                        <asp:Label ID="lbl_answer" runat="server">Answer:</asp:Label>
                        <asp:TextBox ID="txt_answer" runat="server" CssClass="inpt"></asp:TextBox>
                        <asp:Label ID="error_answer" runat="server"></asp:Label>
                    </div>

                    <div class="flex-nner">
                        <asp:Label ID="lbl_cat" runat="server">Category:</asp:Label>
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
                        <asp:Button ID="btn_add_new" runat="server" Text="Add New Question" onclick="btn_add_new_Click"/>
                        <asp:Label ID="msg" runat="server"></asp:Label>
                    </div>

                    <div class="btn-cont">
                        <asp:Button ID="btn_back" runat="server" Text="Back to List of Questions" onclick="btn_back_Click"/>
                    </div>


                </form>
            </div>
        </main>

        <footer><p>Copyright 2017 Dryden Regional Health Centre | All Rights Reserved</p></footer>

    </div>
</body>
</html>
