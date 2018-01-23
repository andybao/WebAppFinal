<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="survey.aspx.cs" Inherits="FinalProject.Andy.survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lbl_db_error_msg_" runat="server" ForeColor="Red"></asp:Label>
        <p>This survey only supports 5 questions</p>
        <asp:LinkButton ID="lbtn_admin_" runat="server" OnClick="lbtn_admin_click">Administrator</asp:LinkButton>
        &nbsp&nbsp&nbsp&nbsp
        <asp:LinkButton ID="lbtn_user_" runat="server" OnClick="lbtn_user_click">User</asp:LinkButton>
        <br /><br />
        <div id="div_admin_pw_" runat="server" visible="false">
            PW: <asp:TextBox ID="tb_admin_pw_" runat="server">12345</asp:TextBox>&nbsp
            <asp:LinkButton ID="lbtn_admin_login_" runat="server" OnClick="lbtn_admin_login_click">Login</asp:LinkButton>&nbsp
            <asp:Label ID="lbl_admin_login_error_msg_" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div id="div_admin_" runat="server" style="width: 700px; background-color: lightblue;" visible="false">
            <br />
            <asp:LinkButton ID="lbtn_admin_check_result_" runat="server" OnClick="lbtn_admin_check_result_click">Check Result</asp:LinkButton>&nbsp
            <asp:LinkButton ID="lbtn_admin_modify_question_" runat="server" OnClick="lbtn_admin_modify_question_click">Modify Questions</asp:LinkButton>&nbsp
            <asp:LinkButton ID="lbtn_admin_logout_" runat="server" OnClick="lbtn_admin_logout_click">Logout</asp:LinkButton>
            <br />            
            <div id="div_modify_questions_" runat="server" visible="false">
                <asp:Label ID="lbl_admin_error_msg_" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lbl_admin_info_msg_" runat="server"></asp:Label>
                <br />
                <p>'Delete' will clear survey result, 'Update' will keep it.</p>
                <br />
                <div id="div_question_0_" runat="server" visible="false">
                    <asp:Label ID="lbl_question_0_id_" runat="server" Visible="false"></asp:Label>&nbsp
                    <asp:TextBox ID="tb_question_0_text_" runat="server" BackColor="Gray" ReadOnly="True" Width="400px"></asp:TextBox>&nbsp
                    <asp:LinkButton ID="lbtn_question_0_delete_" runat="server" OnClick="lbtn_admin_question_delete_click">Delete</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_0_update_" runat="server" OnClick="lbtn_question_update_click">Update</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_0_sbumit_" runat="server" Visible="false" OnClick="lbtn_question_sbumit_click">Submit</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_0_cancle_" runat="server" Visible="false" OnClick="lbtn_question_cancle_click">Cancle</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_0_create_" runat="server" Visible="false" OnClick="lbtn_question_create_click">Create</asp:LinkButton>
                </div>
                <br />
                <div id="div_question_1_" runat="server" visible="false">
                    <asp:Label ID="lbl_question_1_id_" runat="server" Visible="false"></asp:Label>&nbsp
                    <asp:TextBox ID="tb_question_1_text_" runat="server" BackColor="Gray" ReadOnly="True" Width="400px"></asp:TextBox>&nbsp
                    <asp:LinkButton ID="lbtn_question_1_delete_" runat="server" OnClick="lbtn_admin_question_delete_click">Delete</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_1_update_" runat="server" OnClick="lbtn_question_update_click">Update</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_1_sbumit_" runat="server" Visible="false" OnClick="lbtn_question_sbumit_click">Submit</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_1_cancle_" runat="server" Visible="false" OnClick="lbtn_question_cancle_click">Cancle</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_1_create_" runat="server" Visible="false" OnClick="lbtn_question_create_click">Create</asp:LinkButton>
                </div>
                <br />
                <div id="div_question_2_" runat="server" visible="false">
                    <asp:Label ID="lbl_question_2_id_" runat="server" Visible="false"></asp:Label>&nbsp
                    <asp:TextBox ID="tb_question_2_text_" runat="server" BackColor="Gray" ReadOnly="True" Width="400px"></asp:TextBox>&nbsp
                    <asp:LinkButton ID="lbtn_question_2_delete_" runat="server" OnClick="lbtn_admin_question_delete_click">Delete</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_2_update_" runat="server" OnClick="lbtn_question_update_click">Update</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_2_sbumit_" runat="server" Visible="false" OnClick="lbtn_question_sbumit_click">Submit</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_2_cancle_" runat="server" Visible="false" OnClick="lbtn_question_cancle_click">Cancle</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_2_create_" runat="server" Visible="false" OnClick="lbtn_question_create_click">Create</asp:LinkButton>
                </div>
                <br />
                <div id="div_question_3_" runat="server" visible="false">
                    <asp:Label ID="lbl_question_3_id_" runat="server" Visible="false"></asp:Label>&nbsp
                    <asp:TextBox ID="tb_question_3_text_" runat="server" BackColor="Gray" ReadOnly="True" Width="400px"></asp:TextBox>&nbsp
                    <asp:LinkButton ID="lbtn_question_3_delete_" runat="server" OnClick="lbtn_admin_question_delete_click">Delete</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_3_update_" runat="server" OnClick="lbtn_question_update_click">Update</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_3_sbumit_" runat="server" Visible="false" OnClick="lbtn_question_sbumit_click">Submit</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_3_cancle_" runat="server" Visible="false" OnClick="lbtn_question_cancle_click">Cancle</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_3_create_" runat="server" Visible="false" OnClick="lbtn_question_create_click">Create</asp:LinkButton>
                </div>
                <br />
                <div id="div_question_4_" runat="server" visible="false">
                    <asp:Label ID="lbl_question_4_id_" runat="server" Visible="false"></asp:Label>&nbsp
                    <asp:TextBox ID="tb_question_4_text_" runat="server" BackColor="Gray" ReadOnly="True" Width="400px"></asp:TextBox>&nbsp
                    <asp:LinkButton ID="lbtn_question_4_delete_" runat="server" OnClick="lbtn_admin_question_delete_click">Delete</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_4_update_" runat="server" OnClick="lbtn_question_update_click">Update</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_4_sbumit_" runat="server" Visible="false" OnClick="lbtn_question_sbumit_click">Submit</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_4_cancle_" runat="server" Visible="false" OnClick="lbtn_question_cancle_click">Cancle</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lbtn_question_4_create_" runat="server" Visible="false" OnClick="lbtn_question_create_click">Create</asp:LinkButton>
                </div>                
                <br />
                <asp:LinkButton ID="lbtn_admin_create_new_question_" runat="server" OnClick="lbtn_admin_create_new_question_click">Create New Question</asp:LinkButton>&nbsp
                <asp:LinkButton ID="lbtn_admin_cancle_new_question_" runat="server" Visible="false" OnClick="lbtn_admin_cancle_new_question_click">Cancle Question Creation</asp:LinkButton>
            </div>
            <div id="div_check_result_" runat="server" visible="false">
                <asp:Label ID="lbl_result_0_" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_result_1_" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_result_2_" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_result_3_" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_result_4_" runat="server"></asp:Label>
            </div>
        </div>
        <div id="div_user_" runat="server" style="width: 700px; background-color: lightgreen" visible="false">
            <asp:Label ID="lbl_user_error_msg_" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="lbl_user_info_msg_" runat="server"></asp:Label>
            <br />
            <div id="div_question_0_user_" runat="server" visible="false">
                <asp:Label ID="lbl_question_0_id_user_" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_question_0_text_user_" runat="server"></asp:Label>&nbsp
                <asp:CheckBox ID="ckbx_question_0_yes_user_" runat="server" Text="Yes" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_0_no_user_" runat="server" Text="No" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_0_not_sure_user_" runat="server" Text="Not Sure" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>
            </div>
            <br />
            <div id="div_question_1_user_" runat="server" visible="false">
                <asp:Label ID="lbl_question_1_id_user_" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_question_1_text_user_" runat="server"></asp:Label>&nbsp
                <asp:CheckBox ID="ckbx_question_1_yes_user_" runat="server" Text="Yes" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_1_no_user_" runat="server" Text="No" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_1_not_sure_user_" runat="server" Text="Not Sure" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>
            </div>
            <br />
            <div id="div_question_2_user_" runat="server" visible="false">
                <asp:Label ID="lbl_question_2_id_user_" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_question_2_text_user_" runat="server"></asp:Label>&nbsp
                <asp:CheckBox ID="ckbx_question_2_yes_user_" runat="server" Text="Yes" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_2_no_user_" runat="server" Text="No" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_2_not_sure_user_" runat="server" Text="Not Sure" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>
            </div>
            <br />
            <div id="div_question_3_user_" runat="server" visible="false">
                <asp:Label ID="lbl_question_3_id_user_" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_question_3_text_user_" runat="server"></asp:Label>&nbsp
                <asp:CheckBox ID="ckbx_question_3_yes_user_" runat="server" Text="Yes" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_3_no_user_" runat="server" Text="No" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_3_not_sure_user_" runat="server" Text="Not Sure" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>
            </div>
            <br />
            <div id="div_question_4_user_" runat="server" visible="false">
                <asp:Label ID="lbl_question_4_id_user_" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbl_question_4_text_user_" runat="server"></asp:Label>&nbsp
                <asp:CheckBox ID="ckbx_question_4_yes_user_" runat="server" Text="Yes" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_4_no_user_" runat="server" Text="No" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>&nbsp
                <asp:CheckBox ID="ckbx_question_4_not_sure_user_" runat="server" Text="Not Sure" OnCheckedChanged="ckbx_checked_changed" AutoPostBack="true"/>
            </div>
            <br />
            <asp:LinkButton ID="lbtn_user_submit_" runat="server" OnClick="lbtn_user_submit_click">Submit</asp:LinkButton>
        </div>
    </form>
</body>
</html>
