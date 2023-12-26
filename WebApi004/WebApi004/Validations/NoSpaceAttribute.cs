using System.ComponentModel.DataAnnotations;

namespace WebApi004.Validations
{
    public class NoSpaceAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value?.ToString()?.Contains(" ")==true)
            {
                return new ValidationResult("该字符串不允许包含空格");
            }
            return ValidationResult.Success;
        }

    }
}
