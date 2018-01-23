using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.Models;

namespace FinalProject.Andy
{
    public partial class survey : System.Web.UI.Page
    {
        private const int questionTextBoxWidth = 600;
        private const string questionTextBoxPostfit = "tb_question";
        private const string questionCheckBoxPostfit = "cb_question";
        private const string questionDivPostfit = "div_question";
        private const string surveysTable = "surveys";
        private const string surveysTableQuestionIdColumn = "question_id";
        private const string surveysTableQuestionTextColumn = "question_text";
        private const string surveysTableQuestionYesColumn = "question_answer_yes";
        private const string surveysTableQuestionNoColumn = "question_answer_no";
        private const string surveysTableQuestionNotSureColumn = "question_answer_not_sure";
        private const string surveysTableQuestionAdminIdColumn = "question_admin_id";
        private const string personsTable = "persons";
        private const string userLoginErrorMsg = "Wrong passward";
        private const string duplicateErrorMsg = "Value is duplicated";
        private const string userSurveyErrorMsg = "All questions should be answered";
        private const string noResultMsg = "No result to display";
        private const string adminFlag = "admin";
        private const string userFlag = "user";
        private Label[] lblErrorMsgArray;
        private Label[] lblInfoMsgArray;
        private Label[] lblQuestionIdArray;
        private Label[] lblResultArray;
        private Label[] lblQuestionIdUserArray;
        private Label[] lblQuestionTextUserArray;
        private LinkButton[] lbtnQuestionDeleteArray;
        private LinkButton[] lbtnQuestionUpdateArray;
        private LinkButton[] lbtnQuestionSubmitArray;
        private LinkButton[] lbtnQuestionCancleArray;
        private LinkButton[] lbtnQuestionCreateArray;
        private TextBox[] tbQuestionTextArray;
        private Control[] divArray;
        private Control[] divQuestionArray;
        private Control[] divQuestionUserArray;
        private CheckBox[,] questionSurveyResult;

        private FunctionHelper helper;

        protected void Page_Load(object sender, EventArgs e)
        {
            helper = new FunctionHelper(lbl_db_error_msg_);

            lblErrorMsgArray = new Label[]
            {
                lbl_db_error_msg_,
                lbl_admin_login_error_msg_,
                lbl_admin_error_msg_,                
                lbl_user_error_msg_
            };

            lblInfoMsgArray = new Label[]
            {
                lbl_admin_info_msg_,
                lbl_user_info_msg_
            };

            lblResultArray = new Label[]
            {
                lbl_result_0_,
                lbl_result_1_,
                lbl_result_2_,
                lbl_result_3_,
                lbl_result_4_
            };

            divArray = new Control[]
            {
                div_admin_,
                div_user_
            };

            divQuestionArray = new Control[]
            {
                div_question_0_,
                div_question_1_,
                div_question_2_,
                div_question_3_,
                div_question_4_
            };

            lblQuestionIdArray = new Label[]
            {
                lbl_question_0_id_,
                lbl_question_1_id_,
                lbl_question_2_id_,
                lbl_question_3_id_,
                lbl_question_4_id_
            };

            tbQuestionTextArray = new TextBox[]
            {
                tb_question_0_text_,
                tb_question_1_text_,
                tb_question_2_text_,
                tb_question_3_text_,
                tb_question_4_text_
            };

            lbtnQuestionDeleteArray = new LinkButton[]
            {
                lbtn_question_0_delete_,
                lbtn_question_1_delete_,
                lbtn_question_2_delete_,
                lbtn_question_3_delete_,
                lbtn_question_4_delete_
            };

            lbtnQuestionUpdateArray = new LinkButton[]
            {
                lbtn_question_0_update_,
                lbtn_question_1_update_,
                lbtn_question_2_update_,
                lbtn_question_3_update_,
                lbtn_question_4_update_
            };

            lbtnQuestionSubmitArray = new LinkButton[]
            {
                lbtn_question_0_sbumit_,
                lbtn_question_1_sbumit_,
                lbtn_question_2_sbumit_,
                lbtn_question_3_sbumit_,
                lbtn_question_4_sbumit_
            };

            lbtnQuestionCancleArray = new LinkButton[]
            {
                lbtn_question_0_cancle_,
                lbtn_question_1_cancle_,
                lbtn_question_2_cancle_,
                lbtn_question_3_cancle_,
                lbtn_question_4_cancle_
            };

            lbtnQuestionCreateArray = new LinkButton[]
            {
                lbtn_question_0_create_,
                lbtn_question_1_create_,
                lbtn_question_2_create_,
                lbtn_question_3_create_,
                lbtn_question_4_create_
            };

            questionSurveyResult = new CheckBox[5, 3]
            {
                {ckbx_question_0_yes_user_, ckbx_question_0_no_user_, ckbx_question_0_not_sure_user_},
                {ckbx_question_1_yes_user_, ckbx_question_1_no_user_, ckbx_question_1_not_sure_user_},
                {ckbx_question_2_yes_user_, ckbx_question_2_no_user_, ckbx_question_2_not_sure_user_},
                {ckbx_question_3_yes_user_, ckbx_question_3_no_user_, ckbx_question_3_not_sure_user_},
                {ckbx_question_4_yes_user_, ckbx_question_4_no_user_, ckbx_question_4_not_sure_user_}
            };

            divQuestionUserArray = new Control[]
            {
                div_question_0_user_,
                div_question_1_user_,
                div_question_2_user_,
                div_question_3_user_,
                div_question_4_user_
            };

            lblQuestionIdUserArray = new Label[]
            {
                lbl_question_0_id_user_,
                lbl_question_1_id_user_,
                lbl_question_2_id_user_,
                lbl_question_3_id_user_,
                lbl_question_4_id_user_
            };

            lblQuestionTextUserArray = new Label[]
            {
                lbl_question_0_text_user_,
                lbl_question_1_text_user_,
                lbl_question_2_text_user_,
                lbl_question_3_text_user_,
                lbl_question_4_text_user_
            };

            clearMsg();
        }

