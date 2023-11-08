namespace CloudSuite.Modules.Cora.Tests.Application.Hadlers.Accounts
{
    public class CheckExistsAccountByAccountNumberHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ShouldReturnTrueResponse()
        {
             // Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();
            var mockLogger = new Mock<ILogger<CheckExistsAccountByAccountNumberHandler>>();
            var request = new CheckExistsAccountByAccountNumberRequest
            {
                AccountNumber = "12345"
            };

            var validationResult = new ValidationResult();
            var handler = new CheckExistsAccountByAccountNumberHandler(mockAccountRepository.Object, mockLogger.Object);

            mockAccountRepository.Setup(repo => repo.GetByAccountNumber(It.IsAny<string>()))
                .ReturnsAsync(new AccountEntity());

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsType<CheckExistsAccountByAccountNumberResponse>(response);
            Assert.True(response.Exists);
            Assert.Equal(request.Id, response.RequestId);
            Assert.Same(validationResult, response.ValidationResult);

        }

        [Fact]
        public async Task Handle_InvalidRequest_ShouldReturnFalseResponse()
        {
            // Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();
            var mockLogger = new Mock<ILogger<CheckExistsAccountByAccountNumberHandler>>();
            var request = new CheckExistsAccountByAccountNumberRequest
            {
                AccountNumber = "12345"
            };

            var validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("AccountNumber", "Account not found"));
            var handler = new CheckExistsAccountByAccountNumberHandler(mockAccountRepository.Object, mockLogger.Object);

            mockAccountRepository.Setup(repo => repo.GetByAccountNumber(It.IsAny<string>()))
                .ReturnsAsync((AccountEntity)null);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsType<CheckExistsAccountByAccountNumberResponse>(response);
            Assert.False(response.Exists);
            Assert.Equal(request.Id, response.RequestId);
            Assert.Same(validationResult, response.ValidationResult);

        }

        public async Task Handle_ExceptionThrown_ShouldReturnErrorResponse()
        {
            // Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();
            var mockLogger = new Mock<ILogger<CheckExistsAccountByAccountNumberHandler>>();
            var request = new CheckExistsAccountByAccountNumberRequest
            {
                AccountNumber = "12345"
            };

            var handler = new CheckExistsAccountByAccountNumberHandler(mockAccountRepository.Object, mockLogger.Object);

            mockAccountRepository.Setup(repo => repo.GetByAccountNumber(It.IsAny<string>()))
                .ThrowsAsync(new Exception("Simulated error"));

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsType<CheckExistsAccountByAccountNumberResponse>(response);
            Assert.False(response.Exists);
            Assert.Equal(request.Id, response.RequestId);
            Assert.NotNull(response.ErrorMessage);
        }
    }
}