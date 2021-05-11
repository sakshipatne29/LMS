using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_LMS.Models
{
    public partial class Cours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cours()
        {
            this.Student_Progress = new HashSet<Student_Progress>();
        }
        [Required]
        [Key]
        [RegularExpression("[0-9]+")]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage ="Only alphabets are allowed.")]
        [RegularExpression("^[a-zA-Z]+", ErrorMessage = "Only alphabets are allowed.")]
        public string Author { get; set; }

        [Required]
        [StringLength(30, ErrorMessage ="Only alphabets are allowed.")]
        [RegularExpression("^[a-zA-Z]+", ErrorMessage = "Only alphabets are allowed.")]
        public string Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Progress> Student_Progress { get; set; }
    }
}