        protected void lbtn_admin_click(object sender, EventArgs e)
        {
            div_admin_pw_.Visible = true;
            div_user_.Visible = false;
            div_admin_.Visible = false;
        }

        protected void lbtn_admin_login_click(object sender, EventArgs e)
        {
            string adminPW;
            string userInputPW = tb_admin_pw_.Text;

            Dictionary<string, string> whereCause = new Dictionary<string, string>();
            whereCause.Add("person_id", "73");
            List<string[]> adminInfo = helper.getColumnsValueByWhereClause(personsTable, whereCause);

            if (adminInfo.Count > 0)
            {
                adminPW = adminInfo[0][4];
                if (userInputPW.Equals(adminPW))
                {
                    div_admin_pw_.Visible = false;
                    div_user_.Visible = false;
                    div_modify_questions_.Visible = false;
                    div_check_result_.Visible = false;
                    div_admin_.Visible = true;
                }
                else
                {
                    lbl_admin_login_error_msg_.Text = userLoginErrorMsg;
                }
            }
        }

        protected void lbtn_admin_logout_click(object sender, EventArgs e)
        {
            div_admin_.Visible = false;
            div_admin_pw_.Visible = true;
        }

        protected void lbtn_admin_modify_question_click(object sender, EventArgs e)
        {
            displayModifyQuestionsUI();
            div_modify_questions_.Visible = true;
            div_check_result_.Visible = false;
        }

        protected void lbtn_admin_check_result_click(object sender, EventArgs e)
        {
            div_modify_questions_.Visible = false;
            div_check_result_.Visible = true;
            foreach (var i in lblResultArray)
            {
                i.Text = "";
            }

            List<string[]> resultList = helper.getAllColumnsValueFromATable(surveysTable);

            if (resultList.Count < 1)
            {
                lblResultArray[0].Text = noResultMsg;
            } else
            {

                for (int i = 0; i < resultList.Count; i ++)
                {
                    lblResultArray[i].Text =
                        resultList[i][1] + "   " +
                        "-Yes(" + resultList[i][2] + ")" + "   " +
                        "-No(" + resultList[i][3] + ")" + "   " +
                        "-Not Sure(" + resultList[i][4] + ")";
                }
            }
        }

