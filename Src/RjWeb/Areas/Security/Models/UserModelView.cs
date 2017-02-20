using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RjWeb.Areas.Security.Models
{
    public class UserModelView
    {
        public Guid Id { get; set; }
        [Required]
        [MinLength(5,ErrorMessage="KULANG!")]
        [MaxLength(10, ErrorMessage= "SOBRA!")]
        public string Name{ get; set; }

        [Required, Display(Name= "Age")]
        public int? Age { get; set; }
        //public string Birthday { get; set; }
        public string Gender { get; set; }

    }
}