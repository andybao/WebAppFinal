<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="FinalProject.demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>1. Press <asp:LinkButton ID="lbtn_demo_query_lee_msgs_table_" runat="server" OnClick="lbtn_demo_query_lee_msgs_table_click">HERE</asp:LinkButton>&nbsp
            to display all items in lee_msgs table, and press <asp:LinkButton ID="lbtn_demo_hide_" runat="server">HERE</asp:LinkButton>&nbsp
            to hide it.
        </p>
        <asp:Label ID="lbl_demo_query_msgs_table_display" runat="server" Visible="true"></asp:Label>

        <p>2. Find keyword 'senior' in job_info (lee_jobs) 
            <asp:LinkButton ID="lbtn_demo_keyword_" runat="server" OnClick="lbtn_demo_keyword_click">FIND IT</asp:LinkButton>
        </p>
        <asp:Label ID="lbl_demo_keyword_info" runat="server" Visible="true"></asp:Label>
          
        
    </form>
    
    </body>
</html>