        protected void lbtn_admin_create_new_question_click(object sender, EventArgs e)
        {
            lbtn_admin_create_new_question_.Visible = false;
            lbtn_admin_cancle_new_question_.Visible = true;

            List<string[]> questionIdList = helper.getColumnValue(surveysTableQuestionIdColumn, surveysTable);
            int nextQuestionDivCount = questionIdList.Count;
            divQuestionArray[nextQuestionDivCount].Visible = true;

            int nextQuestionId = -1;
            bool uniqueIdFlag;
            for (int i = 0; i < 5; i ++)
            {
                uniqueIdFlag = true;
                
                foreach (var j in questionIdList)
                {
                    if (i.ToString().Equals(j[0]))
                    {
                        uniqueIdFlag = false;
                    }
                }

                if (uniqueIdFlag)
                {
                    nextQuestionId = i;
                    break;
                }
            }

            foreach (var i in lbtnQuestionDeleteArray)
            {
                i.Enabled = false;
            }

            foreach (var i in lbtnQuestionUpdateArray)
            {
                i.Enabled = false;
            }

            lblQuestionIdArray[nextQuestionDivCount].Text = nextQuestionId.ToString();
            lbtnQuestionDeleteArray[nextQuestionDivCount].Visible = false;
            lbtnQuestionUpdateArray[nextQuestionDivCount].Visible = false;
            lbtnQuestionCreateArray[nextQuestionDivCount].Visible = true;
            tbQuestionTextArray[nextQuestionDivCount].Text = "";
            tbQuestionTextArray[nextQuestionDivCount].ReadOnly = false;
            tbQuestionTextArray[nextQuestionDivCount].BackColor = System.Drawing.Color.White;

        }

        protected void lbtn_admin_cancle_new_question_click(object sender, EventArgs e)
        {
            lbtn_admin_cancle_new_question_.Visible = false;
            lbtn_admin_cancle_new_question_.Visible = true;

            List<string[]> questionIdList = helper.getColumnValue(surveysTableQuestionIdColumn, surveysTable);
            int nextQuestionDivCount = questionIdList.Count;
            divQuestionArray[nextQuestionDivCount].Visible = false;
            lbtnQuestionDeleteArray[nextQuestionDivCount].Visible = true;
            lbtnQuestionUpdateArray[nextQuestionDivCount].Visible = true;
            lbtnQuestionCreateArray[nextQuestionDivCount].Visible = false;
        }

        protected void lbtn_question_create_click(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            int htmlId = getHtmlIdFromLinkButton(linkButton);
            string dbId = getDbIdFromLinkButton(linkButton);
            string userInputQuestion = tbQuestionTextArray[htmlId].Text;

            if (!helper.nullValueCheck(userInputQuestion, lbl_admin_error_msg_))
            {
                int duplicateCheckCount = helper.dbDuplicateValueCheck(surveysTableQuestionTextColumn,
                    surveysTable, userInputQuestion);

                if (duplicateCheckCount == 0)
                {
                    Dictionary<string, string> item = new Dictionary<string, string>();
                    item.Add(surveysTableQuestionIdColumn, dbId);
                    item.Add(surveysTableQuestionTextColumn, userInputQuestion);
                    item.Add(surveysTableQuestionYesColumn, "0");
                    item.Add(surveysTableQuestionNoColumn, "0");
                    item.Add(surveysTableQuestionNotSureColumn, "0");
                    item.Add(surveysTableQuestionAdminIdColumn, "73");

                    helper.insertOneItem(surveysTable, item);

                    displayModifyQuestionsUI();
                } else
                {
                    lbl_admin_error_msg_.Text = duplicateErrorMsg;
                }
            }
        }

        protected void lbtn_admin_question_delete_click(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            string dbId = getDbIdFromLinkButton(linkButton);

            Dictionary<string, string> whereClause = new Dictionary<string, string>();
            whereClause.Add(surveysTableQuestionIdColumn, dbId);

            helper.deleteOneItem(surveysTable, whereClause);

            displayModifyQuestionsUI();
        }
        
        protected void lbtn_question_update_click(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            int htmlId = getHtmlIdFromLinkButton(linkButton);
            uiChangeForQuestionUpdateButton(htmlId);
        }

        protected void lbtn_question_sbumit_click(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            int htmlId = getHtmlIdFromLinkButton(linkButton);
            string dbId = getDbIdFromLinkButton(linkButton);
            string userInputQuestion = tbQuestionTextArray[htmlId].Text;
            
            if (!helper.nullValueCheck(userInputQuestion, lbl_admin_error_msg_))
            {
                int duplicateCheckCount = helper.dbDuplicateValueCheck(surveysTableQuestionTextColumn,
                    surveysTable, userInputQuestion);
                if (duplicateCheckCount == 0)
                {
                    Dictionary<string, string> item = new Dictionary<string, string>();
                    item.Add(surveysTableQuestionTextColumn, userInputQuestion);

                    Dictionary<string, string> whereClause = new Dictionary<string, string>();
                    whereClause.Add(surveysTableQuestionIdColumn, dbId);

                    helper.updateOneItem(surveysTable, item, whereClause);

                    displayModifyQuestionsUI();
                } else
                {
                    lbl_admin_error_msg_.Text = duplicateErrorMsg;
                }                
            }
        }

