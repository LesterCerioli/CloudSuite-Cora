using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Responses;
using MediatR;
using TransferFilterEntity = CloudSuite.Modules.Cora.Domain.Models.TransferFilter;


namespace CloudSuite.Modules.Cora.Application.Handlers.TransferFilter
{
	public class CreateTransferFilterCommand : IRequest<CreateTransferFilterResponse>
	{
		public Guid Id { get; private set; }
		public DateTime StartDate {  get; set; }
		public DateTime EndDate { get; set; }
		public string Page {  get; set; }

        public CreateTransferFilterCommand()
        {
            Id = Guid.NewGuid();
        }

		public TransferFilterEntity GetEntity()
		{
			return new TransferFilterEntity(
				StartDate,
				EndDate,
				Page);

        }
    }
}
