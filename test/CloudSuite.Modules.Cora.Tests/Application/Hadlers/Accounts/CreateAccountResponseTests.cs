using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using FluentValidation.Results;
using System;
using Xunit;

namespace CloudSuite.Modules.Cora.Tests.Application.Hadlers.Accounts
{
    public class CreateAccountResponseTests
    {
        [Fact]
        public void Constructor_WithValidationResult_ShouldInitializeProperties()
        {
            // Arrange
            Guid requestId = Guid.NewGuid();
            ValidationResult validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("PropertyName", "Error message 1"));
            validationResult.Errors.Add(new ValidationFailure("AnotherProperty", "Error message 2"));

            // Act
            CreateAccountResponse response = new CreateAccountResponse(requestId, validationResult);

            // Assert
            Assert.Equal(requestId, response.RequestId);
            Assert.Contains("Error message 1", response.Errors);
            Assert.Contains("Error message 2", response.Errors);
        }

        [Fact]
        public void Constructor_WithStringFalhaValidacao_ShouldInitializeProperties()
        {
            // Arrange
            Guid requestId = Guid.NewGuid();
            string falhaValidacao = "Validation failed";

            // Act
            CreateAccountResponse response = new CreateAccountResponse(requestId, falhaValidacao);

            // Assert
            Assert.Equal(requestId, response.RequestId);
            Assert.Contains(falhaValidacao, response.Errors);
        }
    }
}