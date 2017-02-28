using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using L3.Attributes;

namespace L3.Models
{
    public class Person
    {
        //[Display(Name = "First name")]
        //[Required(ErrorMessage = "Field cannot be empty..")]
        public string Name { get; set; }

        //[Display(Name="E-mail")]
        //[Required(ErrorMessage = "Field cannot be empty..")]
        //[DataType(DataType.EmailAddress)]
        //[ValidateSpecificEmail("@acme.com")]
        public string Email { get; set; }

        public int Id { get; set; }
    }
}
