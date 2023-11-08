using CloudSuite.Modules.Cora.Application.Handlers.Extrato;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace CloudSuite.Modules.Cora.Tests.Application.Hadlers.Extracts
{
    public class CreateExtractHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var loggerMock = new Mock<ILogger<CreateExtractHandler>>();

            var command = new CreateExtractCommand(/* initialize with valid data */);
            var handler = new CreateExtractHandler(extractRepositoryMock.Object, loggerMock.Object);

            // Mock the behavior of the repository methods
            extractRepositoryMock.Setup(repo => repo.GetByStartDate(It.IsAny<DateTime>()))
                .ReturnsAsync((Extract)null);
            extractRepositoryMock.Setup(repo => repo.GetByEndDate(It.IsAny<DateTime>()))
                .ReturnsAsync((Extract)null);
            extractRepositoryMock.Setup(repo => repo.GetByCustomer(It.IsAny<string>()))
                .ReturnsAsync((Extract)null);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            // Add your assertions here to check the result
            Assert.NotNull(result);
            // Ensure it's a success response
            Assert.True(result.IsValid);

        }

        
        [Fact]
        public async Task Handle_InvalidCommand_ReturnsErrorResponse()
        {
            // Arrange
            var extractRepositoryMock = new Mock<IExtractRepository>();
            var loggerMock = new Mock<ILogger<CreateExtractHandler>>();

            var command = new CreateExtractCommand(/* initialize with invalid data */);
            var handler = new CreateExtractHandler(extractRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            // Add your assertions here to check the result
            Assert.NotNull(result);
            // Ensure it's an error response
            Assert.False(result.IsValid);
        }

    }
}