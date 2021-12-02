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
        public string pass { get; set; }
    }
}