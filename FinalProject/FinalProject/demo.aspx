<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="FinalProject.demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lbl_demo_db_error_msg_display_" runat="server"></asp:Label>
        <p>1. Press 
            <asp:LinkButton ID="lbtn_demo_query_all_columns_from_a_table_" runat="server" OnClick="lbtn_demo_query_all_columns_from_a_table_click">HERE</asp:LinkButton>&nbsp
            to display all items in lee_msgs table. (sql: SELECT * FROM lee_msgs;). 
            Press 
            <asp:LinkButton ID="lbtn_demo_hide_1_" runat="server" OnClick="lbtn_demo_hide_click">HERE</asp:LinkButton>&nbsp
            to hide the result. 
        </p>
        <asp:Label ID="lbl_demo_query_all_columns_from_a_table_display_" runat="server" Visible="true"></asp:Label>
        <p>2. Press
            <asp:LinkButton ID="lbtn_demo_query_columns_by_where_clause_" runat="server" OnClick="lbtn_demo_query_columns_by_where_clause_click">HERE</asp:LinkButton>&nbsp
            to display item(s) based on where clause. It displays all volunteer jobs in this case. (sql: SELECT * FROM lee_jobs WHERE job_type='VOLUNTEER';). 
            Press 
            <asp:LinkButton ID="lbtn_demo_hide_2_" runat="server" OnClick="lbtn_demo_hide_click">HERE</asp:LinkButton>&nbsp
            to hide the result. 
        </p>
        <asp:Label ID="lbl_demo_query_columns_by_where_clause_display_" runat="server" Visible="true"></asp:Label>

        <p>3. Press
            <asp:LinkButton ID="lbtn_demo_query_columns_by_keyword_" runat="server" OnClick="lbtn_demo_query_columns_by_keyword_click">HERE</asp:LinkButton>&nbsp
            to find item(s) based on keyword. It displays all jobs includes 'operation' in job_info (lee_jobs). 
            Press
            <asp:LinkButton ID="lbtn_demo_hide_3_" runat="server" OnClick="lbtn_demo_hide_click">HERE</asp:LinkButton>&nbsp
            to hide the result.
        </p>
        <asp:Label ID="lbl_demo_query_columns_by_keyword_display_" runat="server" Visible="true"></asp:Label>

        <p>4. Press
            <asp:LinkButton ID="lbtn_demo_query_one_column_by_its_name_" runat="server" OnClick="lbtn_demo_query_one_column_by_its_name_click">HERE</asp:LinkButton>
            to find one column based on its name. It displays all job titles in this case. 
            (sql: SELECT job_title FROM lee_jobs;). 
            Press
            <asp:LinkButton ID="lbtn_demo_hide_4_" runat="server" OnClick="lbtn_demo_hide_click">HERE</asp:LinkButton>&nbsp
            to hide the result.
        </p>
        <asp:Label ID="lbl_demo_query_one_column_by_its_name_display_" runat="server" Visible="true"></asp:Label>
          <p>5. Press
              <asp:LinkButton ID="lbtn_demo_insert_one_item_" runat="server" OnClick="lbtn_demo_insert_one_item_click">HERE</asp:LinkButton>&nbsp
              to insert one item to table. It inserts (12, 'msg from insert demo', -1, 4) into lee_msgs.
              (sql: INSERT INTO lee_msgs VALUES (12, 'msg from insert demo', -1, 4). 
              Press
              <asp:LinkButton ID="lbtn_demo_hide_5_" runat="server" OnClick="lbtn_demo_hide_click">HERE</asp:LinkButton>&nbsp
              to hide the result.
          </p>
        <asp:Label ID="lbl_demo_insert_one_item_display_" runat="server" Visible="true"></asp:Label>
        <p>6. Press
            <asp:LinkButton ID="lbtn_demo_update_one_item_" runat="server" OnClick="lbtn_demo_update_one_item_click">HERE</asp:LinkButton>&nbsp
            to update one item based on its ID. It updates msg(12)'s msg_info to 'msg from update demo'.
            (sql: UPDATE lee_msgs SET msg_info = 'msg from update demo' WHERE msg_id = 12;). 
            Press
            <asp:LinkButton ID="lbtn_demo_hide_6_" runat="server" OnClick="lbtn_demo_hide_click">HERE</asp:LinkButton>&nbsp
            to hide the result.
        </p>
        <asp:Label ID="lbtn_demo_update_one_item_display_" runat="server" Visible="true"></asp:Label>
        <p>7. Press
          <asp:LinkButton ID="lbtn_demo_delete_one_item_" runat="server" OnClick="lbtn_demo_delete_one_item_click">HERE</asp:LinkButton>&nbsp
            to delete one item based on its ID. It deleles msg(12).
            (sql: DELETE FROM lee_msgs WHERE msg_id = 12;). 
            Press
            <asp:LinkButton ID="lbtn_demo_hide_7_" runat="server" OnClick="lbtn_demo_hide_click">HERE</asp:LinkButton>&nbsp
            to hide the result.
        </p>
        <asp:Label ID="lbl_demo_delete_one_item_display_" runat="server" Visible="true"></asp:Label>
    </form>
    
    </body>
</html>
