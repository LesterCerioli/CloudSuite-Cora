using AutoMapper;
using CloudSuite.Modules.Cora.Application.Handlers.Transfer;
using CloudSuite.Modules.Cora.Application.ViewModels;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Moq;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Cora.Application.Tests.Services
{
    public class TransferAppServiceTests
    {
        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task GetByAmount_ShouldReturnsCompanyViewModel(string amount, string description, string code, string category, DateTimeOffset creationDate, 
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var account = new Account("8273", "16728", "9", "Itau", "55");
            var transactionEntity = new Transfer(account, amount, description, code, category, creationDate, bankCodeRecipient, branchNumberRecipient, accountNumberRecipient, scheduled, accountType, status);
            transferRepositoryMock.Setup(repo => repo.GetByAmount(amount)).ReturnsAsync(transactionEntity);

            var expectedViewModel = new TransactionViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransactionViewModel>(transactionEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferAppService.GetByAmount(amount);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("Percy Jackson")]
        [InlineData("Annabeth Smith")]
        [InlineData("John Doe")]
        public async Task GetByAmount_ShouldHandleNullRepositoryResult(string amount)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByAmount(It.IsAny<string>()))
                .ReturnsAsync((Transfer)null); // Simulate null result from the repository

            // Act
            var result = await transferAppService.GetByAmount(amount);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Anderson Silva")]
        [InlineData("João Santos")]
        [InlineData("Lucas Silva")]
        public async Task GetByAmount_ShouldHandleInvalidMappingResult(string amount)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByAmount(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferAppService.GetByAmount(amount));
        }

        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task GetByCode_ShouldReturnsCompanyViewModel(string amount, string description, string code, string category, DateTimeOffset creationDate,
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var account = new Account("8273", "16728", "9", "Itau", "55");
            var transactionEntity = new Transfer(account, amount, description, code, category, creationDate, bankCodeRecipient, branchNumberRecipient, accountNumberRecipient, scheduled, accountType, status);
            transferRepositoryMock.Setup(repo => repo.GetByCode(code)).ReturnsAsync(transactionEntity);

            var expectedViewModel = new TransactionViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransactionViewModel>(transactionEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferAppService.GetByCode(code);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("231")]
        [InlineData("843")]
        [InlineData("984")]
        public async Task GetByCode_ShouldHandleNullRepositoryResult(string code)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByCode(It.IsAny<string>()))
                .ReturnsAsync((Transfer)null); // Simulate null result from the repository

            // Act
            var result = await transferAppService.GetByCode(code);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("473")]
        [InlineData("293")]
        [InlineData("738")]
        public async Task GetByCode_ShouldHandleInvalidMappingResult(string code)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByCode(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferAppService.GetByCode(code));
        }

        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task GetByCategory_ShouldReturnsCompanyViewModel(string amount, string description, string code, string category, DateTimeOffset creationDate,
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var account = new Account("8273", "16728", "9", "Itau", "55");
            var transactionEntity = new Transfer(account, amount, description, code, category, creationDate, bankCodeRecipient, branchNumberRecipient, accountNumberRecipient, scheduled, accountType, status);
            transferRepositoryMock.Setup(repo => repo.GetByCategory(category)).ReturnsAsync(transactionEntity);

            var expectedViewModel = new TransactionViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransactionViewModel>(transactionEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferAppService.GetByCategory(category);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("category1")]
        [InlineData("category2")]
        [InlineData("category3")]
        public async Task GetByCategory_ShouldHandleNullRepositoryResult(string category)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByCategory(It.IsAny<string>()))
                .ReturnsAsync((Transfer)null); // Simulate null result from the repository

            // Act
            var result = await transferAppService.GetByCategory(category);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("category4")]
        [InlineData("category5")]
        [InlineData("category6")]
        public async Task GetByCategory_ShouldHandleInvalidMappingResult(string category)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByCode(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferAppService.GetByCode(category));
        }

        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task GetByBankCodeRecipient_ShouldReturnsCompanyViewModel(string amount, string description, string code, string category, DateTimeOffset creationDate,
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var account = new Account("8273", "16728", "9", "Itau", "55");
            var transactionEntity = new Transfer(account, amount, description, code, category, creationDate, bankCodeRecipient, branchNumberRecipient, accountNumberRecipient, scheduled, accountType, status);
            transferRepositoryMock.Setup(repo => repo.GetByBankCodeRecipient(bankCodeRecipient)).ReturnsAsync(transactionEntity);

            var expectedViewModel = new TransactionViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransactionViewModel>(transactionEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferAppService.GetByBankCodeRecipient(bankCodeRecipient);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("238")]
        [InlineData("192")]
        [InlineData("884")]
        public async Task GetByBankCodeRecipient_ShouldHandleNullRepositoryResult(string bankCode)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByBankCodeRecipient(It.IsAny<string>()))
                .ReturnsAsync((Transfer)null); // Simulate null result from the repository

            // Act
            var result = await transferAppService.GetByBankCodeRecipient(bankCode);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("983")]
        [InlineData("673")]
        [InlineData("563")]
        public async Task GetByBankCodeRecipient_ShouldHandleInvalidMappingResult(string bankCode)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByBankCodeRecipient(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferAppService.GetByBankCodeRecipient(bankCode));
        }

        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task GetByBranchNumberRecipient_ShouldReturnsCompanyViewModel(string amount, string description, string code, string category, DateTimeOffset creationDate,
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var account = new Account("8273", "16728", "9", "Itau", "55");
            var transactionEntity = new Transfer(account, amount, description, code, category, creationDate, bankCodeRecipient, branchNumberRecipient, accountNumberRecipient, scheduled, accountType, status);
            transferRepositoryMock.Setup(repo => repo.GetByBranchNumberRecipient(branchNumberRecipient)).ReturnsAsync(transactionEntity);

            var expectedViewModel = new TransactionViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransactionViewModel>(transactionEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferAppService.GetByBranchNumberRecipient(branchNumberRecipient);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("238")]
        [InlineData("192")]
        [InlineData("884")]
        public async Task GetByBranchNumberRecipient_ShouldHandleNullRepositoryResult(string branchNumber)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByBranchNumberRecipient(It.IsAny<string>()))
                .ReturnsAsync((Transfer)null); // Simulate null result from the repository

            // Act
            var result = await transferAppService.GetByBranchNumberRecipient(branchNumber);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("983")]
        [InlineData("673")]
        [InlineData("563")]
        public async Task GetByBranchNumberRecipient_ShouldHandleInvalidMappingResult(string branchNumber)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByBranchNumberRecipient(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferAppService.GetByBranchNumberRecipient(branchNumber));
        }

        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task GetByScheduled_ShouldReturnsCompanyViewModel(string amount, string description, string code, string category, DateTimeOffset creationDate,
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var account = new Account("8273", "16728", "9", "Itau", "55");
            var transactionEntity = new Transfer(account, amount, description, code, category, creationDate, bankCodeRecipient, branchNumberRecipient, accountNumberRecipient, scheduled, accountType, status);
            transferRepositoryMock.Setup(repo => repo.GetByScheduled(scheduled)).ReturnsAsync(transactionEntity);

            var expectedViewModel = new TransactionViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransactionViewModel>(transactionEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferAppService.GetByScheduled(scheduled);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("238")]
        [InlineData("192")]
        [InlineData("884")]
        public async Task GetByScheduled_ShouldHandleNullRepositoryResult(DateTimeOffset scheduled)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByScheduled(It.IsAny<DateTimeOffset>()))
                .ReturnsAsync((Transfer)null); // Simulate null result from the repository

            // Act
            var result = await transferAppService.GetByScheduled(scheduled);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("983")]
        [InlineData("673")]
        [InlineData("563")]
        public async Task GetByScheduled_ShouldHandleInvalidMappingResult(DateTimeOffset scheduled)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByScheduled(It.IsAny<DateTimeOffset>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferAppService.GetByScheduled(scheduled));
        }

        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task GetByStatus_ShouldReturnsCompanyViewModel(string amount, string description, string code, string category, DateTimeOffset creationDate,
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var account = new Account("8273", "16728", "9", "Itau", "55");
            var transactionEntity = new Transfer(account, amount, description, code, category, creationDate, bankCodeRecipient, branchNumberRecipient, accountNumberRecipient, scheduled, accountType, status);
            transferRepositoryMock.Setup(repo => repo.GetByStatus(status)).ReturnsAsync(transactionEntity);

            var expectedViewModel = new TransactionViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransactionViewModel>(transactionEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferAppService.GetByStatus(status);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("238")]
        [InlineData("192")]
        [InlineData("884")]
        public async Task GetByStatus_ShouldHandleNullRepositoryResult(string status)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByStatus(It.IsAny<string>()))
                .ReturnsAsync((Transfer)null); // Simulate null result from the repository

            // Act
            var result = await transferAppService.GetByStatus(status);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("983")]
        [InlineData("673")]
        [InlineData("563")]
        public async Task GetByStatus_ShouldHandleInvalidMappingResult(string status)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferRepositoryMock.Setup(repo => repo.GetByStatus(It.IsAny<string>())).ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferAppService.GetByStatus(status));
        }

        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task Save_ShouldAddCompanyToRepository(string amount, string description, string code, string category, DateTimeOffset creationDate,
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {
            // Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createTransferCommand = new CreateTransferCommand()
            {
                AgencyAccount = "7382",
                AccountNumberAccount = "2930",
                AccountDigitAccount = "6",
                BankNameAccount = "Itau",
                BankCodeAccount = "28",
                Amount = amount,
                Description = description,
                Code = code,
                Category = category,
                CreationDate = creationDate,
                BankCodeRecipient = bankCodeRecipient,
                BranchNumberRecipient = branchNumberRecipient,
                AccountNumberRecipient = accountNumberRecipient,
                Scheduled = scheduled,
                AccountType = accountType,
                Status = status

            };

            // Act
            await transferAppService.Save(createTransferCommand);

            // Assert
            transferRepositoryMock.Verify(repo => repo.Add(It.IsAny<Transfer>()), Times.Once);
        }

        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task Save_ShouldHandleNullRepositoryResult(string amount, string description, string code, string category, DateTimeOffset creationDate,
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {
            //Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createTransferCommand = new CreateTransferCommand()
            {
                AgencyAccount = "7382",
                AccountNumberAccount = "2930",
                AccountDigitAccount = "6",
                BankNameAccount = "Itau",
                BankCodeAccount = "28",
                Amount = amount,
                Description = description,
                Code = code,
                Category = category,
                CreationDate = creationDate,
                BankCodeRecipient = bankCodeRecipient,
                BranchNumberRecipient = branchNumberRecipient,
                AccountNumberRecipient = accountNumberRecipient,
                Scheduled = scheduled,
                AccountType = accountType,
                Status = status

            };

            transferRepositoryMock.Setup(repo => repo.Add(It.IsAny<Transfer>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => transferAppService.Save(createTransferCommand));

        }

        [Theory]
        [InlineData("23234", "description1", "273", "pix", "08-10-2019", "23", "376", "3425", "08-10-2019", "2", "status1")]
        [InlineData("76452", "description2", "283", "Doc", "10-12-2023", "765", "231", "2345", "10-12-2023", "3", "status2")]
        [InlineData("28374", "description3", "923", "Ted", "04-02-2023", "1", "736", "1231", "04-02-2023", "1", "status3")]
        public async Task Save_ShouldHandleInvalidMappingResult(string amount, string description, string code, string category, DateTimeOffset creationDate,
            string bankCodeRecipient, string branchNumberRecipient, string accountNumberRecipient, DateTimeOffset scheduled, string? accountType, string? status)
        {

            //Arrange
            var transferRepositoryMock = new Mock<ITransferRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferAppService = new TransferAppService(
                transferRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createTransferCommand = new CreateTransferCommand()
            {
                AgencyAccount = "7382",
                AccountNumberAccount = "2930",
                AccountDigitAccount = "6",
                BankNameAccount = "Itau",
                BankCodeAccount = "28",
                Amount = amount,
                Description = description,
                Code = code,
                Category = category,
                CreationDate = creationDate,
                BankCodeRecipient = bankCodeRecipient,
                BranchNumberRecipient = branchNumberRecipient,
                AccountNumberRecipient = accountNumberRecipient,
                Scheduled = scheduled,
                AccountType = accountType,
                Status = status

            };

            // Act       
            transferRepositoryMock.Setup(repo => repo.Add(It.IsAny<Transfer>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferAppService.Save(createTransferCommand));
        }

    }
}
