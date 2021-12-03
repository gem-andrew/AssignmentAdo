using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AssignmentAdo.Models
{
    public class ForegtPassword
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Enetr Your Email")]
        public string email { get; set; }
        [Display(Name = "Enter New Password")]
        public string pass { get; set; }
        [Required]
        [Display(Name = "Re-Enter New Password")]
        public string confirmPass { get; set; }

    }
}