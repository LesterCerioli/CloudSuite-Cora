using AutoMapper;
using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter;
using CloudSuite.Modules.Cora.Application.ViewModels;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Moq;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Cora.Application.Tests.Services
{
    public class TransferFilterAppServiceTests
    {
        [Theory]
        [InlineData("03-08-2018", "10-12-2023", "2")]
        [InlineData("04-02-2023", "04-02-2023", "7")]
        [InlineData("07-09-2018", "03-08-2018", "1")]
        public async Task GetByStartDate_ShouldReturnsCompanyViewModel(DateTime startDate, DateTime endDate, string page)
        {
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var transferFilterEntity = new TransferFilter(startDate, endDate, page);
            transferFilterRepositoryMock.Setup(repo => repo.GetByStartDate(startDate)).ReturnsAsync(transferFilterEntity);

            var expectedViewModel = new TransferViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransferViewModel>(transferFilterEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferFilterAppService.GetByStartDate(startDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("08-10-2019")]
        [InlineData("03-08-2018")]
        [InlineData("09-11-2023")]
        public async Task GetByStartDate_ShouldHandleNullRepositoryResult(DateTime startDate)
        {
            // Arrange
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferFilterRepositoryMock.Setup(repo => repo.GetByStartDate(It.IsAny<DateTime>()))
                .ReturnsAsync((TransferFilter)null); // Simulate null result from the repository

            // Act
            var result = await transferFilterAppService.GetByStartDate(startDate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("04-02-2023")]
        [InlineData("08-10-2019")]
        [InlineData("10-12-2023")]
        public async Task GetByStartDate_ShouldHandleInvalidMappingResult(DateTime startDate)
        {
            // Arrange
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferFilterRepositoryMock.Setup(repo => repo.GetByStartDate(It.IsAny<DateTime>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferFilterAppService.GetByStartDate(startDate));
        }

        [Theory]
        [InlineData("03-08-2018", "10-12-2023", "2")]
        [InlineData("04-02-2023", "04-02-2023", "7")]
        [InlineData("07-09-2018", "03-08-2018", "1")]
        public async Task GetByEndDate_ShouldReturnsCompanyViewModel(DateTime startDate, DateTime endDate, string page)
        {
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var transferFilterEntity = new TransferFilter(startDate, endDate, page);
            transferFilterRepositoryMock.Setup(repo => repo.GetByEndDate(endDate)).ReturnsAsync(transferFilterEntity);

            var expectedViewModel = new TransferViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransferViewModel>(transferFilterEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferFilterAppService.GetByEndDate(endDate);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("08-10-2019")]
        [InlineData("03-08-2018")]
        [InlineData("09-11-2023")]
        public async Task GetByEndDate_ShouldHandleNullRepositoryResult(DateTime endDate)
        {
            // Arrange
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferFilterRepositoryMock.Setup(repo => repo.GetByEndDate(It.IsAny<DateTime>()))
                .ReturnsAsync((TransferFilter)null); // Simulate null result from the repository

            // Act
            var result = await transferFilterAppService.GetByEndDate(endDate);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("04-02-2023")]
        [InlineData("08-10-2019")]
        [InlineData("10-12-2023")]
        public async Task GetByEndDate_ShouldHandleInvalidMappingResult(DateTime endDate)
        {
            // Arrange
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferFilterRepositoryMock.Setup(repo => repo.GetByEndDate(It.IsAny<DateTime>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferFilterAppService.GetByEndDate(endDate));
        }

        [Theory]
        [InlineData("03-08-2018", "10-12-2023", "2")]
        [InlineData("04-02-2023", "04-02-2023", "7")]
        [InlineData("07-09-2018", "03-08-2018", "1")]
        public async Task GetByPage_ShouldReturnsCompanyViewModel(DateTime startDate, DateTime endDate, string page)
        {
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var transferFilterEntity = new TransferFilter(startDate, endDate, page);
            transferFilterRepositoryMock.Setup(repo => repo.GetByPage(page)).ReturnsAsync(transferFilterEntity);

            var expectedViewModel = new TransferViewModel()
            {
                //não tem viewmodel ainda
            };

            mapperMock.Setup(mapper => mapper.Map<TransferViewModel>(transferFilterEntity)).Returns(expectedViewModel);

            // Act
            var result = await transferFilterAppService.GetByPage(page);

            // Assert
            Assert.Equal(expectedViewModel, result);
        }

        [Theory]
        [InlineData("08-10-2019")]
        [InlineData("03-08-2018")]
        [InlineData("09-11-2023")]
        public async Task GetByPage_ShouldHandleNullRepositoryResult(string page)
        {
            // Arrange
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferFilterRepositoryMock.Setup(repo => repo.GetByPage(It.IsAny<string>()))
                .ReturnsAsync((TransferFilter)null); // Simulate null result from the repository

            // Act
            var result = await transferFilterAppService.GetByPage(page);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("04-02-2023")]
        [InlineData("08-10-2019")]
        [InlineData("10-12-2023")]
        public async Task GetByPage_ShouldHandleInvalidMappingResult(string page)
        {
            // Arrange
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            transferFilterRepositoryMock.Setup(repo => repo.GetByPage(It.IsAny<string>()))
                .ThrowsAsync(new ArgumentException("Invalid data")); // Simulate null result from the repository

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferFilterAppService.GetByPage(page));
        }

        [Theory]
        [InlineData("03-08-2018", "10-12-2023", "2")]
        [InlineData("04-02-2023", "04-02-2023", "7")]
        [InlineData("07-09-2018", "03-08-2018", "1")]
        public async Task Save_ShouldAddCompanyToRepository(DateTime startDate, DateTime endDate, string page)
        {
            // Arrange
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createTransferFilterCommand = new CreateTransferFilterCommand()
            {
                StartDate = startDate,
                EndDate = endDate,
                Page = page
            };

            // Act
            await transferFilterAppService.Save(createTransferFilterCommand);

            // Assert
            transferFilterRepositoryMock.Verify(repo => repo.Add(It.IsAny<TransferFilter>()), Times.Once);
        }

        [Theory]
        [InlineData("03-08-2018", "10-12-2023", "2")]
        [InlineData("04-02-2023", "04-02-2023", "7")]
        [InlineData("07-09-2018", "03-08-2018", "1")]
        public async Task Save_ShouldHandleNullRepositoryResult(DateTime startDate, DateTime endDate, string page)
        {
            //Arrange
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createTransferFilterCommand = new CreateTransferFilterCommand()
            {
                StartDate = startDate,
                EndDate = endDate,
                Page = page
            };

            transferFilterRepositoryMock.Setup(repo => repo.Add(It.IsAny<TransferFilter>())).Throws(new NullReferenceException());

            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => transferFilterAppService.Save(createTransferFilterCommand));

        }

        [Theory]
        [InlineData("03-08-2018", "10-12-2023", "2")]
        [InlineData("04-02-2023", "04-02-2023", "7")]
        [InlineData("07-09-2018", "03-08-2018", "1")]
        public async Task Save_ShouldHandleInvalidMappingResult(DateTime startDate, DateTime endDate, string page)
        {

            //Arrange
            var transferFilterRepositoryMock = new Mock<ITransferFilterRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var transferFilterAppService = new TransferAppService(
                transferFilterRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object
                );

            var createTransferFilterCommand = new CreateTransferFilterCommand()
            {
                StartDate = startDate,
                EndDate = endDate,
                Page = page
            };

            // Act       
            transferFilterRepositoryMock.Setup(repo => repo.Add(It.IsAny<TransferFilter>()))
            .Throws(new ArgumentException("Invalid data"));

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => transferFilterAppService.Save(createTransferFilterCommand));
        }

    }
}
