using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Payments.PayemntScheduling.Responses
{
	public class CreatePaymentSchedullingResponse : Response
	{
        public Guid RequestId { get; private set; }

        public CreatePaymentSchedullingResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }
        public CreatePaymentSchedullingResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            this.AddError(falseValidation   );
        }
    }
}
