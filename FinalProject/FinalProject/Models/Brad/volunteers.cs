using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bradCampbell_FinalAssignment.Models
{
    public class volunteers
    {
        private string volunteer_FirstName;
        private string volunteer_LastName;
        private string volunteer_Email;
        private string volunteer_Password;
        private string volunteer_Status;
        private int volunteer_Task;

        public string Volunteer_FirstName
        {
            get { return this.volunteer_FirstName; }
            set { this.volunteer_FirstName = value; }
        }
        public string Volunteer_LastName
        {
            get { return this.volunteer_LastName; }
            set { this.volunteer_LastName = value; }
        }
        public string Volunteer_Email
        {
            get { return this.volunteer_Email; }
            set { this.volunteer_Email = value; }
        }
        public string Volunteer_Password
        {
            get { return this.volunteer_Password; }
            set { this.volunteer_Password = value; }
        }
        public string Volunteer_Status
        {
            get { return this.volunteer_Status; }
            set { this.volunteer_Status = value; }
        }
        public int Volunteer_Task
        {
            get { return this.volunteer_Task; }
            set { this.volunteer_Task = value; }
        }
    }
}