using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class UrlImageAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string strngified = value as string;
            if (strngified.StartsWith("http://") || strngified.StartsWith("https://"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The link shoule start with http://  or https:// ");

        }
    }
}
