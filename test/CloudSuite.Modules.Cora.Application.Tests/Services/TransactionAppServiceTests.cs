using AutoMapper;
using CloudSuite.Modules.Cora.Application.Handlers.Transactions;
using CloudSuite.Modules.Cora.Application.ViewModels;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Moq;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Cora.Application.Tests.Services
{
    public class TransactionAppServiceTests
    {
        [Theory]
        [InlineData(22.12, "08-10-2019", "fiz um pagamento", "Rick riordan", "784365872", "67873647834")]
        [InlineData(36.12, "10-12-2023", "estava devendo", "Groover Rails", "83478347", "9387498345")]
        [InlineData(87.34, "04-02-2023", "fiz uma transferencia", "Annabeth Smith", "6354762546", "937624873624")]
        public async Task GetByCounterPartyName_ShouldReturnsCompanyViewModel(decimal entryAmount, DateTimeOffset entryCreatedAt, string entryTransactionDescription, string entryTransactionCounterPartyName, string transactiOnorder, string entryTransactionCounterPartyIdentity)
        {
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transactionAppService = new TransactionAppService(
                transactionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var transactionEntity = new Transaction(entryAmount, entryCreatedAt, entryTransactionDescription, entryTransactionCounterPartyName, transactiOnorder, entryTransactionCounterPartyIdentity);
            transactionRepositoryMock.Setup(repo => repo.GetByCounterPartyName(entryTransactionCounterPartyName)).ReturnsAsync(transactionEntity);

            var expectedViewModel = new TransactionViewModel()
            {
               //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransactionViewModel>(transactionEntity)).Returns(expectedViewModel);

            // Act
            var result = await transactionAppService.GetByCounterPartyName(entryTransactionCounterPartyName);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("Percy Jackson")]
        [InlineData("Annabeth Smith")]
        [InlineData("John Doe")]
        public async Task GetByCounterPartyName_ShouldHandleNullRepositoryResult(string counterPartyName)
        {
            // Arrange
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transactionAppService = new TransactionAppService(
                transactionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transactionRepositoryMock.Setup(repo => repo.GetByCounterPartyName(It.IsAny<string>()))
                .ReturnsAsync((Transaction)null); // Simulate null result from the repository

            // Act
            var result = await transactionAppService.GetByCounterPartyName(counterPartyName);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Anderson Silva")]
        [InlineData("João Santos")]
        [InlineData("Lucas Silva")]
        public async Task GetByCounterPartyName_ShouldHandleInvalidMappingResult(string counterPartyName)
        {
            // Arrange
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transactionAppService = new TransactionAppService(
                transactionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transactionRepositoryMock.Setup(repo => repo.GetByCounterPartyName(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transactionAppService.GetByCounterPartyName(counterPartyName));
        }

        [Theory]
        [InlineData(22.12, "08-10-2019", "fiz um pagamento", "Rick riordan", "784365872", "67873647834")]
        [InlineData(36.12, "10-12-2023", "estava devendo", "Groover Rails", "83478347", "9387498345")]
        [InlineData(87.34, "04-02-2023", "fiz uma transferencia", "Annabeth Smith", "6354762546", "937624873624")]
        public async Task GetByTransactionOrder_ShouldReturnsCompanyViewModel(decimal entryAmount, DateTimeOffset entryCreatedAt, string entryTransactionDescription, string entryTransactionCounterPartyName, string transactiOnorder, string entryTransactionCounterPartyIdentity)
        {
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transactionAppService = new TransactionAppService(
                transactionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var transactionEntity = new Transaction(entryAmount, entryCreatedAt, entryTransactionDescription, entryTransactionCounterPartyName, transactiOnorder, entryTransactionCounterPartyIdentity);
            transactionRepositoryMock.Setup(repo => repo.GetByTransactionOrder(transactiOnorder)).ReturnsAsync(transactionEntity);

            var expectedViewModel = new TransactionViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransactionViewModel>(transactionEntity)).Returns(expectedViewModel);

            // Act
            var result = await transactionAppService.GetByTransactionOrder(transactiOnorder);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("Percy Jackson")]
        [InlineData("Annabeth Smith")]
        [InlineData("John Doe")]
        public async Task GetByTransactionOrder_ShouldHandleNullRepositoryResult(string transactionOrder)
        {
            // Arrange
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transactionAppService = new TransactionAppService(
                transactionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transactionRepositoryMock.Setup(repo => repo.GetByTransactionOrder(It.IsAny<string>()))
                .ReturnsAsync((Transaction)null); // Simulate null result from the repository

            // Act
            var result = await transactionAppService.GetByTransactionOrder(transactionOrder);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Anderson Silva")]
        [InlineData("João Santos")]
        [InlineData("Lucas Silva")]
        public async Task GetByTransactionOrder_ShouldHandleInvalidMappingResult(string transactionOrder)
        {
            // Arrange
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transactionAppService = new TransactionAppService(
                transactionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transactionRepositoryMock.Setup(repo => repo.GetByTransactionOrder(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transactionAppService.GetByTransactionOrder(transactionOrder));
        }

        [Theory]
        [InlineData(22.12, "08-10-2019", "fiz um pagamento", "Rick riordan", "784365872", "67873647834")]
        [InlineData(36.12, "10-12-2023", "estava devendo", "Groover Rails", "83478347", "9387498345")]
        [InlineData(87.34, "04-02-2023", "fiz uma transferencia", "Annabeth Smith", "6354762546", "937624873624")]
        public async Task Save_ShouldAddCompanyToRepository(decimal entryAmount, DateTimeOffset entryCreatedAt, string entryTransactionDescription, string entryTransactionCounterPartyName, string transactiOnorder, string entryTransactionCounterPartyIdentity)
        {
            // Arrange
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transactionAppService = new TransactionAppService(
                transactionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createTransactionCommand = new CreateTransactionCommand()
            {
                EntryAmount = entryAmount,
                EntryCreatedAt = entryCreatedAt,
                EntryTransactionDescription = entryTransactionDescription,
                EntryTransactionCounterPartyName = entryTransactionCounterPartyName,
                TransactiOnorder = transactiOnorder,
                EntryTransactionCounterPartyIdentity = entryTransactionCounterPartyIdentity
            };

            // Act
            await transactionAppService.Save(createTransactionCommand);

            // Assert
            transactionRepositoryMock.Verify(repo => repo.Add(It.IsAny<Transaction>()), Times.Once);
        }

        [Theory]
        [InlineData(22.12, "08-10-2019", "fiz um pagamento", "Rick riordan", "784365872", "67873647834")]
        [InlineData(36.12, "10-12-2023", "estava devendo", "Groover Rails", "83478347", "9387498345")]
        [InlineData(87.34, "04-02-2023", "fiz uma transferencia", "Annabeth Smith", "6354762546", "937624873624")]
        public async Task Save_ShouldHandleNullRepositoryResult(decimal entryAmount, DateTimeOffset entryCreatedAt, string entryTransactionDescription, string entryTransactionCounterPartyName, string transactiOnorder, string entryTransactionCounterPartyIdentity)

        {
            //Arrange
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transactionAppService = new TransactionAppService(
                transactionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createTransactionCommand = new CreateTransactionCommand()
            {
                EntryAmount = entryAmount,
                EntryCreatedAt = entryCreatedAt,
                EntryTransactionDescription = entryTransactionDescription,
                EntryTransactionCounterPartyName = entryTransactionCounterPartyName,
                TransactiOnorder = transactiOnorder,
                EntryTransactionCounterPartyIdentity = entryTransactionCounterPartyIdentity
            };

            transactionRepositoryMock.Setup(repo => repo.Add(It.IsAny<Transaction>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => transactionAppService.Save(createTransactionCommand));

        }

        [Theory]
        [InlineData(22.12, "08-10-2019", "fiz um pagamento", "Rick riordan", "784365872", "67873647834")]
        [InlineData(36.12, "10-12-2023", "estava devendo", "Groover Rails", "83478347", "9387498345")]
        [InlineData(87.34, "04-02-2023", "fiz uma transferencia", "Annabeth Smith", "6354762546", "937624873624")]
        public async Task Save_ShouldHandleInvalidMappingResult(decimal entryAmount, DateTimeOffset entryCreatedAt, string entryTransactionDescription, string entryTransactionCounterPartyName, string transactiOnorder, string entryTransactionCounterPartyIdentity)

        {

            //Arrange
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transactionAppService = new TransactionAppService(
                transactionRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createTransactionCommand = new CreateTransactionCommand()
            {
                EntryAmount = entryAmount,
                EntryCreatedAt = entryCreatedAt,
                EntryTransactionDescription = entryTransactionDescription,
                EntryTransactionCounterPartyName = entryTransactionCounterPartyName,
                TransactiOnorder = transactiOnorder,
                EntryTransactionCounterPartyIdentity = entryTransactionCounterPartyIdentity
            };

            // Act       
            transactionRepositoryMock.Setup(repo => repo.Add(It.IsAny<Transaction>())).Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transactionAppService.Save(createTransactionCommand));
        }

    }
}
