using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;


namespace ECards
{
    public partial class ecards : System.Web.UI.Page
    {
        //Connecting to database
        protected static string myhost = "calvin.humber.ca";
        protected static string port = "1521";
        protected static string sid = "grok";
        protected static string user = "n01257490";
        protected static string pass = "oracle";
        protected static string connectionString = OracleConnString(myhost, port, sid, user, pass);
        OracleConnection conn = new OracleConnection(connectionString);

        // Database driven variabless
        string select_statment;
        string command;
        int rows;

        // Variables to hold data input
        string ecard_id;
        string sender_fname;
        string sender_lname;
        string sender_email;
        int person_id;
        string patient_fname;
        string patient_lname;
        string card_choice;
        string card_message;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // READ BY ECARD ID
        protected void check_by_id_input_Click(object sender, EventArgs e)
        {
            // Setting Variables
            select_statment = "SELECT * FROM ecards WHERE ecard_id = :id_input";
            ecard_id = ecardId_input.Text;

            // Validation
            Regex regex = new Regex(@"^[0-9]+$");
            Match match = regex.Match(ecard_id);
            if (match.Success)
            {
                server_output.InnerHtml = "";
                id_err.Text = "";
                rows = 0;
                try
                {
                    conn.Open(); // Open Connection

                    // Execute Oracle Command 
                    OracleCommand cmd = new OracleCommand(select_statment, conn);
                    cmd.Parameters.Add(new OracleParameter("id_input", Convert.ToInt32(ecard_id)));

                    OracleDataReader reader = cmd.ExecuteReader();

                    // Filling TextBoxes with the current data (for update)
                    while (reader.Read()) // Placing old values into TextBoxes by ID#
                    {
                        s_fname_input.Text = Convert.ToString(reader["sender_first_name"]);
                        s_lname_input.Text = Convert.ToString(reader["sender_last_name"]);
                        s_email_input.Text = Convert.ToString(reader["sender_email"]);
                        person_id = Convert.ToInt32(reader["person_id"]);
                        card_choice_input.SelectedValue = Convert.ToString(reader["card_choice"]);
                        message_input.Text = Convert.ToString(reader["card_message"]);
                        rows += 1;
                    }

                    if (rows > 0)
                    {
                        rows = 0;
                        // Grabbing Patient ID from persons table
                        select_statment = "SELECT * FROM persons WHERE person_id = :p_id";

                        // Execute Oracle Command
                        OracleCommand cmd1 = new OracleCommand(select_statment, conn);
                        cmd1.Parameters.Add(new OracleParameter("p_id", person_id));

                        OracleDataReader reader2 = cmd1.ExecuteReader();

                        // Filling in Patient Name via Patient ID for Update
                        while (reader2.Read())
                        {
                            p_fname_input.Text = Convert.ToString(reader2["person_first_name"]);
                            p_lname_input.Text = Convert.ToString(reader2["person_last_name"]);
                        }
                    }
                    else
                    {
                        server_output.InnerHtml = "ID does not exist.";
                    }
                    conn.Close(); // Close Connection
                }
                catch (OracleException ex)
                {
                    server_output.InnerHtml = "</br>" + ex.Message;
                }
                finally
                {
                    server_output.InnerHtml += "</br>Transaction Completed.";
                }

            }
            else
            {
                id_err.Text = "Invalid ID input.";
            }
        }

