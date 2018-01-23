using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_C_Sharp.Models
{
    public class Question
    {
        // Fields
        private int     _question_id;
        private string   _question_description;
        private string  _owner;
        private string  _l_name;
        private string  _f_name;
        private string  _created;
        private string  _modified;
        private int     _answer_id;
        private string  _answer_description;
        private int     _category_id;
        private string  _category_description;


        // Properties
        public int Question_ID {
            set { this._question_id = value; }
            get { return this._question_id; }
        }

        public int Answer_ID
        {
            set { this._answer_id = value; }
            get { return this._answer_id; }
        }

        public int Category_ID
        {
            set { this._category_id = value; }
            get { return this._category_id; }
        }

        public string Question_Description
        {
            set { this._question_description = value; }
            get { return this._question_description; }
        }

        public string Answer_Description
        {
            set { this._answer_description = value; }
            get { return this._answer_description; }
        }

        public string Category_Description
        {
            set { this._category_description = value; }
            get { return this._category_description; }
        }

        public string Owner
        {
            set { this._owner = value; }
            get { return this._owner; }
        }

        public string Created
        {
            set { this._created = value; }
            get { return this._created; }
        }

        public string Modified
        {
            set { this._modified = value; }
            get { return this._modified; }
        }

        public string F_Name
        {
            set { this._f_name = value; }
            get { return this._f_name; }
        }

        public string L_Name
        {
            set { this._l_name = value; }
            get { return this._l_name; }
        }
    }
}