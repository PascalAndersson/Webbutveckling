using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using L3.Attributes;

namespace L3.Models
{
    public class PeopleCreateVM
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Field cannot be blank")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Field cannot be blank")]
        [EmailAddress()]
        [ValidateSpecificEmail("@acme.com")]
        public string Email { get; set; }

        [Display(Name = "I Accept Terms & Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Must be checked")]
        public bool AcceptTerms { get; set; }
    }
}
