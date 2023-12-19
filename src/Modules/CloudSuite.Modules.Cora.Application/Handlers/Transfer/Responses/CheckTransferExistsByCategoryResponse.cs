using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;


namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses
{
    public class CheckTransferExistsByCategoryResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }

        public CheckTransferExistsByCategoryResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckTransferExistsByCategoryResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}
