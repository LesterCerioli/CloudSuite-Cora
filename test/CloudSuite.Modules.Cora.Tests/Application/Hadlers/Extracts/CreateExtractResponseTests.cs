namespace CloudSuite.Modules.Cora.Tests.Application.Hadlers.Extracts
{
    public class CreateExtractResponseTests
    {
        [Fact]
        public void CreateExtractResponse_WithValidationResult_ShouldInitializeCorrectly()
        {
            // Arrange
            Guid requestId = Guid.NewGuid();
            ValidationResult validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("PropertyName", "Error message 1"));
            validationResult.Errors.Add(new ValidationFailure("AnotherProperty", "Error message 2"));

            // Act
            CreateExtractResponse response = new CreateExtractResponse(requestId, validationResult);

            // Assert
            Assert.Equal(requestId, response.RequestId);
            Assert.Contains("Error message 1", response.Errors);
            Assert.Contains("Error message 2", response.Errors);
        }

        [Fact]
        public void CreateExtractResponse_WithStringFalseValidation_ShouldInitializeCorrectly()
        {
            // Arrange
            Guid requestId = Guid.NewGuid();
            string falseValidation = "False validation error message";

            // Act
            CreateExtractResponse response = new CreateExtractResponse(requestId, falseValidation);

            // Assert
            Assert.Equal(requestId, response.RequestId);
            Assert.Contains(falseValidation, response.Errors);
        }
        
    }
}