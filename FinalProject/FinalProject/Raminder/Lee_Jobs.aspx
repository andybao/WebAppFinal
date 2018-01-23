<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Lee_Jobs.aspx.cs" Inherits="FinalProject.Lee_Jobs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div> <h1>Dryden Regional Health Centre </h1>
            <h3>View All Jobs</h3>
             <div><asp:Button ID="btn_view_jobs" runat="server" Text="View Job" OnClick="btn_view_jobs_Click" />
       </div>  <br />  <div id="list_jobs" runat="server"></div><br />
        </div>
          <div>  <h3>Add and Update Jobs</h3>
             Job ID: <asp:TextBox ID="txt_id" runat="server"></asp:TextBox>
         <asp:Label ID="valid_id" runat="server"></asp:Label><br /><br/>

        Job Type:
            <asp:RadioButton ID="rb_part" Text="Part Time" runat="server" GroupName="jobType" checked ="true"/>
            <asp:RadioButton ID="rb_full" Text="Full Time" runat="server" GroupName="jobType"  />
        <br /><br/>

        Job title:   <asp:DropDownList id="dropdownlist1" runat="server">
                     <asp:ListItem>Select</asp:ListItem>
                     <asp:ListItem> Medical Assistant</asp:ListItem>
                     <asp:ListItem> Nursing Assistant</asp:ListItem>
                     <asp:ListItem> Home Health Aide</asp:ListItem>
                     <asp:ListItem> Physician</asp:ListItem>
                     <asp:ListItem> Therapist</asp:ListItem>
                     <asp:ListItem> Pharmacy Technician</asp:ListItem>
                     <asp:ListItem> Diagnostic Medical Sonographer</asp:ListItem>
                     <asp:ListItem> Clinical Laboratory Technician</asp:ListItem>
                     <asp:ListItem> Dental Assistant</asp:ListItem>
                     <asp:ListItem> Radiologic Technologist</asp:ListItem>
                     <asp:ListItem> Physical Therapist</asp:ListItem>
                     <asp:ListItem> Speech-Language Pathologist</asp:ListItem>
                     <asp:ListItem> Respiratory Therapist</asp:ListItem>
      </asp:DropDownList><asp:Label ID="valid_title" runat="server"></asp:Label> <br /><br/>

        Job Info:   <asp:TextBox ID="txt_info" runat="server"></asp:TextBox>
        <asp:Label ID="valid_info" runat="server"></asp:Label> <br /><br/>

        Job Start Date:  <input type="date" runat="server" id="date_picker" />
            <asp:Label ID="valid_start" runat="server"></asp:Label>
        <br /><br/>

       Job End Date:  <input type="date" runat="server" id="date_picker2" /> 
        <br /><br/>
        Job Location:  <asp:TextBox ID="txt_loc" runat="server"></asp:TextBox>
       <asp:Label ID="valid_location" runat="server"></asp:Label>  <br /><br/>

         Job Salary:   <asp:TextBox ID="txt_salary" runat="server"></asp:TextBox>
       <asp:Label ID="valid_salary" runat="server"></asp:Label>  <br /><br/>

        Job Person ID:  <asp:TextBox ID="txt_p_id" runat="server"></asp:TextBox>
        <asp:Label ID="valid_pid" runat="server"></asp:Label> <br /><br/>
       <div> 
        <asp:Button ID="btn_add_jobs" runat="server" Text="Add Job" OnClick="btn_add_jobs_Click"/>
       </div>  <br />
        <div><asp:Button ID="btn_update_jobs" runat="server" Text="Update Job" OnClick="btn_update_jobs_Click" />
        </div> </div><br />
        <div>
            <h3>Delete Jobs</h3>
            Job ID: <asp:TextBox ID="txt_job_id" runat="server"></asp:TextBox>
         <asp:Label ID="valid_del_id" runat="server"></asp:Label><br /><br/>
        <div><asp:Button ID="btn_delete_jobs" runat="server" Text="Delete Job" OnClick="btn_delete_jobs_Click" />
      </div> <br />
       
       <div> <asp:Label ID="lbl_server_message" runat="server"></asp:Label></div>
       
        <%--<div id="jobs" runat="server">
  <ul id="list_jobs" runat="server"></ul>
        </div>--%>   </div>
    </form>
</body>
</html>
