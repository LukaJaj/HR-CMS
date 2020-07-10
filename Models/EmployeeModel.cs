using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HrProject.Models
{
    public class EmployeeModel
    {
        [Key]
        [Required]
        [Display(Name = "Private Id")]
        [DataType(DataType.Text)]
        public string PrivateId { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Sex")]
        [DataType(DataType.Text)]
        public string Sex { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Status")]
        public string Status { get; set; }


        [Display(Name = "Date of fire")]
        [DataType(DataType.Date)]
        [AllowNull]
        public DateTime? DateOfFire { get; set; }



    }
}
