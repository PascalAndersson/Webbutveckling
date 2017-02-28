using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace L3.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateSpecificEmailAttribute: ValidationAttribute
    {
        string acmeEmail;

        public ValidateSpecificEmailAttribute(string acmeEmail)
        {
            this.acmeEmail = acmeEmail;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            return value.ToString().EndsWith(acmeEmail);
        }
    }
}
