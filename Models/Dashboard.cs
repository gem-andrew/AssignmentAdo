using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AssignmentAdo.Models
{
    public class Dashboard
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime dateOfBirth { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

    }
}