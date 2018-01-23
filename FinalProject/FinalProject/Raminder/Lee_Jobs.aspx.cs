using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.Models;
using Oracle.ManagedDataAccess.Client;

namespace FinalProject
{
    public partial class Lee_Jobs : System.Web.UI.Page
    {
        protected static string myhost = "calvin.humber.ca";
        protected static string port = "1521";
        protected static string sid = "grok";
        protected static string user = OracleCredentials.username;
        protected static string pass = OracleCredentials.password;
        protected static string connectionString = OracleConnString(myhost, port, sid, user, pass);
        OracleConnection conn = new OracleConnection(connectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
           

        }

        protected void btn_view_jobs_Click(object sender, EventArgs e)
        {
            string query = "SELECT job_id AS id, job_type AS jtype, job_title As jtitle, job_info As jinfo, job_start_date As jstart, job_end_date As jend, job_location As jloc, job_salary As jsal, job_person_id As pid   FROM lee_jobs";

            try
            {
                conn.Open(); //open connection



                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    list_jobs.InnerHtml += "<li>" + reader["id"] + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" 
                        + reader["jtype"]  + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" 
                        + reader["jtitle"] + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" 
                        + reader["jinfo"]  + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" 
                        + reader["jstart"] + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" 
                        + reader["jend"]   + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;"
                        + reader["jloc"]   + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" 
                        + reader["jsal"]   + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;"
                        + reader["pid"]    + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + "</li>";
                    
                }
                conn.Close(); //close connection
            }
            catch (OracleException excep)
            {
                list_jobs.InnerHtml = excep.ToString();
                list_jobs.InnerHtml = excep.Message;

            }
            finally
            {
                list_jobs.InnerHtml += " Database operations ceased.";
            }

        }

