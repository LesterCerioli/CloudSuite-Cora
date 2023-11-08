using CloudSuite.Modules.Cora.Application.Handlers.Extract;
using CloudSuite.Modules.Cora.Application.Handlers.Extract.Request;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace CloudSuite.Modules.Cora.Tests.Application.Hadlers.Extracts
{
    public class CheckExtractExistByCostumerHandlerTests
    {
        [Fact]
        public async Task Handle_ExistingCustomer_ReturnsSuccessResponse()
        {
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var loggerMock = new Mock<ILogger<CheckExtractExistByCostumerHandler>>();

            var request = new CheckExtractExistByCostumerRequest(/* initialize with valid data */);
            var handler = new CheckExtractExistByCostumerHandler(extractRepositoryMock.Object, loggerMock.Object);

            // Mock the behavior of the repository method
            extractRepositoryMock.Setup(repo => repo.GetByCustomer(It.IsAny<string>()))
                .ReturnsAsync(new Extract(/* initialize with data */));

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            // Add your assertions here to check the result
            Assert.NotNull(result);
            Assert.True(result.Exists);

        }

        [Fact]
        public async Task Handle_NonExistingCustomer_ReturnsFailureResponse()
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var loggerMock = new Mock<ILogger<CheckExtractExistByCostumerHandler>>();

            var request = new CheckExtractExistByCostumerRequest(/* initialize with valid data */);
            var handler = new CheckExtractExistByCostumerHandler(extractRepositoryMock.Object, loggerMock.Object);

            // Mock the behavior of the repository method
            extractRepositoryMock.Setup(repo => repo.GetByCustomer(It.IsAny<string>()))
                .ReturnsAsync((Extract)null);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            // Add your assertions here to check the result
            Assert.NotNull(result);
            Assert.False(result.Exists);


        }

        
        [Fact]
        public async Task Handle_InvalidRequest_ReturnsFailureResponse()
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var loggerMock = new Mock<ILogger<CheckExtractExistByCostumerHandler>>();

            var request = new CheckExtractExistByCostumerRequest(/* initialize with invalid data */);
            var handler = new CheckExtractExistByCostumerHandler(extractRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            // Add your assertions here to check the result
            Assert.NotNull(result);
            Assert.False(result.Exists);

        }
    }
}