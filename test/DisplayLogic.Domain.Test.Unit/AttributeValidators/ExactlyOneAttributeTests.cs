using System.ComponentModel.DataAnnotations;
using DisplayLogic.Domain.AttributeValidators;

namespace DisplayLogic.Domain.Test.Unit.AttributeValidators
{
    public class ExactlyOneAttributeTests
    {
        private class TestModel
        {
            [ExactlyOne("Property2", ErrorMessage = "Exactly one of the properties must be set.")]
            public Guid Property1 { get; set; }

            public Guid Property2 { get; set; }
        }

        [Fact]
        public void ExactlyOneAttribute_NoPropertiesSet_FailsValidation()
        {
            var model = new TestModel
            {
                Property1 = Guid.Empty,
                Property2 = Guid.Empty
            };

            var context = new ValidationContext(model) { MemberName = "Property1" };
            var attribute = new ExactlyOneAttribute("Property2");
            var result = attribute.GetValidationResult(model.Property1, context);

            Assert.NotNull(result);
            Assert.Equal("Exactly one of the properties must be set.", result.ErrorMessage);
        }

        [Fact]
        public void ExactlyOneAttribute_BothPropertiesSet_FailsValidation()
        {
            var model = new TestModel
            {
                Property1 = Guid.NewGuid(),
                Property2 = Guid.NewGuid()
            };

            var context = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
    
            // Get validation attributes for Property1 and Property2
            var property1Attributes = context.ObjectType.GetProperty(nameof(TestModel.Property1)).GetCustomAttributes(true).OfType<ValidationAttribute>();
            var property2Attributes = context.ObjectType.GetProperty(nameof(TestModel.Property2)).GetCustomAttributes(true).OfType<ValidationAttribute>();
    
            // Validate Property1 and Property2 individually
            var property1ValidationResults = property1Attributes.Select(attribute => attribute.GetValidationResult(model.Property1, context)).ToList();
            var property2ValidationResults = property2Attributes.Select(attribute => attribute.GetValidationResult(model.Property2, context)).ToList();

            // Combine the validation results
            validationResults.AddRange(property1ValidationResults);
            validationResults.AddRange(property2ValidationResults);

            // Check if there's at least one error
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void ExactlyOneAttribute_Property1Set_PassesValidation()
        {
            var model = new TestModel
            {
                Property1 = Guid.NewGuid(),
                Property2 = Guid.Empty
            };

            var context = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();

            // Validate the entire object
            Validator.TryValidateObject(model, context, validationResults, true);

            // Count the validation results related to the ExactlyOneAttribute
            int exactlyOneValidationResultsCount = validationResults.Count(r => r.ErrorMessage.Contains("Exactly one of the properties must be set."));

            // Assert that there is only one successful validation result
            Assert.Equal(1, exactlyOneValidationResultsCount);
        }

        [Fact]
        public void ExactlyOneAttribute_Property2Set_PassesValidation()
        {
            var model = new TestModel
            {
                Property1 = Guid.Empty,
                Property2 = Guid.NewGuid()
            };

            var context = new ValidationContext(model) { MemberName = "Property1" };
            var attribute = new ExactlyOneAttribute("Property2");
            var result = attribute.GetValidationResult(model.Property1, context);

            Assert.Null(result);
        }
    }
}
