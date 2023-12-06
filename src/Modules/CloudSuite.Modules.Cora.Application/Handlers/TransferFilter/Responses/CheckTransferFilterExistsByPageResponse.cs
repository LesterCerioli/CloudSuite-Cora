using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Responses
{
	public class CheckTransferFilterExistsByPageResponse : Response
	{
		public Guid RequestId {  get; private set; }
		public bool Exists {  get; set; }

        public CheckTransferFilterExistsByPageResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors) {
                this.AddError(item.ErrorCode);
            }
        }

        public CheckTransferFilterExistsByPageResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}
