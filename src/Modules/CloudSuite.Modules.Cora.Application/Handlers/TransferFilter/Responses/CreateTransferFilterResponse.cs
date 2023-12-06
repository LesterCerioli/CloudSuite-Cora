using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Responses
{
    public class CreateTransferFilterResponse : Response
    {
        public Guid RequestId {  get; private set; }

        public CreateTransferFilterResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;

            foreach(var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateTransferFilterResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            this.AddError(falhaValidacao);
        }
    }
}
