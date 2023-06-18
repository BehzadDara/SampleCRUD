using System.ComponentModel.DataAnnotations;

namespace Test.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotNullOrEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(value as string))
            {
                return new ValidationResult("The value cannot be null or empty.");
            }
            
            return ValidationResult.Success;
        }
    }
}
