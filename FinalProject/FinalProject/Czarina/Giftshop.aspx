<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Giftshop.aspx.cs" Inherits="_5101BFinalProject.Giftshop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <a href="Login.aspx">Admin Panel</a>

    <form id="form1" runat="server">
        <div>
            <h1>Dryden Regional Health Centre Virtual Gift Shop</h1>
        </div>
        <div>
            <b>Your first name :</b> <asp:TextBox ID="txt_sender_f_name" runat="server"></asp:TextBox> <asp:Label ID="gift_send_f_name_err" runat="server" ForeColor="red"></asp:Label>
        </div>
        <div>
            <b>Your last name :</b> <asp:TextBox ID="txt_sender_l_name" runat="server"></asp:TextBox> <asp:Label ID="gift_send_l_name_err" runat="server" ForeColor="red"></asp:Label>
        </div>
        <div>
            <b>Patient's first name :</b> <asp:TextBox ID="txt_recipient_f_name" runat="server"></asp:TextBox> <asp:Label ID="gift_rec_f_name_err" runat="server" ForeColor="red"></asp:Label>
        </div>
        <div>
            <b>Patient's last name :</b> <asp:TextBox ID="txt_recipient_l_name" runat="server"></asp:TextBox> <asp:Label ID="gift_rec_l_name_err" runat="server" ForeColor="red"></asp:Label>
        </div>
        <div>
            <b>Which type of gift would you like to give to the patient? :</b> 
            <asp:DropDownList ID="ddl_gift_type" runat="server" Width="167px"> 
                      <asp:ListItem Value="-1">-- Select One --</asp:ListItem>
                      <asp:ListItem Value="Flower">Flower</asp:ListItem>
                      <asp:ListItem Value="Food">Food</asp:ListItem>
                      <asp:ListItem Value="Drink">Drink</asp:ListItem>
                      <asp:ListItem Value="Luxury">Luxury</asp:ListItem>
                      <asp:ListItem Value="Toiletries">Toiletries</asp:ListItem>
            </asp:DropDownList> <asp:Label ID="gift_type_err" runat="server"></asp:Label>
        </div>
        <div>
            <b>What would you like to send to the patient?: </b> <asp:TextBox ID="txt_gift_desc" runat="server"></asp:TextBox> <asp:Label ID="gift_desc_err" runat="server" ForeColor="red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btn_submit" runat="server" Text="Click to Purchase" OnClick="btn_submit_Click" />
        </div>
        <asp:Label ID="thank_you_msg" runat="server"></asp:Label>
    </form>
</body>
</html>
