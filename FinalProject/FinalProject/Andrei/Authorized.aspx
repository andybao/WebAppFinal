<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Authorized.aspx.cs" Inherits="Final_Project_C_Sharp.Authorized" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin page for FAQ manipulations</title>
    <link rel="stylesheet" href="../Styles/style.css" type="text/css"/>
    <meta charset="utf-8" />
</head>
<body>
    <div id="page">

        <header>
            <div id="logo"><img src="../Images/Dryden-Regional-Health-Centre-Logo.jpg" alt="logo of drhc hospital"/></div>
        </header>

        <main>
            
            <h1>Admin Panel for FAQ editing</h1>
            <a href="FAQ.aspx">Go to User Page</a>
            <div>
                
                <form id="faq_form" runat="server">
                    
                    <div class="flex-nner">
                        <asp:Label ID="lbl_question" runat="server">Question ID:</asp:Label>
                        <asp:TextBox ID="txt_question" runat="server" CssClass="inpt"></asp:TextBox>
                        <asp:Label ID="error_question" runat="server"></asp:Label>
                    </div>

                    <div class="btn-cont">
                        <asp:Button ID="btn_show" runat="server" Text="Show Question Info" OnClick="btn_show_Click"/>
                    </div>

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
                                        
                    <div class="btn-cont">
                        <asp:Button ID="btn_update" runat="server" Text="Save / Update Changes" OnClick="btn_update_Click"/>
                        <asp:Button ID="btn_delete" runat="server" Text="Delete Question" OnClick="btn_delete_Click"/>
                        <asp:Button ID="btn_add" runat="server" Text="Add New Question" OnClick="btn_add_Click"/>
                        <asp:Label ID="msg" runat="server"></asp:Label>
                    </div>

                    <div class="btn-cont">
                        <asp:Button ID="botn_logout" runat="server" Text="Logout" onclick="btn_logout_Click"/>
                    </div>
                    
                </form>

                <!-- This section shows all questions -->
                <h2>All FAQ Questions</h2>
                <div id="faq_list" runat="server"></div>
            </div>
        </main>

        <footer><p>Copyright 2017 Dryden Regional Health Centre | All Rights Reserved</p></footer>

    </div>
</body>
</html>
