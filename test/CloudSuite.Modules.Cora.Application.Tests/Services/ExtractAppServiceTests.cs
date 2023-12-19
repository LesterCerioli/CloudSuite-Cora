using AutoMapper;
using CloudSuite.Modules.Cora.Application.Handlers.Extract;
using CloudSuite.Modules.Cora.Application.Services.Implementations;
using CloudSuite.Modules.Cora.Application.ViewModels;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Moq;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Cora.Application.Tests.Services
{
    public class ExtractAppServiceTests
    {
        [Theory]
        [InlineData(22.12, 569.43, "08-10-2019", 43.92, "10-12-2023", "2763982933431" ,"Hermione Granger", 234.1, 123.134)]
        [InlineData(36.12, 344.234, "10-12-2023", 8392.123, "10-12-2023", "394738943903" ,"Rony Wesley", 65.12, 34.145)]
        [InlineData(87.34, 1.35, "04-02-2023", 65.23, "08-10-2019", "8736248732093" ,"Harry Potter", 76.23, 95.21)]
        public async Task GetByStartDate_ShouldReturnsCompanyViewModel(decimal entryAmount, decimal endBalance, DateTimeOffset endDate, decimal startBalance, DateTimeOffset startDate, string headerBusinessDocument, string headerBusinessName, decimal aggregationsCreditTotal, decimal aggregationsDebitTotal)
        {
            var accountRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new ExtractAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var extractEntity = new Extract(entryAmount, endBalance, endDate, startBalance, startDate, headerBusinessDocument, headerBusinessName);
            accountRepositoryMock.Setup(repo => repo.GetByStartDate(startDate)).ReturnsAsync(extractEntity);

            var expectedViewModel = new ExtractViewModel()
            {
                Id = extractEntity.Id,
                StartDate = startDate,
                EndDate = endDate,
                EntryAmount = entryAmount,
                AggregationsCreditTotal = aggregationsCreditTotal,
                AggregationsDebitTotal = aggregationsDebitTotal
            };

            mapperMock.Setup(mapper => mapper.Map<ExtractViewModel>(extractEntity)).Returns(expectedViewModel);

            // Act
            var result = await accountAppService.GetByStartDate(startDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("08-10-2023")]
        [InlineData("09-11-2023")]
        [InlineData("10-12-2023")]
        public async Task GetByStartDate_ShouldHandleNullRepositoryResult(DateTimeOffset startDate)
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var extractAppService = new ExtractAppService(
                extractRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            extractRepositoryMock.Setup(repo => repo.GetByStartDate(It.IsAny<DateTimeOffset>()))
                .ReturnsAsync((Extract)null); // Simulate null result from the repository

            // Act
            var result = await extractAppService.GetByStartDate(startDate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("01-03-2022")]
        [InlineData("03-08-2018")]
        [InlineData("10-12-2023")]
        public async Task GetByStartDate_ShouldHandleInvalidMappingResult(DateTimeOffset startDate)
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var extractAppService = new ExtractAppService(
                extractRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            extractRepositoryMock.Setup(repo => repo.GetByStartDate(It.IsAny<DateTimeOffset>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => extractAppService.GetByStartDate(startDate));
        }

        [Theory]
        [InlineData(22.12, 569.43, "04-02-2023", 43.92, "10-12-2023", "2763982933431", "Hermione Granger", 234.1, 123.134)]
        [InlineData(36.12, 344.234, "09-11-2023", 8392.123, "10-12-2023", "394738943903", "Rony Wesley", 65.12, 34.145)]
        [InlineData(87.34, 1.35, "08-10-2023", 65.23, "08-10-2019", "8736248732093", "Harry Potter", 76.23, 95.21)]
        public async Task GetByEndDate_ShouldReturnsCompanyViewModel(decimal entryAmount, decimal endBalance, DateTimeOffset endDate, decimal startBalance, DateTimeOffset startDate, string headerBusinessDocument, string headerBusinessName, decimal aggregationsCreditTotal, decimal aggregationsDebitTotal)
        {
            var accountRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new ExtractAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var extractEntity = new Extract(entryAmount, endBalance, endDate, startBalance, startDate, headerBusinessDocument, headerBusinessName);
            accountRepositoryMock.Setup(repo => repo.GetByEndDate(endDate)).ReturnsAsync(extractEntity);

            var expectedViewModel = new ExtractViewModel()
            {
                Id = extractEntity.Id,
                StartDate = startDate,
                EndDate = endDate,
                EntryAmount = entryAmount,
                AggregationsCreditTotal = aggregationsCreditTotal,
                AggregationsDebitTotal = aggregationsDebitTotal
            };

            mapperMock.Setup(mapper => mapper.Map<ExtractViewModel>(extractEntity)).Returns(expectedViewModel);

            // Act
            var result = await accountAppService.GetByEndDate(endDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("10-01-2023")]
        [InlineData("10-12-2023")]
        [InlineData("08-10-2019")]
        public async Task GetByEndDate_ShouldHandleNullRepositoryResult(DateTimeOffset endDate)
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var extractAppService = new ExtractAppService(
                extractRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            extractRepositoryMock.Setup(repo => repo.GetByEndDate(It.IsAny<DateTimeOffset>()))
                .ReturnsAsync((Extract)null); // Simulate null result from the repository

            // Act
            var result = await extractAppService.GetByEndDate(endDate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("09-11-2021")]
        [InlineData("08-10-2019")]
        [InlineData("07-09-2018")]
        public async Task GetByEndDate_ShouldHandleInvalidMappingResult(DateTimeOffset endDate)
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var extractAppService = new ExtractAppService(
                extractRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            extractRepositoryMock.Setup(repo => repo.GetByEndDate(It.IsAny<DateTimeOffset>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => extractAppService.GetByEndDate(endDate));
        }

        [Theory]
        [InlineData(22.12, 569.43, "04-02-2023", 43.92, "10-12-2023", "2763982933431", "Hermione Granger", 234.1, 123.134)]
        [InlineData(36.12, 344.234, "09-11-2023", 8392.123, "10-12-2023", "394738943903", "Rony Wesley", 65.12, 34.145)]
        [InlineData(87.34, 1.35, "08-10-2023", 65.23, "08-10-2019", "8736248732093", "Harry Potter", 76.23, 95.21)]
        public async Task GetByEntryAmount_ShouldReturnsCompanyViewModel(decimal entryAmount, decimal endBalance, DateTimeOffset endDate, decimal startBalance, DateTimeOffset startDate, string headerBusinessDocument, string headerBusinessName, decimal aggregationsCreditTotal, decimal aggregationsDebitTotal)
        {
            var accountRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var accountAppService = new ExtractAppService(
                accountRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var extractEntity = new Extract(entryAmount, endBalance, endDate, startBalance, startDate, headerBusinessDocument, headerBusinessName);
            accountRepositoryMock.Setup(repo => repo.GetByEntryAmount(entryAmount)).ReturnsAsync(extractEntity);

            var expectedViewModel = new ExtractViewModel()
            {
                Id = extractEntity.Id,
                StartDate = startDate,
                EndDate = endDate,
                EntryAmount = entryAmount,
                AggregationsCreditTotal = aggregationsCreditTotal,
                AggregationsDebitTotal = aggregationsDebitTotal
            };

            mapperMock.Setup(mapper => mapper.Map<ExtractViewModel>(extractEntity)).Returns(expectedViewModel);

            // Act
            var result = await accountAppService.GetByEntryAmount(entryAmount);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData(32.123)]
        [InlineData(432.12)]
        [InlineData(763284.32)]
        public async Task GetByEntryAmount_ShouldHandleNullRepositoryResult(decimal entryAmount)
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var extractAppService = new ExtractAppService(
                extractRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            extractRepositoryMock.Setup(repo => repo.GetByEntryAmount(It.IsAny<decimal>()))
                .ReturnsAsync((Extract)null); // Simulate null result from the repository

            // Act
            var result = await extractAppService.GetByEntryAmount(entryAmount);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(83.43)]
        [InlineData(78.75)]
        [InlineData(49.234)]
        public async Task GetByEntryAmount_ShouldHandleInvalidMappingResult(decimal entryAmount)
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var extractAppService = new ExtractAppService(
                extractRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            extractRepositoryMock.Setup(repo => repo.GetByEntryAmount(It.IsAny<decimal>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => extractAppService.GetByEntryAmount(entryAmount));
        }

        [Theory]
        [InlineData(22.12, 569.43, "03-08-2018", 43.92, "10 -12-2023", "2763982933431", "Hermione Granger", 234.1, 123.134)]
        [InlineData(36.12, 344.234, "10-04-2015", 8392.123, "10-12-2023", "394738943903", "Rony Wesley", 65.12, 34.145)]
        [InlineData(87.34, 1.35, "10-01-2023", 65.23, "08-10-2019", "8736248732093", "Harry Potter", 76.23, 95.21)]
        public async Task Save_ShouldAddCompanyToRepository(decimal entryAmount, decimal endBalance, DateTimeOffset endDate, decimal startBalance, DateTimeOffset startDate, string headerBusinessDocument, string headerBusinessName, decimal aggregationsCreditTotal, decimal aggregationsDebitTotal)
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var extractAppService = new ExtractAppService(
                extractRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createDASCommand = new CreateExtractCommand()
            {
                EntryAmount = entryAmount,
                EndBalance = endBalance,
                EndDate = endDate,
                StartBalance = startBalance,
                StartDate = startDate,
                HeaderBusinessDocument = headerBusinessDocument,
                HeaderBusinessName = headerBusinessName,
                AggregationsCreditTotal = aggregationsCreditTotal,
                AggregationsDebitTotal = aggregationsDebitTotal
            };

            // Act
            await extractAppService.Save(createDASCommand);

            // Assert
            extractRepositoryMock.Verify(repo => repo.Add(It.IsAny<Extract>()), Times.Once);
        }

        [Theory]
        [InlineData(22.12, 569.43, "01-03-2022", 43.92, "10-12-2023", "12312334421", "Ricardo Ohara", 234.1, 123.134)]
        [InlineData(36.12, 344.234, "03-08-2018", 21312.221, "10-12-2023", "21312323", "Wally West", 65.12, 34.145)]
        [InlineData(87.34, 1.35, "08-10-2023", 65321.2323, "08-10-2019", "9786483924", "Dean Winchester", 76.23, 95.21)]
        public async Task Save_ShouldHandleNullRepositoryResult(decimal entryAmount, decimal endBalance, DateTimeOffset endDate, decimal startBalance, DateTimeOffset startDate, string headerBusinessDocument, string headerBusinessName, decimal aggregationsCreditTotal, decimal aggregationsDebitTotal)

        {
            //Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var extractAppService = new ExtractAppService(
                extractRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createDASCommand = new CreateExtractCommand()
            {
                EntryAmount = entryAmount,
                EndBalance = endBalance,
                EndDate = endDate,
                StartBalance = startBalance,
                StartDate = startDate,
                HeaderBusinessDocument = headerBusinessDocument,
                HeaderBusinessName = headerBusinessName,
                AggregationsCreditTotal = aggregationsCreditTotal,
                AggregationsDebitTotal = aggregationsDebitTotal
            };

            extractRepositoryMock.Setup(repo => repo.Add(It.IsAny<Extract>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => extractAppService.Save(createDASCommand));

        }

        [Theory]
        [InlineData(22.12, 569.43, "08-10-2019", 43.92, "10-12-2023", "123123", "Sam Winchester", 234.1, 123.134)]
        [InlineData(36.12, 344.234, "09-11-2023", 8392.123, "10-12-2023", "394743438943903", "Percy Jackson", 65.12, 34.145)]
        [InlineData(87.34, 1.35, "10-12-2023", 65.23, "08-10-2019", "8736248732093", "Katniss Everdeen", 76.23, 95.21)]
        public async Task Save_ShouldHandleInvalidMappingResult(decimal entryAmount, decimal endBalance, DateTimeOffset endDate, decimal startBalance, DateTimeOffset startDate, string headerBusinessDocument, string headerBusinessName, decimal aggregationsCreditTotal, decimal aggregationsDebitTotal)

        {

            //Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var extractAppService = new ExtractAppService(
                extractRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createDASCommand = new CreateExtractCommand()
            {
                EntryAmount = entryAmount,
                EndBalance = endBalance,
                EndDate = endDate,
                StartBalance = startBalance,
                StartDate = startDate,
                HeaderBusinessDocument = headerBusinessDocument,
                HeaderBusinessName = headerBusinessName,
                AggregationsCreditTotal = aggregationsCreditTotal,
                AggregationsDebitTotal = aggregationsDebitTotal
            };

            // Act       
            extractRepositoryMock.Setup(repo => repo.Add(It.IsAny<Extract>()))
            .Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => extractAppService.Save(createDASCommand));
        }

    }
}
