using CloudSuite.Modules.Cora.Application.Handlers.Account.Requests;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Cora.Tests.Application.Hadlers.Accounts
{
    public class CheckExistsAccountByAccountNumberRequestTests
    {
        [Fact]
        public void Constructor_WithAccountNumber_ShouldInitializeProperties()
        {
            // Arrange
            string accountNumber = "12345";

            // Act
            CheckExistsAccountByAccountNumberRequest request = new CheckExistsAccountByAccountNumberRequest(accountNumber);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id);
            Assert.Equal(accountNumber, request.AccountNumber);
        }

        [Fact]
        public void DefaultConstructor_ShouldInitializeIdAndAccountNumber()
        {
            // Act
            CheckExistsAccountByAccountNumberRequest request = new CheckExistsAccountByAccountNumberRequest();

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id);
            Assert.Null(request.AccountNumber);
        }
    }
}