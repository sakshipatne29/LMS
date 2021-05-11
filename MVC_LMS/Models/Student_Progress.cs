using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_LMS.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Student_Progress
    {
        [Required]
        [Key]
        [RegularExpression("[0-9]+")]
        [Display(Name ="User ID")]
        public int UserID { get; set; }
        
        [Required]
        [Key]
        [RegularExpression("[0-9]+")]
        [Display(Name ="Course ID")]
        public int CourseID { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string UserName { get; set; }

        [Display(Name ="Progress Status")]
        [RegularExpression("[0-9]+")]
        [Range(0, 100, ErrorMessage = "Mark Correct Progress")]
        public int Prog_status { get; set; }
        
        [Display(Name = "Test Score")]
        public Nullable<double> Test_scores { get; set; }
        
        [Display(Name ="Certificate Status")]
        public string Certi_status { get; set; }

        public virtual Cours Cours { get; set; }
        public virtual User_Details User_Details { get; set; }
    }
}