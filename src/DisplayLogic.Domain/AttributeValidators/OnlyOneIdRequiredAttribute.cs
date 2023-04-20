using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.AttributeValidators;

public class ExactlyOneAttribute : ValidationAttribute
{
    private readonly string[] _propertyNames;

    public ExactlyOneAttribute(params string[] propertyNames)
    {
        _propertyNames = propertyNames;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var nonEmptyPropertyCount = 0;

        foreach (var propertyName in _propertyNames)
        {
            var property = validationContext.ObjectType.GetProperty(propertyName);

            if (property == null)
            {
                return new ValidationResult($"Unknown property: {propertyName}");
            }

            if (property.GetValue(validationContext.ObjectInstance) is Guid propertyValue && propertyValue != Guid.Empty)
            {
                nonEmptyPropertyCount++;
            }
        }

        if (nonEmptyPropertyCount != 1)
        {
            return new ValidationResult("Exactly one of the properties must be set.");
        }

        return ValidationResult.Success!;
    }
}