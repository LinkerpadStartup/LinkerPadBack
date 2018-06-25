using System;
using System.ComponentModel.DataAnnotations;

namespace LinkerPad.Common.CustomeValidationAttribute
{
    public class ValidEnumValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Type enumType = value.GetType();
            bool valid = Enum.IsDefined(enumType, value);
            return valid
                ? ValidationResult.Success
                : new ValidationResult($"{value} is not a valid value for type {enumType.Name}");
        }
    }
}