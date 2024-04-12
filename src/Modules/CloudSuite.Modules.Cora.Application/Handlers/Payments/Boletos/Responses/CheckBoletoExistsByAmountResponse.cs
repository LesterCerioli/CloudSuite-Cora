using CloudSuite.Modules.Cora.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Payments.Boletos.Responses
{
	public class CheckBoletoExistsByAmountResponse : Response
	{
		public Guid RequestId { get; private set; }
		public bool Exists { get; set; }

		public CheckBoletoExistsByAmountResponse(Guid requestId, string failValidation)
		{
			RequestId = requestId;
			Exists = false;
			this.AddError(failValidation);
		}


	}
}
