using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project_C_Sharp.Models;
using Oracle.ManagedDataAccess.Client;

namespace Final_Project_C_Sharp
{
    public partial class NewQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear error/success messages
            error_cat.Text = msg.Text = error_question_desc.Text = error_answer.Text = "";

            // Check if user is authorized, then show him greeting message, else redirect him to login page
            if (String.IsNullOrEmpty((string)Session["admin"]))
            {
                Response.Redirect("Login.aspx");
            }
            else {
                
            }
        }

        protected void btn_add_new_Click(object sender, EventArgs e)
        {
            // Check if question was not empty
            if ("" == txt_question_desc.Text || null == txt_question_desc.Text)
            {
                error_question_desc.Text = "Question must be entered.";
                return;
            }

            // Check if answer was not empty
            if ("" == txt_answer.Text || null == txt_answer.Text)
            {
                error_answer.Text = "Answer must be entered.";
                return;
            }

            // add new question and answer
            int res_rows = Add_New(txt_question_desc.Text, txt_answer.Text, Convert.ToInt32(slc_cat.SelectedValue));
            if (res_rows > 0)
            {
                msg.Text += "Congrats! Question was added successfully.";
            }
            else
            {
                msg.Text += "Sorry, nothing was added.";
            }
            
        }

        // Updates Question description and Answer description in DB
        public int Add_New(string question_desc, string answer_desc, int cat_id)
        {

            // Establish connection
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnectDb.connectionString;
            conn.Open();
            
            string command;
            int rows = 0;
            OracleCommand cmd;

            try
            {
                // Insert new answer
                command = "INSERT INTO " + ConnectDb.username + ".t_answers VALUES( " + ConnectDb.username + ".t_answers_seq.NEXTVAL, :ans_desc)";
                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("ans_desc", answer_desc));
                rows += cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                msg.Text += ex.Message;
            }

            try
            {
                // Insert new question
                command = "INSERT INTO " + ConnectDb.username + ".t_questions (question_id, answer_id, category_id, description) VALUES(" +
                    ConnectDb.username + ".t_questions_seq.NEXTVAL, " + ConnectDb.username + ".t_answers_seq.CURRVAL, :category_id, :ques_desc)";
                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("category_id", cat_id));
                cmd.Parameters.Add(new OracleParameter("ques_desc", question_desc));
                rows += cmd.ExecuteNonQuery();

            }
            catch (OracleException ex)
            {
                msg.Text += ex.Message;
            }

            conn.Close();
            return rows;
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Authorized.aspx");
        }
    }
}