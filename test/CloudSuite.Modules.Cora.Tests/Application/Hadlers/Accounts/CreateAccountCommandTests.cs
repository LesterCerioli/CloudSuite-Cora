using CloudSuite.Modules.Cora.Application.Handlers.Account;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Cora.Tests.Application.Hadlers.Accounts
{
    public class CreateAccountCommandTests
    {
        
        [Fact]
        public void GetEntity_ShouldCreateAccountEntityWithProperties()
        {
            // Arrange
            var command = new CreateAccountCommand
            {
                Agency = "1234",
                AccountNumber = "567890",
                AccountDigit = "1",
                BankName = "Test Bank",
                BankCode = "TB123"
            };

            // Act
            var accountEntity = command.GetEntity();

            // Assert
            Assert.Equal(command.AccountNumber, accountEntity.AccountNumber);
            Assert.Equal(command.AccountDigit, accountEntity.AccountDigit);
            Assert.Equal(command.Agency, accountEntity.Agency);
            Assert.Equal(command.BankName, accountEntity.BankName);
            Assert.Equal(command.BankCode, accountEntity.BankCode);

        }

        [Fact]
        public void GetEntity_ShouldCreateAccountEntityWithNullProperties()
        {
            // Arrange
            var command = new CreateAccountCommand();

            // Act
            var accountEntity = command.GetEntity();

            // Assert
            Assert.Null(accountEntity.AccountNumber);
            Assert.Null(accountEntity.AccountDigit);
            Assert.Null(accountEntity.Agency);
            Assert.Null(accountEntity.BankName);
            Assert.Null(accountEntity.BankCode);
        }
    }
}