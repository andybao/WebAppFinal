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
    public partial class FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Show all FAQ questions
            // Create a table
            faq_list.InnerHtml = "<table>";
            List<Question> faq_questions = Get_All();

            // Go through the list and display
            foreach (Question question in faq_questions)
            {
                // If no answer substitute with placeholder text
                string answer_out = "[No answer yet]";
                if ("empty" != question.Answer_Description) {
                    answer_out = question.Answer_Description;
                }
            
                faq_list.InnerHtml += "<tr><td><span class='question'>" + question.Question_Description + "</span>" +
                    "<span class='answer'>" + answer_out + "</span></td>" +
                    "</tr><tr class='spacer'></tr>";
            }
            // Close the table
            faq_list.InnerHtml += "</table>";
        }

        // Returns all questions with answers from DB
        public List<Question> Get_All()
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
                " FROM " + ConnectDb.username + ".t_questions q" +
                " INNER JOIN " + ConnectDb.username + ".t_answers a" +
                " ON q.answer_id = a.answer_id" +
                " INNER JOIN " + ConnectDb.username + ".t_categories c" +
                " ON q.category_id = c.category_id" +
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
        public Question Populate_Question(OracleDataReader reader)
        {
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
            
            return temp_qs;
        }

        protected void btn_client_add_new_Click(object sender, EventArgs e)
        {
            // Check if question was not empty
            if ("" == txt_question_desc.Text || null == txt_question_desc.Text)
            {
                error_question_desc.Text = "Question must be entered.";
                return;
            }

            // add new question and answer
            int res_rows = Add_New(txt_question_desc.Text, Convert.ToInt32(slc_cat.SelectedValue));
            if (res_rows > 0)
            {
                msg.Text += "Thank yo for your question. It was sent successfully.";
            }
            else
            {
                msg.Text += "Sorry, nothing was added.";
            }
        }

        // Updates Question description and Answer description in DB
        public int Add_New(string question_desc, int cat_id)
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
                command = "INSERT INTO " + ConnectDb.username + ".t_answers VALUES( " + ConnectDb.username + ".t_answers_seq.NEXTVAL, 'empty')";
                cmd = new OracleCommand(command, conn);
                rows += cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                msg.Text += ex.Message;
            }

            try
            {
                // Insert new question
                command = "INSERT INTO " + ConnectDb.username + ".t_questions (question_id, answer_id, category_id, owner, description) VALUES(" +
                    ConnectDb.username + ".t_questions_seq.NEXTVAL, " +
                    ConnectDb.username + ".t_answers_seq.CURRVAL, :category_id, 'clnt', :ques_desc)";
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

        protected void btn_search_Click(object sender, EventArgs e)
        {
            // Check if question was not empty
            if ("" == txt_question_desc.Text || null == txt_question_desc.Text)
            {
                error_question_desc.Text = "Question must be entered.";
                return;
            }

            // search for question
            List<Question> faq_questions = Search(txt_question_desc.Text.ToLower());
            // Go through the list and display
            found.InnerHtml = "<h2>Your Search Results</h2>";
            if (0 < faq_questions.Count)
            {
                foreach (Question question in faq_questions)
                {
                    // If no answer substitute with placeholder text
                    string answer_out = "[No answer yet]";
                    if ("empty" != question.Answer_Description)
                    {
                        answer_out = question.Answer_Description;
                    }

                    found.InnerHtml += "<p><span class='question_found'>" + question.Question_Description + "</span><br>" +
                        "<span class='answer'>" + question.Answer_Description + "</span></p>";
                }
            }
            else {
                found.InnerHtml += "<p><span class='answer'>Nothing was found for search word '" + txt_question_desc.Text + "'</span></p>";
            }
            
        }

        // Returns all questions with answers from DB
        public List<Question> Search(string key)
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
                " FROM " + ConnectDb.username + ".t_questions q" +
                " INNER JOIN " + ConnectDb.username + ".t_answers a" +
                " ON q.answer_id = a.answer_id" +
                " INNER JOIN " + ConnectDb.username + ".t_categories c" +
                " ON q.category_id = c.category_id" +
                " WHERE q.description LIKE '%" + key + "%'";
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

        
    }
}