using CloudSuite.Modules.Cora.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Payments.Boletos.Responses
{
	public class CreateBoletoResponse : Response
	{
		public Guid RequestId { get; private set; }

		public CreateBoletoResponse(Guid requestId, ValidationResult result)
		{
			RequestId = requestId;
			foreach (var item in result.Errors)
			{
				this.AddError(item.ErrorMessage);
			}
		}
		public CreateBoletoResponse(Guid requestId, string failValidation)
		{
			RequestId = requestId;
			this.AddError(failValidation);
		}
	}
}
