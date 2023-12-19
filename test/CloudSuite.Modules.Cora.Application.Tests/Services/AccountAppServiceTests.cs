using AutoMapper;
using CloudSuite.Modules.Cora.Application.Handlers.Account;
using CloudSuite.Modules.Cora.Application.Services.Implementations;
using CloudSuite.Modules.Cora.Application.ViewModels;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Moq;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Cora.Application.Tests.Services
{
	public class AccountAppServiceTests
	{
        [Theory]
        [InlineData("8575", "8722", "9", "Itau", "55")]
        [InlineData("7283", "6745", "2", "Brasil", "22")]
        [InlineData("1342", "3242", "4", "Bradesco", "88")]
        public async Task GetByBankCode_ShouldReturnsCompanyViewModel(string agency, string accountNumber, string accountDigit, string bankName, string bankCode)
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var dasAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var accountEntity = new Account(agency, accountNumber, accountDigit, bankName, bankCode);
            accountRepositoryMock.Setup(repo => repo.GetByBankCode(bankCode)).ReturnsAsync(accountEntity);

            var expectedViewModel = new AccountViewModel()
            {
                Id = accountEntity.Id,
                BankName = bankName,
                BankCode = bankCode,
                Agency = agency,
                AccountNumber = accountNumber,
                DigitAccount = accountDigit
            };

            mapperMock.Setup(mapper => mapper.Map<AccountViewModel>(accountEntity)).Returns(expectedViewModel);

            // Act
            var result = await dasAppService.GetByBankCode(bankCode);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("65")]
        [InlineData("55")]
        public async Task GetByBankCode_ShouldHandleNullRepositoryResult(string bankCode)
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            accountRepositoryMock.Setup(repo => repo.GetByBankCode(It.IsAny<string>()))
                .ReturnsAsync((Account)null); // Simulate null result from the repository

            // Act
            var result = await accountAppService.GetByBankCode(bankCode);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("4")]
        [InlineData("78")]
        [InlineData("36")]
        public async Task GetByBankCode_ShouldHandleInvalidMappingResult(string bankCode)
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            accountRepositoryMock.Setup(repo => repo.GetByBankCode(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => accountAppService.GetByBankCode(bankCode));
        }

        [Theory]
        [InlineData("8764", "6534", "5", "Santander", "11")]
        [InlineData("2314", "2345", "7", "Nubank", "16")]
        [InlineData("5673", "7542", "1", "Inter", "53")]
        public async Task GetByAgency_ShouldReturnsCompanyViewModel(string agency, string accountNumber, string accountDigit, string bankName, string bankCode)
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var dasAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var accountEntity = new Account(agency, accountNumber, accountDigit, bankName, bankCode);
            accountRepositoryMock.Setup(repo => repo.GetByAgency(agency)).ReturnsAsync(accountEntity);

            var expectedViewModel = new AccountViewModel()
            {
                Id = accountEntity.Id,
                BankName = bankName,
                BankCode = bankCode,
                Agency = agency,
                AccountNumber = accountNumber,
                DigitAccount = accountDigit
            };

            mapperMock.Setup(mapper => mapper.Map<AccountViewModel>(accountEntity)).Returns(expectedViewModel);

            // Act
            var result = await dasAppService.GetByAgency(agency);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("6752")]
        [InlineData("2445")]
        [InlineData("4323")]
        public async Task GetByAgency_ShouldHandleNullRepositoryResult(string agency)
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            accountRepositoryMock.Setup(repo => repo.GetByBankCode(It.IsAny<string>()))
                .ReturnsAsync((Account)null); // Simulate null result from the repository

            // Act
            var result = await accountAppService.GetByAgency(agency);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("13")]
        [InlineData("45")]
        [InlineData("65")]
        public async Task GetByAgency_ShouldHandleInvalidMappingResult(string agency)
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            accountRepositoryMock.Setup(repo => repo.GetByAgency(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => accountAppService.GetByAgency(agency));
        }

        [Theory]
        [InlineData("1342", "3242", "4", "Bradesco", "88")]
        [InlineData("2314", "2345", "5", "Nubank", "16")]
        [InlineData("4363", "2136", "2", "Pan", "55")]
        public async Task GetByAccountNumber_ShouldReturnsCompanyViewModel(string agency, string accountNumber, string accountDigit, string bankName, string bankCode)
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var dasAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var accountEntity = new Account(agency, accountNumber, accountDigit, bankName, bankCode);
            accountRepositoryMock.Setup(repo => repo.GetByAccountNumber(accountNumber)).ReturnsAsync(accountEntity);

            var expectedViewModel = new AccountViewModel()
            {
                Id = accountEntity.Id,
                BankName = bankName,
                BankCode = bankCode,
                Agency = agency,
                AccountNumber = accountNumber,
                DigitAccount = accountDigit
            };

            mapperMock.Setup(mapper => mapper.Map<AccountViewModel>(accountEntity)).Returns(expectedViewModel);

            // Act
            var result = await dasAppService.GetByAccountNumber(accountNumber);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("8575")]
        [InlineData("2534")]
        [InlineData("6830")]
        public async Task GetByAccountNumber_ShouldHandleNullRepositoryResult(string accountNumber)
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            accountRepositoryMock.Setup(repo => repo.GetByBankCode(It.IsAny<string>()))
                .ReturnsAsync((Account)null); // Simulate null result from the repository

            // Act
            var result = await accountAppService.GetByAccountNumber(accountNumber);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("4")]
        [InlineData("78")]
        [InlineData("36")]
        public async Task GetByAccountNumber_ShouldHandleInvalidMappingResult(string accountNumber)
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            accountRepositoryMock.Setup(repo => repo.GetByAccountNumber(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => accountAppService.GetByAccountNumber(accountNumber));
        }

        [Theory]
        [InlineData("8764", "6534", "5", "Santander", "11")]
        [InlineData("2314", "2345", "5", "Nubank", "16")]
        [InlineData("7283", "6745", "2", "Brasil", "22")]
        public async Task GetByAccountDigit_ShouldReturnsCompanyViewModel(string agency, string accountNumber, string accountDigit, string bankName, string bankCode)
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var dasAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var accountEntity = new Account(agency, accountNumber, accountDigit, bankName, bankCode);
            accountRepositoryMock.Setup(repo => repo.GetByAccountDigit(accountDigit)).ReturnsAsync(accountEntity);

            var expectedViewModel = new AccountViewModel()
            {
                Id = accountEntity.Id,
                BankName = bankName,
                BankCode = bankCode,
                Agency = agency,
                AccountNumber = accountNumber,
                DigitAccount = accountDigit
            };

            mapperMock.Setup(mapper => mapper.Map<AccountViewModel>(accountEntity)).Returns(expectedViewModel);

            // Act
            var result = await dasAppService.GetByAccountDigit(accountDigit);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("9")]
        [InlineData("3")]
        [InlineData("1")]
        public async Task GetByAccountDigit_ShouldHandleNullRepositoryResult(string accountDigit)
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            accountRepositoryMock.Setup(repo => repo.GetByAccountDigit(It.IsAny<string>()))
                .ReturnsAsync((Account)null); // Simulate null result from the repository

            // Act
            var result = await accountAppService.GetByAccountDigit(accountDigit);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("4")]
        [InlineData("2")]
        [InlineData("7")]
        public async Task GetByAccountDigit_ShouldHandleInvalidMappingResult(string accountDigit)
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            accountRepositoryMock.Setup(repo => repo.GetByAccountDigit(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => accountAppService.GetByAccountDigit(accountDigit));
        }

        [Theory]
        [InlineData("8764", "6534", "5", "Santander", "11")]
        [InlineData("2314", "2345", "7", "Nubank", "16")]
        [InlineData("5673", "7542", "1", "Inter", "53")]
        public async Task Save_ShouldAddCompanyToRepository(string agency, string accountNumber, string accountDigit, string bankName, string bankCode)
        {
            // Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createDASCommand = new CreateAccountCommand()
            {
                AccountNumber = accountNumber,
                AccountDigit = accountDigit,
                Agency = agency,
                BankName = bankName,
                BankCode = bankCode
            };

            // Act
            await accountAppService.Save(createDASCommand);

            // Assert
            accountRepositoryMock.Verify(repo => repo.Add(It.IsAny<Account>()), Times.Once);
        }

        [Theory]
        [InlineData("8575", "8722", "6", "Unibanco", "33")]
        [InlineData("8575", "8722", "5", "Itau", "66")]
        [InlineData("8575", "8722", "4", "C6", "88")]
        public async Task Save_ShouldHandleNullRepositoryResult(string agency, string accountNumber, string accountDigit, string bankName, string bankCode)
        {
            //Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createDASCommand = new CreateAccountCommand()
            {
                AccountNumber = accountNumber,
                AccountDigit = accountDigit,
                Agency = agency,
                BankName = bankName,
                BankCode = bankCode
            };

            accountRepositoryMock.Setup(repo => repo.Add(It.IsAny<Account>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => accountAppService.Save(createDASCommand));

        }

        [Theory]
        [InlineData("5342", "5678", "3", "Santander", "11")]
        [InlineData("7543", "1234", "2", "Nubank", "16")]
        [InlineData("2355", "7543", "1", "Inter", "53")]
        public async Task Save_ShouldHandleInvalidMappingResult(string agency, string accountNumber, string accountDigit, string bankName, string bankCode)
        {

            //Arrange
            var accountRepositoryMock = new Mock<IAccountRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new AccountAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createDASCommand = new CreateAccountCommand()
            {
                AccountNumber = accountNumber,
                AccountDigit = accountDigit,
                Agency = agency,
                BankName = bankName,
                BankCode = bankCode
            };

            // Act       
            accountRepositoryMock.Setup(repo => repo.Add(It.IsAny<Account>()))
            .Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => accountAppService.Save(createDASCommand));
        }
    }
}