        protected void btn_add_jobs_Click(object sender, EventArgs e)
            {
                string job_id = txt_id.Text;
                string job_type;
                string job_title = dropdownlist1.SelectedItem.Text;
                string job_info = txt_info.Text;
            DateTime job_start_date = Convert.ToDateTime(date_picker.Value);
            //DateTime job_start_date = txt_start.Text;
            string job_end_date = txt_end.Text;
                string job_location = txt_loc.Text;
                string job_salary = txt_salary.Text;
                string job_person_id = txt_p_id.Text;

            //DateTime dDate;
            //dDate = DateTime.TryParse(txt_start.Text);
            //String.Format("{0:d/MM/yyyy}", dDate);
            if (rb_part.Checked)
            {
                job_type = "Part Time";
            }

            else
            {
                job_type = "Full Time";
            }
            if (job_start_date == null)
            {
                valid_start.Text = "Choose a start date";
            }

            int rows = 0;
                try
                {
                    conn.Open();

                 string   command = "INSERT INTO lee_jobs VALUES(:Id, :type, :title, :info, :start_date, :end_date, :loc, :salary, :p_id)"; //prepared statement

                    OracleCommand cmd = new OracleCommand(command, conn);
                    cmd.Parameters.Add(new OracleParameter("Id", job_id));
                    cmd.Parameters.Add(new OracleParameter("type", job_type));
                    cmd.Parameters.Add(new OracleParameter("title", job_title));
                    cmd.Parameters.Add(new OracleParameter("info", job_info));
                    cmd.Parameters.Add(new OracleParameter("start_date", job_start_date));
                    cmd.Parameters.Add(new OracleParameter("end_date", job_end_date));
                    cmd.Parameters.Add(new OracleParameter("loc", job_location));
                    cmd.Parameters.Add(new OracleParameter("salary", job_salary));
                    cmd.Parameters.Add(new OracleParameter("p_id", job_person_id));
                   
                    rows = cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (OracleException excep)
                {
                    lbl_server_message.Text = excep.Message;
                }
                finally
                {
                    lbl_server_message.Text += Convert.ToString(rows) + " rows affected";
                }

            

            
            if (job_id.Trim() == "")
            {
                valid_id.Text = "Job id is required";
            }
            
            for (int i = 0; i < job_id.Length; i++)
            {
                if (!char.IsNumber(job_id[i]))
                {
                    valid_id.Text = "Please enter a valid number";
                    txt_id.Text = "";
                    return;
                }
            }
           
            if (dropdownlist1.SelectedItem.Text == "Select")
            {
                valid_title.Text = "Please Select Job Title.";
            }
            if (txt_info.Text == "" || txt_info.Text == null)
            {
                valid_info.Text = "Job info is required";
            }
            if (date_picker.Value == null)
            {
                valid_start.Text =  "Job start date is required";
            }


            if (txt_loc.Text == "")
            {
                valid_location.Text = "Job location is required";
            }
           
            if (job_salary.Trim() == "")
            {
                valid_salary.Text = "Job salary is required";
            }

            for (int i = 0; i < job_salary.Length; i++)
            {
                if (!char.IsNumber(job_salary[i]))
                {
                    valid_salary.Text = "A valid amount is required";
                    txt_salary.Text = "";
                    return;
                }
            }

            if (txt_p_id.Text == "" )
            {
                valid_pid.Text = "Person Id is required";
            }
        }

        protected void btn_update_jobs_Click(object sender, EventArgs e)
        {
            string job_id = txt_id.Text;
            string job_type ;
            string job_title = dropdownlist1.SelectedItem.Text;
            string job_info = txt_info.Text;
            DateTime job_start_date = Convert.ToDateTime(date_picker.Value);
            //string job_start_date = txt_start.Text;
            string job_end_date = txt_end.Text;
            string job_location = txt_loc.Text;
            string job_salary = txt_salary.Text;
            string job_person_id = txt_p_id.Text;

            if (rb_part.Checked)
            {
                job_type = "Part Time";
            }

            else
            {
                job_type = "Full Time";
            }


            if (job_id.Trim() == "")
            {
                valid_id.Text = "Job id is required";
            }

            for (int i = 0; i < job_id.Length; i++)
            {
                if (!char.IsNumber(job_id[i]))
                {
                    valid_id.Text = "Please enter a valid number";
                    txt_id.Text = "";
                    return;
                }
            }
           
            
            int rows = 0;
            try
            {
                conn.Open();

                string   command = "UPDATE lee_jobs " +
                    "SET job_type = :type, job_title = :title, job_info = :info, job_start_date = :s_date, job_end_date = :e_date, job_location = :loc, job_salary = :salary, job_person_id = :p_id " +
                    "WHERE job_id = :Id";

                OracleCommand cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("type", job_type));
                cmd.Parameters.Add(new OracleParameter("title", job_title));
                cmd.Parameters.Add(new OracleParameter("info", job_info));
                cmd.Parameters.Add(new OracleParameter("s_date", job_start_date));
                cmd.Parameters.Add(new OracleParameter("e_date", job_end_date));
                cmd.Parameters.Add(new OracleParameter("loc", job_location));
                cmd.Parameters.Add(new OracleParameter("salary", job_salary));
                cmd.Parameters.Add(new OracleParameter("p_id", job_person_id));
                cmd.Parameters.Add(new OracleParameter("Id", job_id));


                rows = cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (OracleException except)
            {
                lbl_server_message.Text += except.Message;
            }
            finally
            {
                lbl_server_message.Text += " " + Convert.ToString(rows) + " rows updated.";
            }
        }

        protected void btn_delete_jobs_Click(object sender, EventArgs e)
        {
            string job_id = txt_id.Text;
           string  command = "DELETE FROM lee_jobs WHERE job_id = :Id";

            if (job_id.Trim() == "")
            {
                valid_id.Text = "Enter Job Id which you want to delete";
            }

            for (int i = 0; i < job_id.Length; i++)
            {
                if (!char.IsNumber(job_id[i]))
                {
                    valid_id.Text = "Please enter a valid number";
                    txt_id.Text = "";
                    return;
                }
            }

            int rows = 0;
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("Id", job_id));
                rows = cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (OracleException ex)
            {
                lbl_server_message.Text = ex.Message;
            }
            finally
            {
                lbl_server_message.Text = Convert.ToString(rows) + " rows deleted";
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
