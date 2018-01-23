<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="volunteers_page.aspx.cs" Inherits="bradCampbell_FinalAssignment.volunteers_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="registerTitle" runat="server">Not a Volunteer?</asp:Label><br />
            <asp:Label ID="registerTitle2" runat="server">Register As A Volunteer Today!</asp:Label><br /><br />
            <asp:Label ID="volFName" runat="server">First Name: </asp:Label>
            <asp:TextBox ID="userFNameInput" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="volLName" runat="server">Last Name: </asp:Label>
            <asp:TextBox ID="userLNameInput" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="volEmail" runat="server">Email: </asp:Label>
            <asp:TextBox ID="userEmailInput" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="volPassword" runat="server">Password: </asp:Label>
            <asp:TextBox ID="userPasswordInput" runat="server"></asp:TextBox><br /><br />
            
            <asp:Button ID="register_volunteer_button" runat="server" Text="Register Volunteer" onClick="btn_add_volunteer_Click"/>
            
            <hr />

            

            <asp:Label ID="loginTitle" runat="server">Enter your login information.</asp:Label><br /><br />
            <asp:Label ID="loginEmailLabel" runat="server">Email: </asp:Label>
            <asp:TextBox ID="loginEmailInput" runat="server"></asp:TextBox>
            <asp:Label ID="loginPasswordLabel" runat="server">Password: </asp:Label>
            <asp:TextBox ID="loginPasswordInput" runat="server"></asp:TextBox><br /><br />
            
            <asp:Button ID="login_volunteer_button" runat="server" Text="Login" onClick="btn_login_volunteer_Click"/>
            
            <hr />
            <div id="ifLoggedIn" runat="server">
                <asp:Label ID="displayName" runat="server">Your Name.</asp:Label><br /><br />
                <asp:Label ID="displayVolunteer" runat="server"></asp:Label><br /><br />

                <hr />

                <asp:Label ID="volunteeringOpTitle" runat="server">Current Volunteering Options: </asp:Label><br /><br />
                <asp:Label ID="listOfTasks" runat="server"></asp:Label><br /><br />

                <hr />

                <asp:Label ID="changeTitle" runat="server">Change your volunteering?</asp:Label>
                <asp:DropDownList ID="dropdownList" runat="server"></asp:DropDownList>
                <asp:Button ID="updateVolunteer" runat="server" Text="Update Task" onClick="btn_volunteer_update_Click"/>
            
                <hr />
            </div>
            <div id="adminLoggedIn" runat="server">
                <asp:Label ID="viewVolTitle" runat="server">View Task Volunteers</asp:Label>
                <asp:DropDownList ID="viewDropdownList" runat="server"></asp:DropDownList><br /><br />
                <asp:Label ID="displayVolunteers" runat="server"></asp:Label>
                <asp:Button ID="viewListButton" runat="server" Text="View Task Volunteers" onClick="btn_view_volunteers_Click"/>
            
                <hr />

                <asp:Label ID="addTaskTitle" runat="server">Add Volunteer Task</asp:Label><br /><br />
                <asp:Label ID="addTaskName" runat="server">Task Name: </asp:Label>
                <asp:TextBox ID="addTaskNameInput" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="addTaskSup" runat="server">Task Supervisor: </asp:Label>
                <asp:TextBox ID="addTaskSupInput" runat="server"></asp:TextBox><br /><br />
                
                <asp:Button ID="Button1" runat="server" Text="View Task Volunteers" onClick="btn_add_volunteer_task_Click"/>
            
                <hr />

                <asp:Label ID="deleteAccTitle" runat="server">Delete Account</asp:Label><br /><br />
                <asp:Label ID="deleteAcc" runat="server">Account Email: </asp:Label>
                <asp:TextBox ID="deleteAccInput" runat="server"></asp:TextBox><br /><br />
                
                <asp:Button ID="deleteAccButton" runat="server" Text="Delete Volunteer" onClick="btn_delete_volunteer_Click"/>
            
                <hr />
            </div>
            <asp:Label ID="error_message_text" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
