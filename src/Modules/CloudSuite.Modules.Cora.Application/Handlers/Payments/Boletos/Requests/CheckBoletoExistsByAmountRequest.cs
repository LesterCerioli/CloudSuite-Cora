using CloudSuite.Modules.Cora.Application.Handlers.Payments.Boletos.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Payments.Boletos.Requests
{
	public class CheckBoletoExistsByAmountRequest : IRequest<CheckBoletoExistsByAmountResponse>
	{
        public Guid Id { get; private set; }

        public string Amount { get; set; }

        public CheckBoletoExistsByAmountRequest(string amount)
		{
			Id = Guid.NewGuid();
			Amount = amount;
		}
	}
}
