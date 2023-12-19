using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses
{
	public class CreateTransferResponse : Response
	{
		public Guid RequestId { get; private set; }

        public CreateTransferResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach(var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateTransferResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            this.AddError(falhaValidacao);
        }
    }
}
