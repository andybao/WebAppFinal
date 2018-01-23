using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bradCampbell_FinalAssignment.Models;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;

namespace bradCampbell_FinalAssignment
{
    public partial class volunteers_page : System.Web.UI.Page
    {
        protected static string myhost = "calvin.humber.ca";
        protected static string port = "1521";
        protected static string sid = "grok";
        protected static string user = "";
        protected static string pass = "";
        protected static string connectionString = OracleConnString(myhost, port, sid, user, pass);
        OracleConnection conn = new OracleConnection(connectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["volLoggedIn"] != null)
            {
                ifLoggedIn.Visible = true;
            }
            else if (Session["adminLoggedIn"] != null)
            {
                adminLoggedIn.Visible = true;
            }
            else
            {
                ifLoggedIn.Visible = false;
                adminLoggedIn.Visible = false;
            }
            
        }

        protected void btn_volunteer_update_Click(object sender, EventArgs e)
        {
            volunteers volunteer = new volunteers();
            volunteer.Volunteer_Task = Convert.ToInt32(dropdownList.SelectedValue);
            volunteer.Volunteer_Email = loginEmailInput.Text;
            volunteer.Volunteer_Password = loginPasswordInput.Text;
            int rows = 0;

            try
            {
                conn.Open();
                

                string command = "UPDATE persons SET person_task = :v_task WHERE person_email = :v_email AND person_pw = :v_pw";

                OracleCommand cmd = new OracleCommand(command, conn);


                cmd.Parameters.Add(new OracleParameter("v_task", volunteer.Volunteer_Task));
                cmd.Parameters.Add(new OracleParameter("v_email", volunteer.Volunteer_Email));
                cmd.Parameters.Add(new OracleParameter("v_pw", volunteer.Volunteer_Password));

                rows = cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (OracleException except)
            {
                error_message_text.Text += except.Message;
            }
            finally
            {
                error_message_text.Text += " " + Convert.ToString(rows) + " rows updated.";
            }
        }
        public static class Validator
        {

            static Regex ValidEmailRegex = CreateValidEmailRegex();

            private static Regex CreateValidEmailRegex()
            {
                string validEmailPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

                return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
            }

            internal static bool EmailIsValid(string emailAddress)
            {
                bool isValid = ValidEmailRegex.IsMatch(emailAddress);

                return isValid;
            }
        }
        protected void btn_login_volunteer_Click(object sender, EventArgs e)
        {
            volunteers volunteer = new volunteers();
            volunteer.Volunteer_Email = loginEmailInput.Text;
            volunteer.Volunteer_Password = loginPasswordInput.Text;
            int rows = 0;
            try
            {

                conn.Open();

                string query = "SELECT * FROM persons JOIN tasks ON person_task = task_id WHERE person_email = :v_email AND person_pw = :v_pw";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.Parameters.Add(new OracleParameter("v_email", volunteer.Volunteer_Email));
                cmd.Parameters.Add(new OracleParameter("v_pw", volunteer.Volunteer_Password));
                
                OracleDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    displayName.Text = reader["person_first_name"] + " " + reader["person_last_name"];
                    if(reader["person_task"] == null)
                    {
                        displayVolunteer.Text += "Not Currently Volunteering";
                    }
                    else
                    {
                        displayVolunteer.Text = "Currently Volunteering with: " + reader["task_name"];
                    }
                    rows++;
                }
                if(volunteer.Volunteer_Email == "admin@admin.com" && volunteer.Volunteer_Password == "admin")
                {
                    adminLoggedIn.Visible = true;
                    Session["adminLoggedIn"] = 1;
                    Session["volLoggedIn"] = null;
                }
                else if(rows > 0)
                {
                    ifLoggedIn.Visible = true;
                    Session["volLoggedIn"] = 1;
                    Session["adminLoggedIn"] = null;
                }
                else
                {
                    ifLoggedIn.Visible = false;
                    error_message_text.Text = "The login information you provided did not match our records.";
                }
                conn.Close();

            }
            catch (OracleException excep)
            {
                error_message_text.Text = excep.ToString();
                error_message_text.Text = excep.Message;
            }
            finally
            {
                
            }
            try
            {
                conn.Open(); //open connection

                string query = "SELECT * FROM tasks";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader reader = cmd.ExecuteReader();
                listOfTasks.Text = "<table style=\"border:1px solid black;text-align:left;\"><tr><th style=\"border:1px solid black;\">Task Name</th><th style=\"border:1px solid black;\">Task Supervisor</th></tr>";
                while (reader.Read())
                {
                    listOfTasks.Text += "<tr><td style=\"border:1px solid black;\">" + reader["task_name"] + "</td><td style=\"border:1px solid black;\">" + reader["task_supervisor"] + "</td><tr>";
                    if(Session["uploaded1"] == null)
                    {
                        ListItem insert = new ListItem(Convert.ToString(reader["task_name"]), Convert.ToString(reader["task_id"]));
                        dropdownList.Items.Insert(dropdownList.Items.Count, insert);
                        
                    }
                    if(Session["uploaded2"] == null)
                    {
                        ListItem insertAdmin = new ListItem(Convert.ToString(reader["task_name"]), Convert.ToString(reader["task_id"]));
                        viewDropdownList.Items.Insert(viewDropdownList.Items.Count, insertAdmin);
                        
                    }
                    
                }
                listOfTasks.Text += "</table>";
                Session["uploaded1"] = 1;
                Session["uploaded2"] = 1;
                conn.Close();
            }
            catch (OracleException excep)
            {
                error_message_text.Text = excep.ToString();
                error_message_text.Text = excep.Message;
            }
            finally
            {

            }
            
        }
        protected void btn_add_volunteer_Click(object sender, EventArgs e)
        {
            volunteers volunteer = new volunteers();
            volunteer.Volunteer_FirstName = userFNameInput.Text;
            volunteer.Volunteer_LastName = userLNameInput.Text;
            volunteer.Volunteer_Email = userEmailInput.Text;
            volunteer.Volunteer_Password = userPasswordInput.Text;
            int rows = 0;
            int testedRows = 0;
            databaseConnect db = new databaseConnect();
            if (userPasswordInput.Text == null || userPasswordInput.Text == "")
            {
                error_message_text.Text = "Please enter your password.";
            }
            else
            {
                if (userLNameInput.Text == null || userLNameInput.Text == "")
                {
                    error_message_text.Text = "Please enter your last name.";
                }
                else
                {
                    if (userFNameInput.Text == null || userFNameInput.Text == "")
                    {
                        error_message_text.Text = "Please enter your first name.";
                    }
                    else
                    { 
                        if (Validator.EmailIsValid(volunteer.Volunteer_Email))
                        {
                            conn.Open();

                            string query1 = "SELECT * FROM persons WHERE person_email = :v_email";

                            OracleCommand cmd1 = new OracleCommand(query1, conn);

                            cmd1.Parameters.Add(new OracleParameter("v_email", volunteer.Volunteer_Email));

                            OracleDataReader reader = cmd1.ExecuteReader();



                            while (reader.Read())
                            {
                                testedRows++;
                            }

                            conn.Close();

                            if (testedRows == 0)
                            {
                                try
                                {

                                    conn.Open();

                                    string command = "INSERT INTO persons VALUES(:v_id, :v_lname, :v_fname, :v_status, :v_email, :v_pw, :v_task)";

                                    OracleCommand cmd = new OracleCommand(command, conn);

                                    cmd.Parameters.Add(new OracleParameter("v_id", null));
                                    cmd.Parameters.Add(new OracleParameter("v_lname", volunteer.Volunteer_LastName));
                                    cmd.Parameters.Add(new OracleParameter("v_fname", volunteer.Volunteer_FirstName));
                                    cmd.Parameters.Add(new OracleParameter("v_status", "Volunteer"));
                                    cmd.Parameters.Add(new OracleParameter("v_email", volunteer.Volunteer_Email));
                                    cmd.Parameters.Add(new OracleParameter("v_pw", volunteer.Volunteer_Password));
                                    cmd.Parameters.Add(new OracleParameter("v_task", 1));

                                    rows = cmd.ExecuteNonQuery();

                                    conn.Close();

                                }
                                catch (OracleException ex)
                                {
                                    error_message_text.Text = ex.Message;
                                }
                                finally
                                {
                                    error_message_text.Text += " " + Convert.ToString(rows) + " rows updated.";
                                }
                            }
                            else
                            {
                                error_message_text.Text = "Email is already in use.";
                            }

                        }
                        else
                        {
                            error_message_text.Text = "Please enter a valid email.";
                        }
                    }
                }

            }
            
        }
        protected void btn_view_volunteers_Click(object sender, EventArgs e)
        {
            volunteers volunteer = new volunteers();
            volunteer.Volunteer_Task = Convert.ToInt32(viewDropdownList.SelectedValue);
            

            try
            {
                conn.Open();


                string command = "SELECT person_first_name, person_last_name, person_email FROM persons WHERE person_task = :v_task";

                OracleCommand cmd = new OracleCommand(command, conn);


                cmd.Parameters.Add(new OracleParameter("v_task", volunteer.Volunteer_Task));
                
                OracleDataReader reader = cmd.ExecuteReader();
                displayVolunteers.Text = "";
                displayVolunteers.Text = "<table style=\"border:1px solid black;text-align:left;\"><tr><th style=\"border:1px solid black;\">First Name</th><th style=\"border:1px solid black;\">Last Name</th><th style=\"border:1px solid black;\">Email</th></tr>";
                while (reader.Read())
                {
                    displayVolunteers.Text += "<tr><td style=\"border:1px solid black;\">" + reader["person_first_name"] + "</td><td style=\"border:1px solid black;\">" + reader["person_last_name"] + "</td><td style=\"border:1px solid black;\">" + reader["person_email"] + "</td><tr>";
                    
                }
                displayVolunteers.Text += "</table>";

                conn.Close();
            }
            catch (OracleException except)
            {
                error_message_text.Text += except.Message;
            }
            finally
            {
                
            }
        }
        protected void btn_add_volunteer_task_Click(object sender, EventArgs e)
        {
            string taskName = addTaskNameInput.Text;
            string taskSup = addTaskSupInput.Text;
            
            int rows = 0;
            
            databaseConnect db = new databaseConnect();
            try
            {

                conn.Open();

                string command = "INSERT INTO tasks VALUES(:t_id, :t_name, :t_sup)";

                OracleCommand cmd = new OracleCommand(command, conn);

                cmd.Parameters.Add(new OracleParameter("t_id", null));
                cmd.Parameters.Add(new OracleParameter("t_name", taskName));
                cmd.Parameters.Add(new OracleParameter("t_sup", taskSup));
           

                rows = cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (OracleException ex)
            {
                error_message_text.Text = ex.Message;
            }
            finally
            {
                error_message_text.Text += " " + Convert.ToString(rows) + " rows updated.";
            }
        }
        protected void btn_delete_volunteer_Click(object sender, EventArgs e)
        {
            volunteers volunteer = new volunteers();
            volunteer.Volunteer_Email = deleteAccInput.Text;

            int rows = 0;

            databaseConnect db = new databaseConnect();
            try
            {

                conn.Open();

                string command = "DELETE FROM persons WHERE person_email = :v_email";

                OracleCommand cmd = new OracleCommand(command, conn);

                cmd.Parameters.Add(new OracleParameter("v_email", volunteer.Volunteer_Email));

                rows = cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (OracleException ex)
            {
                error_message_text.Text = ex.Message;
            }
            finally
            {

            }
        }
        public static string OracleConnString(string host, string port, string servicename, string user, string pass)
        {
            return String.Format(
              "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
              "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
              host,
              port,
              servicename,
              user,
              pass);
        }
    }
    
}