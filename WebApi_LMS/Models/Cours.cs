using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_LMS.Models
{
    public partial class Cours
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}