using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_C_Sharp.Models
{
    public class Category
    {
        // Fields
        private int _category_id;
        private string _category_description;

        // Properties
        public int Category_ID {
            get { return this._category_id; }
            set { this._category_id = value; }
        }

        public string Category_Desc
        {
            get { return this._category_description; }
            set { this._category_description = value; }
        }
    }
}