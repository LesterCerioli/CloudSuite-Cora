using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudSuite.Modules.Cora.Application.Handlers.Account;
using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CloudSuite.Modules.Cora.Tests.Application.Hadlers.Accounts
{
    public class CreateAccountHandlerTests
    {
        
        [Fact]
        public async Task Handle_ValidCommand_ReturnsCreateAccountResponse()
        {
            // Arrange
            var command = new CreateAccountCommand(/* Initialize command with valid data */);
            var accountRepository = new Mock<IAccountRepository>();
            var logger = new Mock<ILogger<CreateAccountHandler>>();
            var validator = new Mock<IValidator<CreateAccountCommand>>();
            validator.Setup(v => v.Validate(It.IsAny<CreateAccountCommand>()))
            .Returns(new FluentValidation.Results.ValidationResult());

            var handler = new CreateAccountHandler(accountRepository.Object, logger.Object);

            // Ensure the repository methods return null (account doesn't exist)
            accountRepository.Setup(repo => repo.GetByAccountNumber(It.IsAny<string>())).ReturnsAsync((Account)null);
            accountRepository.Setup(repo => repo.GetByAccountDigit(It.IsAny<string>())).ReturnsAsync((Account)null);
            accountRepository.Setup(repo => repo.GetByBankName(It.IsAny<string>())).ReturnsAsync((Account)null);
            accountRepository.Setup(repo => repo.GetByBankCode(It.IsAny<string>())).ReturnsAsync((Account)null);

            // Act
            var response = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsType<CreateAccountResponse>(response);
            //Assert.True(response.IsValid);
        }
        
        
        [Fact]
        public async Task Handle_CommandWithExistingAccount_ReturnsCreateAccountResponseWithErrorMessage()
        {
            // Arrange
            var command = new CreateAccountCommand(/* Initialize command with existing account data */);
            var accountRepository = new Mock<IAccountRepository>();
            var logger = new Mock<ILogger<CreateAccountHandler>>();
            var validator = new Mock<IValidator<CreateAccountCommand>>();
            validator.Setup(v => v.Validate(It.IsAny<CreateAccountCommand>()))
            .Returns(new FluentValidation.Results.ValidationResult());

            var handler = new CreateAccountHandler(accountRepository.Object, logger.Object);

            // Ensure the repository methods return an existing account
            accountRepository.Setup(repo => repo.GetByAccountNumber(It.IsAny<string>())).ReturnsAsync(new Account());
            accountRepository.Setup(repo => repo.GetByAccountDigit(It.IsAny<string>())).ReturnsAsync(new Account());
            accountRepository.Setup(repo => repo.GetByBankName(It.IsAny<string>())).ReturnsAsync(new Account());
            accountRepository.Setup(repo => repo.GetByBankCode(It.IsAny<string>())).ReturnsAsync(new Account());

            // Act
            var response = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsType<CreateAccountResponse>(response);
            Assert.False(response.IsValid);
            Assert.Equal("Account already exists.", response.ErrorMessage);

        }
        
        
    }
}