        // UPDATE BY ECARD ID
        protected void update_by_id_Click(object sender, EventArgs e)
        {
            // Setting bind variables from textboxes
            sender_fname = s_fname_input.Text;
            sender_lname = s_lname_input.Text;
            sender_email = s_email_input.Text;
            patient_fname = p_fname_input.Text;
            patient_lname = p_lname_input.Text;
            card_choice = card_choice_input.SelectedValue;
            card_message = message_input.Text;
            ecard_id = ecardId_input.Text;

            Regex idregex = new Regex(@"^[0-9]+$");
            Match idmatch = idregex.Match(ecard_id);
               // Validate Inputs
            if (sender_fname == "" || sender_fname == "" || sender_email == "" || patient_fname == "" || patient_lname == "" || card_message == "" || !idmatch.Success)
            {
                server_output.InnerHtml = "Please fill in all areas with valid inputs.";
            }
            else
            {
                server_output.InnerHtml = "";
                id_err.Text = "";
                // Validate Inputs 
                sender_email = s_email_input.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(sender_email);
                if (match.Success)
                {
                    // Resetting Rows
                    rows = 0;
                    try
                    {
                        conn.Open(); // Open Connection

                        // Grabbing Patient ID from persons table
                        select_statment = "SELECT * FROM persons WHERE upper(person_first_name) = upper(:p_fname) AND upper(person_last_name) = upper(:p_lname)";

                        // Execute Oracle Command
                        OracleCommand cmd1 = new OracleCommand(select_statment, conn);
                        cmd1.Parameters.Add(new OracleParameter("p_fname", patient_fname));
                        cmd1.Parameters.Add(new OracleParameter("p_lname", patient_lname));

                        OracleDataReader reader = cmd1.ExecuteReader();

                        // Grabbing Patient ID for Update Statement
                        while (reader.Read())
                        {
                            person_id = Convert.ToInt32(reader["person_id"]);
                            rows += 1;
                        }

                        if (rows > 0)
                        {
                            rows = 0;
                            // Execute Update Statement
                            command = "UPDATE ecards " +
                                        "SET sender_first_name = :s_fname, " +
                                        "sender_last_name = :s_lname, " +
                                        "sender_email = :s_email, " +
                                        "person_id = :p_id, " +
                                        "card_choice = :c_choice, " +
                                        "card_message = :c_message " +
                                        "WHERE ecard_id = :ecardID";
                            OracleCommand cmd = new OracleCommand(command, conn);

                            // Setting Bind Variables
                            cmd.Parameters.Add(new OracleParameter("s_fname", sender_fname));
                            cmd.Parameters.Add(new OracleParameter("s_lname", sender_lname));
                            cmd.Parameters.Add(new OracleParameter("s_email", sender_email));
                            cmd.Parameters.Add(new OracleParameter("p_id", person_id));
                            cmd.Parameters.Add(new OracleParameter("c_choice", card_choice));
                            cmd.Parameters.Add(new OracleParameter("c_message", card_message));
                            cmd.Parameters.Add(new OracleParameter("ecardID", Convert.ToInt32(ecard_id)));

                            // Checking number of rows affected
                            rows = cmd.ExecuteNonQuery();
                        }
                        else
                        {
                           server_output.InnerHtml = "There is no one at the hospital with this name.";
                        }

                        // Close Connection
                        conn.Close();
                    }
                    catch (OracleException ex)
                    {
                        server_output.InnerHtml = "</br>" + ex.Message;
                    }
                    finally
                    {
                        // Outputing results
                        server_output.InnerHtml = "</br>" + Convert.ToString(rows) + " rows updated.";
                    }// End of try catch
                } // End of if else
            } // End of if else
        } // End of update click

        // DELETE ECARD BY ECARD ID
        protected void delete_by_id_Click(object sender, EventArgs e)
        {
            rows = 0;
            // Deleting Row from Database
            ecard_id = ecardId_input.Text;
            command = "DELETE FROM ecards WHERE ecard_id = :ecardID";

            // Validation
            Regex regex = new Regex(@"^[0-9]+$");
            Match match = regex.Match(ecard_id);
            if (match.Success)
            {
                server_output.InnerHtml = "";
                id_err.Text = "";
                
                try
                {
                    conn.Open(); // Open Connection

                    // Execute Oracle Command
                    OracleCommand cmd = new OracleCommand(command, conn);
                    cmd.Parameters.Add(new OracleParameter("ecardID", Convert.ToInt32(ecard_id)));
                    rows = cmd.ExecuteNonQuery();

                    if (rows < 1)
                    {
                            server_output.InnerHtml = "ID does not exist.";
                    }

                    conn.Close(); // Close Connection
                }
                catch (OracleException ex)
                {
                    server_output.InnerHtml = "<div>" + ex.Message + "</div>";
                }
                finally
                {
                    // Outputting results
                    server_output.InnerHtml = "<div>" + Convert.ToString(rows) + " rows deleted.</div>";
                }
            }
            else
            {
                id_err.Text = "Invalid ID input.";
                server_output.InnerHtml = "<div>" + Convert.ToString(rows) + " rows deleted.</div>";
            }
        }   

