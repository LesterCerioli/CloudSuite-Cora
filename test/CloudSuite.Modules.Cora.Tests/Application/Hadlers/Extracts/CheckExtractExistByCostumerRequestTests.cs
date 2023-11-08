namespace CloudSuite.Modules.Cora.Tests.Application.Hadlers.Extracts
{
    public class CheckExtractExistByCostumerRequestTests
    {
        [Fact]
        public void Constructor_WithCustomer_ShouldInitializeProperties()
        {
            // Arrange
            Customer customer = new Customer("John Doe", "john@example.com");

            // Act
            CheckExtractExistByCostumerRequest request = new CheckExtractExistByCostumerRequest(customer);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id);
            Assert.Equal(customer, request.Customer);

        }

        [Fact]
        public void DefaultConstructor_ShouldInitializeIdAndCustomer()
        {
            // Act
            CheckExtractExistByCostumerRequest request = new CheckExtractExistByCostumerRequest();

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id);
            Assert.Null(request.Customer);
        }
    }
}