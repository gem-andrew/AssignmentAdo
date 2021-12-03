using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AssignmentAdo.Models
{
    public class Login
    {
        
        [Required]
        [Display(Name ="E-mail")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string pass { get; set; }

    }
}