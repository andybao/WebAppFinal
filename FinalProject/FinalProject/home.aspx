<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="FinalProject.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:LinkButton ID="lbtn_demo_" runat="server" OnClick="lbtn_demo_click"></asp:LinkButton>
        <br /><br />
        <asp:LinkButton ID="lbtn_andrei" runat="server" OnClick="lbtn_andrei_click">Anderi - FAQ</asp:LinkButton>
        <br /><br />
        <asp:LinkButton ID="lbtn_bradley" runat="server" OnClick="lbtn_bradley_click">Brad - Volunteer Recruit</asp:LinkButton>
        <br /><br />
        <asp:LinkButton ID="lbtn_czarina" runat="server" OnClick="lbtn_czarina_click">Czarina - Gifts Shop</asp:LinkButton>
        <br /><br />
        <asp:LinkButton ID="lbtn_raminder" runat="server" OnClick="lbtn_raminder_click">Raminder - Employee Recruit</asp:LinkButton>
        <br /><br />
        <asp:LinkButton ID="lbtn_sophia" runat="server" OnClick="lbtn_sophia_click">Sophia - Ecard</asp:LinkButton>
        <br /><br />
        <asp:LinkButton ID="lbtn_andy" runat="server" OnClick="lbtn_andy_click">Andy - Survey</asp:LinkButton>
    </form>

</body>
</html>
