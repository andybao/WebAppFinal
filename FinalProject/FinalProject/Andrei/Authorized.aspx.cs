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
    public partial class Authorized : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear error/success messages
            error_question.Text = msg.Text = "";

            // Check if user is authorized, then show him greeting message, else redirect him to login page
            if (!String.IsNullOrEmpty((string)Session["admin"]))
            {
                // Show all FAQ questions
                // Create a table
                faq_list.InnerHtml = "<table>";
                List<Question> faq_questions = Get_All();

                // Go through the list and display
                foreach (Question question in faq_questions)
                {   
                    faq_list.InnerHtml += "<tr><td><span class='question'>" + question.Question_Description  + "</span>" +
                        "<span class='answer'>" + question.Answer_Description + 
                        "</span><span class='meta'>Question # " + question.Question_ID + ", created: " + question.Created + " by "
                        + question.L_Name + " " + question.F_Name  +
                        " in category " + question.Category_Description  + ".</span></td>" +
                        "</tr><tr class='spacer'></tr>";
                }
                // Close the table
                faq_list.InnerHtml += "</table>";
            }
            else {
                Response.Redirect("Login.aspx");
            }
        }

        // Clears session variables and redirects to login page
        protected void btn_logout_Click(object sender, EventArgs e)
        {
            // Remove session variable
            //Session.Remove("email");

            // Clear all session values
            Session.Clear();

            // Ends the session
            //Session.Abandon();

            Response.Redirect("Login.aspx");
        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            // Check if question ID is valid
            if ("" == txt_question.Text || null == txt_question.Text)
            {
                error_question.Text = "Question ID must be entered.";
                return;
            }

            Question my_question = new Question();
            my_question = Get_Question(txt_question.Text);
            

            // Check if question was found
            if (0 != Convert.ToInt32(my_question.Question_ID))
            {
                // Show form and populate fields with data from DB
                txt_question.Text = Convert.ToString(my_question.Question_ID);
                txt_question_desc.Text = my_question.Question_Description;
                txt_answer.Text = my_question.Answer_Description;
            }
            else {
                error_question.Text = "Question with ID " + txt_question.Text + " was not found.";
            }
                      
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            // Check if question ID is valid
            if ("" == txt_question.Text || null == txt_question.Text)
            {
                error_question.Text = "Question ID must be entered.";
                return;
            }
            int res_rows = Delete(txt_question.Text);
            if (res_rows > 0)
            {
                msg.Text += "Congrats! Question was deleted successfully.";
            }
            else
            {
                msg.Text += "Sorry, nothing was deleted.";
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            // Check if question ID is valid
            if ("" == txt_question.Text || null == txt_question.Text)
            {
                error_question.Text = "Question ID must be entered.";
                return;
            }
            int res_rows = Update(txt_question.Text);
            if ( res_rows > 0)
            {
                msg.Text += "Congrats! Question was updated successfully.";
            }
            else
            {
                msg.Text += "Sorry, nothing was updated.";
            }
            
        }

        protected void btn_add_Click(object sender, EventArgs e) {
            Response.Redirect("NewQuestion.aspx");
        }

        // Returns all questions with answers from DB
        public List<Question> Get_All() {
            // Establish connection
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnectDb.connectionString;

            string command = "SELECT q.question_id AS question_no" +
                ", q.answer_id AS answer_no" +
                ", q.category_id AS category_no" +
                ", owner" +
                ", created" +
                ", modified" +
                ", q.description AS question" +
                ", a.description AS answer" +
                ", c.description AS category" +
                ", p.person_last_name AS l_name" +
                ", p.person_first_name AS f_name" +
                " FROM " + ConnectDb.username + ".t_questions q" +
                " JOIN " + ConnectDb.username + ".t_answers a" +
                " ON q.answer_id = a.answer_id" +
                " INNER JOIN " + ConnectDb.username + ".t_categories c" +
                " ON q.category_id = c.category_id" +
                " JOIN " + ConnectDb.username + ".persons p" +
                " ON p.person_status = q.owner" +
                " ORDER BY q.question_id";
            conn.Open();
            OracleCommand cmd = new OracleCommand(command, conn);
            OracleDataReader reader = cmd.ExecuteReader();

            // Create empty list which will be returned.
            List<Question> qs_list = new List<Question> { };
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Add object into list
                        qs_list.Add(Populate_Question(reader));
                    }
                }
                else
                {
                    faq_list.InnerHtml += "No rows fetched, sorry. Your SQL command is: " + command;
                }
            }
            catch { }
            conn.Close();
            return qs_list;
        }

        // Returns Question object populated with data from DB
        public Question Populate_Question(OracleDataReader reader) {

            // Create temp object to hold current info about question
            Question temp_qs = new Question();

            // Populate fields of this temp object with values from the DB
            temp_qs.Question_ID = Convert.ToInt32(reader["question_no"]);
            temp_qs.Answer_ID = Convert.ToInt32(reader["answer_no"]);
            temp_qs.Category_ID = Convert.ToInt32(reader["category_no"]);
            temp_qs.Question_Description = Convert.ToString(reader["question"]);
            temp_qs.Answer_Description = Convert.ToString(reader["answer"]);
            temp_qs.Category_Description = Convert.ToString(reader["category"]);
            temp_qs.Owner = Convert.ToString(reader["owner"]);
            temp_qs.Created = Convert.ToString(reader["created"]);
            temp_qs.Modified = Convert.ToString(reader["modified"]);
            temp_qs.L_Name = Convert.ToString(reader["l_name"]);
            temp_qs.F_Name = Convert.ToString(reader["f_name"]);

            return temp_qs;
        }

        // Returns specific question from DB by ID
        public Question Get_Question(string question_id)
        {
            // Establish connection
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnectDb.connectionString;

            string command = "SELECT q.question_id AS question_no" +
                ", q.answer_id AS answer_no" +
                ", q.category_id AS category_no" +
                ", owner" +
                ", created" +
                ", modified" +
                ", q.description AS question" +
                ", a.description AS answer" +
                ", c.description AS category" +
                ", p.person_last_name AS l_name" +
                ", p.person_first_name AS f_name" +
                " FROM " + ConnectDb.username + ".t_questions q" +
                " INNER JOIN " + ConnectDb.username + ".t_answers a" +
                " ON q.answer_id = a.answer_id" +
                " INNER JOIN " + ConnectDb.username + ".t_categories c" +
                " ON q.category_id = c.category_id" +
                " JOIN " + ConnectDb.username + ".persons p" +
                " ON p.person_status = q.owner" +
                " WHERE q.question_id = :question";
            conn.Open();
            OracleCommand cmd = new OracleCommand(command, conn);
            cmd.Parameters.Add(new OracleParameter("question", question_id));

            OracleDataReader reader = cmd.ExecuteReader();
            // Create temp object to hold current info about question
            Question temp_qs = new Question();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Populate fields of this temp object with values from the DB
                        temp_qs = Populate_Question(reader);
                    }
                }
            }
            catch { }
            conn.Close();
            return temp_qs;
        }

        // Updates Question description and Answer description in DB
        public int Update(string question_id) {

            // Establish connection
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnectDb.connectionString;
            conn.Open();

            Question my_question = new Question();
            my_question = Get_Question(question_id);

            string command;
            int rows = 0;
            OracleCommand cmd;

            try
            {
                // Update questions table in DB
                command = "UPDATE " + ConnectDb.username + ".t_questions SET description = :ques_desc WHERE question_id = :ques_id";
                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("ques_desc", txt_question_desc.Text));
                cmd.Parameters.Add(new OracleParameter("ques_id", txt_question.Text));
                rows += cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                msg.Text += ex.Message;
            }

            try
            {
                // Update answers table in DB
                command = "UPDATE " + ConnectDb.username + ".t_answers SET description = :ans_desc WHERE answer_id = :ans_id";
                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("ans_desc", txt_answer.Text));
                cmd.Parameters.Add(new OracleParameter("ans_id", my_question.Answer_ID));
                rows += cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                msg.Text += ex.Message;
            }

            conn.Close();
            return rows;
        }

        // Deletes Question and Answer from DB
        public int Delete(string question_id)
        {

            // Establish connection
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnectDb.connectionString;
            conn.Open();

            Question my_question = new Question();
            my_question = Get_Question(question_id);

            string command;
            int rows = 0;
            OracleCommand cmd;

            try
            {
                // Update questions table in DB
                command = "DELETE FROM " + ConnectDb.username + ".t_questions WHERE question_id = :ques_id";
                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("ques_id", txt_question.Text));
                rows += cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                msg.Text += ex.Message;
            }

            try
            {
                // Update answers table in DB
                command = "DELETE FROM " + ConnectDb.username + ".t_answers WHERE answer_id = :ans_id";
                cmd = new OracleCommand(command, conn);
                cmd.Parameters.Add(new OracleParameter("ans_id", my_question.Answer_ID));
                rows += cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                msg.Text += ex.Message;
            }

            conn.Close();
            return rows;
        }

        protected void btn_logout_Click1(object sender, EventArgs e)
        {

        }
    }
}