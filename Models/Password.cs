using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AssignmentAdo.Models
{
    public class Password
    {
        public int id { get; set; }
        [Required]
        
        [Display(Name ="Enter Password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Invalid password format")]
        public string pass { get; set; }
        [Required]
  
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Invalid password format")]
        [Display(Name = "Re-Enter Password")]

        public string confirmPass { get; set; }
    }
}