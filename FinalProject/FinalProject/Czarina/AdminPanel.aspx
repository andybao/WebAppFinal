<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="AdminPanel.aspx.cs" Inherits="_5101BFinalProject.GiftShop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gift Shop - Admin</title>
    <style>
        body {
            font-family:Arial;
            background-color:beige;
            font-size:10pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Gift Shop - Admin</h1>
        <div>
            <fieldset><legend style="font-size:1.5em"><b>Search by</b></legend>
                <br />
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Gift ID: </b><asp:TextBox ID="txt_gift_id" runat="server"></asp:TextBox>
                </div>
                <div style="padding-left:0.5em">
                    <b>Gift Description: </b><asp:TextBox ID="txt_gift_desc2" runat="server"></asp:TextBox>
                </div>
                <br />
                <div style="padding-left:0.5em">
                    <asp:Button ID="btn_gs_show" runat="server" Text="Show Transaction" OnClick="btn_gs_show_Click" style="margin-right:10px" />
                </div>
                <br />
                    <div style="padding-left:0.5em">
                        <asp:Label ID="lbl_search_err" runat="server"></asp:Label>
                    </div>
                <br />
                    <div id="table_gifts" runat="server" style="padding-left:0.5em"></div>
                <br />
            </fieldset>
        </div>
        <br />
        <div>
            <fieldset><legend style="font-size:1.5em"><b>Create / Update Transaction</b></legend>
                <br />
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Gift ID: </b><asp:TextBox ID="txt_gift_id2" runat="server"></asp:TextBox> <asp:Label ID="gift_id2_err" runat="server" ForeColor="red"></asp:Label> 
                </div>
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Sender's First Name: </b> <asp:TextBox ID="txt_sender_f_name" runat="server"></asp:TextBox> <asp:Label ID="gift_send_f_name_err" runat="server" ForeColor="red"></asp:Label>  
                </div>
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Sender's Last Name: </b> <asp:TextBox ID="txt_sender_l_name" runat="server"></asp:TextBox> <asp:Label ID="gift_send_l_name_err" runat="server" ForeColor="red"></asp:Label>
                </div>
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Recipient's First Name: </b> <asp:TextBox ID="txt_recipient_f_name" runat="server"></asp:TextBox> <asp:Label ID="gift_rec_f_name_err" runat="server" ForeColor="red"></asp:Label>
                </div>
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Recipient's Last Name: </b> <asp:TextBox ID="txt_recipient_l_name" runat="server"></asp:TextBox> <asp:Label ID="gift_rec_l_name_err" runat="server" ForeColor="red"></asp:Label>
                </div>
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Gift Type:</b> 
                    <asp:DropDownList ID="ddl_gift_type" runat="server" Width="167px"> 
                      <asp:ListItem Value="-1">-- Select One --</asp:ListItem>
                      <asp:ListItem Value="Flower">Flower</asp:ListItem>
                      <asp:ListItem Value="Food">Food</asp:ListItem>
                      <asp:ListItem Value="Drink">Drink</asp:ListItem>
                      <asp:ListItem Value="Luxury">Luxury</asp:ListItem>
                      <asp:ListItem Value="Toiletries">Toiletries</asp:ListItem>
                    </asp:DropDownList> <asp:Label ID="gift_type_err" runat="server"></asp:Label>
                </div>
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Gift Description:</b> <asp:TextBox ID="txt_gift_desc" runat="server"></asp:TextBox> <asp:Label ID="gift_desc_err" runat="server" ForeColor="red"></asp:Label> 
                </div>
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Price: </b><asp:TextBox ID="txt_gift_price" runat="server"></asp:TextBox> <asp:Label ID="gift_price_err" runat="server" ForeColor="red"></asp:Label>
                </div>
                <div style="padding-left:0.5em; padding-bottom:0.5em">
                    <b>Gift Sender ID: </b> <asp:TextBox ID="txt_gift_sender_id" runat="server"></asp:TextBox> <asp:Label ID="gift_sender_id_err" runat="server" ForeColor="red"></asp:Label>
                </div>
                <div style="padding-left:0.5em">
                    <b>Gift Recipient ID: </b> <asp:TextBox ID="txt_gift_recipient_id" runat="server"></asp:TextBox> <asp:Label ID="gift_recipient_id_err" runat="server" ForeColor="red"></asp:Label>
                </div>
                <br />
                <div style="padding-left:0.5em">
                    <asp:Button ID="btn_gs_create" runat="server" Text="Add Transaction" OnClick="btn_gs_create_Click" style="margin-right:10px" /> 

                    <asp:Button ID="btn_gs_update" runat="server" Text="Update Transaction" OnClick="btn_gs_update_Click" style="margin-right:10px" /> 
                </div>
                <br />
                    <asp:Label ID="lbl_insert_err" runat="server"></asp:Label>
                <br />
            </fieldset>
        </div>
        <br />
        <fieldset><legend style="font-size:1.5em"><b>Delete transaction</b></legend>
            <br />
            <div style="padding-left:0.5em">
                <b>Gift ID: </b><asp:TextBox ID="txt_gift_id3" runat="server"></asp:TextBox> <asp:Label ID="gift_id3_err" runat="server" ForeColor="red"></asp:Label>
            </div>
            <br />
            <div style="padding-left:0.5em">
                <asp:Button ID="btn_gs_delete" runat="server" Text="Delete Transaction" OnClick="btn_gs_delete_Click" />
            </div>
            <br />
                <asp:Label ID="lbl_delete_err" runat="server"></asp:Label>
            <br />
        </fieldset>
        <div>
        </div>
    </form>
</body>
</html>
