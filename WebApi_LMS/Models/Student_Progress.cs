using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_LMS.Models
{
    public partial class Student_Progress
    {
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public string UserName { get; set; }
        public int Prog_status { get; set; }
        public Nullable<double> Test_scores { get; set; }
        public string Certi_status { get; set; }
    }
}