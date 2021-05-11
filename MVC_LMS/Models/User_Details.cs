using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_LMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class User_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_Details()
        {
            this.Student_Progress = new HashSet<Student_Progress>();
        }
        [Required]
        [Key]
        [RegularExpression("[0-9]+")]
        [Display(Name = "User ID")]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z]+", ErrorMessage ="Only alphabets are allowed.")]
        [StringLength(20, ErrorMessage = "Min length should be 2 & Max length should be 20", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [RegularExpression("^[a-zA-Z]*", ErrorMessage = "Only alphabets are allowed.")]
        [StringLength(20)]
        public string MiddleName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+", ErrorMessage = "Only alphabets are allowed.")]
        [StringLength(20, ErrorMessage = "Min length should be 2 & Max length should be 20", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9]+[@][a-zA-Z0-9]+[.][a-z]+", ErrorMessage = "Email Id is not Valid")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contact No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Number")]
        public string ContactNo { get; set; }

        [Required]
        [RegularExpression("[MmFf]", ErrorMessage = "Enter only M/F or m/f")]
        [StringLength(1, ErrorMessage = "Enter only M/F or m/f")]
        public string Gender { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [Required]
        [RegularExpression("^Admin|^Student", ErrorMessage = "Only Student/Admin allowed")]
        [StringLength(7, ErrorMessage = "Only Student/Admin allowed", MinimumLength = 5)]
        public string Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Progress> Student_Progress { get; set; }
    }
}