        protected void lbtn_question_cancle_click(object sender, EventArgs e)
        {
            displayModifyQuestionsUI();
        }

        protected void lbtn_user_click(object sender, EventArgs e)
        {
            div_admin_pw_.Visible = false;
            div_admin_.Visible = false;
            displaySurveyQuestionUI();
        }
        
        protected void lbtn_user_submit_click(object sender, EventArgs e)
        {
            List<string[]> questionList = helper.getAllColumnsValueFromATable(surveysTable);
            int questionCount = questionList.Count;

            if (userAnswerValueCheck(questionCount))
            {

                string dbId;
                List<string[]> currentValue;                
                int newValue;


                for (int i = 0; i < questionCount; i ++)
                {
                    for (int j = 0; j < 3; j ++)
                    {
                        if (questionSurveyResult[i, j].Checked)
                        {
                            Dictionary<string, string> item = new Dictionary<string, string>();
                            
                            dbId = getDbIdFromCheckBox(questionSurveyResult[i, j]);

                            Dictionary<string, string> whereClause = new Dictionary<string, string>();
                            whereClause.Add(surveysTableQuestionIdColumn, dbId);

                            currentValue = helper.getColumnsValueByWhereClause(surveysTable, whereClause);

                            switch (questionSurveyResult[i, j].Text)
                            {
                                case "Yes":
                                    newValue = Convert.ToInt32(currentValue[0][2]) + 1;
                                    item.Add(surveysTableQuestionYesColumn, newValue.ToString());
                                    helper.updateOneItem(surveysTable, item, whereClause);
                                    break;
                                case "No":
                                    newValue = Convert.ToInt32(currentValue[0][3]) + 1;
                                    item.Add(surveysTableQuestionNoColumn, newValue.ToString());
                                    helper.updateOneItem(surveysTable, item, whereClause);
                                    break;
                                case "Not Sure":
                                    newValue = Convert.ToInt32(currentValue[0][4]) + 1;
                                    item.Add(surveysTableQuestionNotSureColumn, newValue.ToString());
                                    helper.updateOneItem(surveysTable, item, whereClause);
                                    break;
                            }

                            break;
                        }
                    }
                }
                displaySurveyQuestionUI();
            } else
            {
                lbl_user_error_msg_.Text = userSurveyErrorMsg;
                //lbl_user_error_msg_.Visible = true;
            }
        }
        
        protected void ckbx_checked_changed(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            int htmlId = getHtmlIdFromCheckBox(checkBox);

            if (checkBox.Checked)
            {
                for (int i = 0; i < 3; i ++)
                {
                    questionSurveyResult[htmlId, i].Checked = false;
                }

                checkBox.Checked = true;
            }
        }

        private void displayModifyQuestionsUI()
        {
            List<string[]> questionList = helper.getAllColumnsValueFromATable(surveysTable);            
            int questionCount = questionList.Count;

            for (int i = 0; i < questionCount; i ++)
            {
                lblQuestionIdArray[i].Text = questionList[i][0];
                tbQuestionTextArray[i].Text = questionList[i][1];
            }

            initQuestionUI();
            initQuestionDiv(questionCount, adminFlag);
            initCreateNewQuestionButton(questionCount);
        }

        private void displaySurveyQuestionUI()
        {
            List<string[]> questionList = helper.getAllColumnsValueFromATable(surveysTable);            
            int questionCount = questionList.Count;

            for (int i = 0; i < questionCount; i ++)
            {
                lblQuestionIdUserArray[i].Text = questionList[i][0];
                lblQuestionTextUserArray[i].Text = questionList[i][1];
                
                for (int j = 0; j < 3; j ++)
                {
                    questionSurveyResult[i, j].Checked = false;
                }                                    
            }

            lbl_user_error_msg_.Text = "";

            initQuestionDiv(questionCount, userFlag);

            div_user_.Visible = true;
        }

        private bool userAnswerValueCheck(int questionCount)
        {
            bool tempResult;

            for (int i = 0; i < questionCount; i ++)
            {
                tempResult = false;
                
                for (int j = 0; j < 3; j ++)
                {
                    tempResult = tempResult || questionSurveyResult[i, j].Checked;
                }

                if (!tempResult)
                {
                    return false;
                }
            }

            return true;
        }

