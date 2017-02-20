using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRjWeb.dal
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        //public String Firstname { get; set; }
        public string Name { get; set; }
        //public String Lastname { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }

        
    }
}
