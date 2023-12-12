using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Customer.Responses;
using MediatR;
using CustomerEntity = CloudSuite.Modules.Cora.Domain.Models.Payments.Customer;

namespace CloudSuite.Modules.Cora.Application.Handlers.Customer
{
	public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
	{
		public Guid Id { get; private set; }
		public string? Cnpj { get; set; }
		public string? SocialReason { get; set; }
		public string? ResponsibeContact { get; set; }
		public string? TelephoneNumber { get; set; }
		public string? TelephoneRegion { get; set;}

		public CreateCustomerCommand()
		{
			Id  = Guid.NewGuid();
		}

		public CustomerEntity GetEntity()
		{
			return new CustomerEntity(
				new Cnpj(Cnpj),
				SocialReason,
				ResponsibeContact,
				new Telephone(TelephoneNumber, TelephoneRegion)
				);
		}
	}
}