        private int getHtmlIdFromLinkButton(LinkButton linkButton)
        {
            int htmlId = Convert.ToInt32(linkButton.ID[14]) - 48;
            return htmlId;
        }

        private string getDbIdFromLinkButton(LinkButton linkButton)
        {
            int htmlID = getHtmlIdFromLinkButton(linkButton);
            string dbId = lblQuestionIdArray[htmlID].Text;

            return dbId;
        }

        private int getHtmlIdFromCheckBox(CheckBox checkBox)
        {
            int htmlId = Convert.ToInt32(checkBox.ID[14]) - 48;
            return htmlId;
        }

        private string getDbIdFromCheckBox(CheckBox checkBox)
        {
            int htmlId = getHtmlIdFromCheckBox(checkBox);
            string dbId = lblQuestionIdUserArray[htmlId].Text;

            return dbId;
        }

        private void uiChangeForQuestionUpdateButton(int htmlId)
        {
            initQuestionUI();

            tbQuestionTextArray[htmlId].BackColor = System.Drawing.Color.White;
            tbQuestionTextArray[htmlId].ReadOnly = false;
            lbtnQuestionUpdateArray[htmlId].Visible = false;
            lbtnQuestionSubmitArray[htmlId].Visible = true;
            lbtnQuestionCancleArray[htmlId].Visible = true;
        }

        private void initQuestionUI()
        {
            initQuestionTextBox();
            initQuestionDeleteButton();
            initQuestionUpdateButton();
            initQuestionSubmitButton();
            initQuestionCancalButton();
            initQuestionCreateButton();
            lbtn_admin_create_new_question_.Visible = true;
            lbtn_admin_cancle_new_question_.Visible = false;
        }

        private void initQuestionDeleteButton()
        {
            for (int i = 0; i < lbtnQuestionDeleteArray.Length; i ++)
            {
                lbtnQuestionDeleteArray[i].Visible = true;
                lbtnQuestionDeleteArray[i].Enabled = true;
            }
        }

        private void initQuestionUpdateButton()
        {
            for (int i = 0; i < lbtnQuestionUpdateArray.Length; i ++)
            {
                lbtnQuestionUpdateArray[i].Visible = true;
                lbtnQuestionUpdateArray[i].Enabled = true;
            }           
        }

        private void initQuestionSubmitButton()
        {
            for (int i = 0; i < lbtnQuestionSubmitArray.Length; i ++)
            {
                lbtnQuestionSubmitArray[i].Visible = false;
            }
        }

        private void initQuestionCancalButton()
        {
            for (int i = 0; i < lbtnQuestionCancleArray.Length; i ++)
            {
                lbtnQuestionCancleArray[i].Visible = false;
            }
        }

        private void initQuestionCreateButton()
        {
            for (int i = 0; i < lbtnQuestionCreateArray.Length; i ++)
            {
                lbtnQuestionCreateArray[i].Visible = false;
            }
        }

        private void initQuestionTextBox()
        {
            for (int i = 0; i < tbQuestionTextArray.Length; i ++)
            {
                tbQuestionTextArray[i].BackColor = System.Drawing.Color.LightGray;
                tbQuestionTextArray[i].ReadOnly = true;

            }
        }

        private void initQuestionDiv(int displayCount, string flag)
        {
            Control[] divArray;

            if (flag.Equals(adminFlag))
            {
                divArray = divQuestionArray;
            } else
            {
                divArray = divQuestionUserArray;
            }
            
            for (int i = 0; i < divArray.Length; i ++)
            {
                divArray[i].Visible = false;
            }

            for (int i = 0; i < displayCount; i ++)
            {
                divArray[i].Visible = true; 
            }
        }

        private void initCreateNewQuestionButton(int displayCount)
        {
            if (displayCount > 4)
            {
                lbtn_admin_create_new_question_.Enabled = false;
            } else
            {
                lbtn_admin_create_new_question_.Enabled = true;
            }
        }

        private void clearMsg()
        {
            for (int i = 0; i < lblErrorMsgArray.Length; i ++)
            {
                lblErrorMsgArray[i].Text = "";
            }

            for (int i = 0; i < lblInfoMsgArray.Length; i ++)
            {
                lblInfoMsgArray[i].Text = "";
            }
        }

        protected void test(object sender, EventArgs e)
        {            
            Response.Write("xxxxxxxxx");
        }
    }
}