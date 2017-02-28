using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace L3.Models
{
    public class PeopleIndexVM
    {
        [Display(Name="First name")]
        public string Name { get; set; }

        [Display(Name="E-mail")]
        public string Email { get; set; }

        public bool ShowAsHighLighted { get; set; }
    }
}