        // CREATE NEW ROW IN DATABASE
        protected void send_card_btn_Click(object sender, EventArgs e)
        {
            // Setting bind variables from textboxes
            sender_fname = s_fname_input.Text;
            sender_lname = s_lname_input.Text;
            sender_email = s_email_input.Text;
            patient_fname = p_fname_input.Text;
            patient_lname = p_lname_input.Text;
            card_choice = card_choice_input.SelectedValue;
            card_message = message_input.Text;

            if(sender_fname == "" || sender_fname == "" || sender_email == "" ||patient_fname == "" || patient_lname == "" || card_message == "") {
                server_output.InnerHtml = "Please fill in all areas.";
            }
            else
            {
                // Validate Inputs 
                sender_email = s_email_input.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(sender_email);
                if (match.Success)
                {
                    // Resetting Rows
                    rows = 0;
                    try
                    {
                        conn.Open(); // Open Connection

                        // Grabbing Patient ID from persons table
                        select_statment = "SELECT * FROM persons WHERE upper(person_first_name) = upper(:p_fname) AND upper(person_last_name) = upper(:p_lname)";

                        // Executing Oracle Command
                        OracleCommand cmd1 = new OracleCommand(select_statment, conn);
                        cmd1.Parameters.Add(new OracleParameter("p_fname", patient_fname));
                        cmd1.Parameters.Add(new OracleParameter("p_lname", patient_lname));

                        OracleDataReader reader = cmd1.ExecuteReader();

                        // Grabbing n ID for Insert bind variable
                        while (reader.Read())
                        {
                            person_id = Convert.ToInt32(reader["person_id"]);
                            rows += 1;
                        }

                        if (rows > 0)
                        {
                            rows = 0;
                            // Execute Update Statement
                            command = "INSERT INTO ecards "
                                    + "VALUES (ecard_id_seq.nextval, :s_fname, :s_lname, :s_email, :p_id, :c_choice, :c_message)";
                            OracleCommand cmd = new OracleCommand(command, conn);

                            // Setting Bind Variables
                            cmd.Parameters.Add(new OracleParameter("s_fname", sender_fname));
                            cmd.Parameters.Add(new OracleParameter("s_lname", sender_lname));
                            cmd.Parameters.Add(new OracleParameter("s_email", sender_email));
                            cmd.Parameters.Add(new OracleParameter("p_id", person_id));
                            cmd.Parameters.Add(new OracleParameter("c_choice", card_choice));
                            cmd.Parameters.Add(new OracleParameter("c_message", card_message));

                            rows = cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            patient_err.Text = "There is no one at the hospital with this name.";
                        }
                        // Close Connection
                        conn.Close();
                    }
                    catch (OracleException ex)
                    {
                        server_output.InnerHtml = "<div>" + ex.Message + "</div>";
                    }
                    finally
                    {
                        // Outputting Results
                        server_output.InnerHtml += "<div>" + Convert.ToString(rows) + " ecard created. </div>";
                    }
                }
                else
                {
                    email_err.Text = "Email is incorrect";
                }
            }
            
        }

        protected void ecards_by_email_btn_Click(object sender, EventArgs e)
        {
            // Setting Variables
            email_err.Text = "";
            server_output.InnerHtml = "";
            sender_email = s_email_input.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(sender_email);
            if (match.Success)
            {
                email_err.Text = "";
                server_output.InnerHtml = "";
                try
                {
                    conn.Open(); // Open Connection

                    // Execute Oracle Command
                    select_statment = "SELECT * FROM ecards WHERE sender_email = :email_input";
                    OracleCommand cmd = new OracleCommand(select_statment, conn);
                    cmd.Parameters.Add(new OracleParameter("email_input", sender_email));
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) //Displaying each card sent by email input 
                    { // NOTE TO SELF: CHANGE PATIENT ID TO persons NAME, FIRST AND LAST TO COMPLETE THIS SECTION
                        server_output.InnerHtml += "</br><strong>E-Card ID: </strong>" + reader["ecard_id"]
                                                  + ",<strong> Sender: </strong>" + reader["sender_first_name"] + " " + reader["sender_last_name"]
                                                  + ",<strong> Sender E-Mail: </strong>" + reader["sender_email"]
                                                  + ",<strong> Patient: </strong>" + reader["person_id"]
                                                  + ",<strong> Card Option: </strong>" + reader["card_choice"]
                                                  + ",<strong> Message: </strong>" + reader["card_message"];
                    }
                    conn.Close();
                }
                catch (OracleException ex)
                {
                    server_output.InnerHtml += "<div>" + ex.Message + "</div>";
                }
                finally
                {
                    server_output.InnerHtml += "<div>Completed.</div>";
                }
            }
            else
            {
                email_err.Text = "Email input is incorrect";
            }
        }

        // Connecting to Database
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

        protected void all_ecards_Click(object sender, EventArgs e)
        {
            conn.Open(); // Open Connection

            // Execute Oracle Command
            select_statment = "SELECT * FROM ecards";
            OracleCommand cmd = new OracleCommand(select_statment, conn);
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) //Displaying each card sent by email input 
            { 
                server_output.InnerHtml += "</br><strong>E-Card ID: </strong>" + reader["ecard_id"]
                                          + ",<strong> Sender: </strong>" + reader["sender_first_name"] + " " + reader["sender_last_name"]
                                          + ",<strong> Sender E-Mail: </strong>" + reader["sender_email"]
                                          + ",<strong> Patient: </strong>" + reader["person_id"]
                                          + ",<strong> Card Option: </strong>" + reader["card_choice"]
                                          + ",<strong> Message: </strong>" + reader["card_message"];
            }
            conn.Close();
        }
    }
}