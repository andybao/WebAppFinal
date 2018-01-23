<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ecards.aspx.cs" Inherits="ECards.ecards" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="ecards" runat="server">
        <h1>User side</h1>
        <h2>Send an E-Card to a Patient!</h2>
        <p>Please fill out the following information:</p>
        <div>
            <asp:Label runat="server">Sender First Name: </asp:Label>
            <asp:TextBox runat="server" ID="s_fname_input" Text=""></asp:TextBox>
            <asp:Label runat="server" ID="f_name_err" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label runat="server">Sender Last Name: </asp:Label>
            <asp:TextBox runat="server" id="s_lname_input" Text=""></asp:TextBox>
            <asp:Label runat="server" ID="l_name_err" Text=""></asp:Label>

        </div>
        <div>
            <asp:Label runat="server">Sender E-Mail: </asp:Label>
            <asp:TextBox runat="server" id="s_email_input" Text=""></asp:TextBox>
            <asp:Button runat="server" ID="ecards_by_email_btn" OnClick="ecards_by_email_btn_Click" Text="Check Cards Sent" />
            <asp:Label runat="server" ID="email_err" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label runat="server">Patient First Name: </asp:Label>
            <asp:TextBox runat="server" id="p_fname_input" Text=""></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server">Patient Last Name: </asp:Label>
            <asp:TextBox runat="server" id="p_lname_input" Text=""></asp:TextBox>
            <asp:Label runat="server" ID="patient_err"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server">Card Choice: </asp:Label>
            <asp:DropDownList runat="server" id="card_choice_input">
                <asp:ListItem Text="Congrats" Value="congrats"></asp:ListItem>  
                <asp:ListItem Text="Get Well Soon" Value="getwellsoon"></asp:ListItem>
                <asp:ListItem Text="Best Wishes" Value="bestwishes"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server">Message: </asp:Label>
            <asp:TextBox runat="server" id="message_input" Text=""></asp:TextBox>
            <asp:Label runat="server" ID="msg_err" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button runat="server" ID="send_card_btn" OnClick="send_card_btn_Click" Text="Send Card" />
        </div>

        <h1>Admin additional</h1>
        <h2>Update/Delete E-Card by ID#</h2>
        <div>
            <asp:Label runat="server">E-Card Id: </asp:Label>
            <asp:TextBox runat="server" ID="ecardId_input"></asp:TextBox>
            <asp:Button runat="server" ID="check_by_id_input" OnClick="check_by_id_input_Click" Text="Check E-Card"/>
            <asp:Label runat="server" ID="id_err" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button runat="server" ID="update_by_id" OnClick="update_by_id_Click" Text="Update"/>
            <asp:Button runat="server" ID="delete_by_id" OnClick="delete_by_id_Click" Text="Delete"/>
            <asp:Button runat="server" ID="all_ecards" OnClick="all_ecards_Click" Text="View All Cards"/>
        </div>
        <div runat="server" id="server_output"></div>
    </form>
</body>
</html>
