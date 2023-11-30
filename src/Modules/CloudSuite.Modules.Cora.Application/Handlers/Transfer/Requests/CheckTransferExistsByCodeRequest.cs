using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using MediatR;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests
{
	public class CheckTransferExistsByCodeRequest : IRequest<CheckTransferExistsByCodeResponse>
	{
		public Guid Id { get; private set; }
		public string Code { get; set; }

        public CheckTransferExistsByCodeRequest(string code)
        {
            Id = Guid.NewGuid();
            Code = code;
        }
    }
}
