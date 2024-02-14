using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Payments.Boletos.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoletoEntity = CloudSuite.Modules.Cora.Domain.Models.Payments.Boleto;

namespace CloudSuite.Modules.Cora.Application.Handlers.Payments.Boletos
{
	public class CreateBoletoCommand : IRequest<CreateBoletoResponse>
	{
        public Guid Id { get; private set; }

        public string? AmountTotal { get; set; }

		public string? Status { get; set; }

		public string? Code { get; set; }

		public DateTimeOffset? CreatedAt { get; set; }

		public DateTimeOffset? FinalizedAt { get; set; }

		public decimal? TotalPaid { get; set; }

		public string? Method { get; set; }

		//Valor total em centavos dos juros pagos.
		//Total value in cents of interest paid.
		public decimal? Interest { get; set; }

		//Total value in cents of the fine paid.
		//Total value in cents of the fine paid.
		public decimal? Fine { get; set; }

		public CreateBoletoCommand()
		{
			Id = Guid.NewGuid();
		}

		public BoletoEntity GetEntity()
		{
			return new BoletoEntity(
				this.AmountTotal,
				this.Status,
				this.Code,
				this.CreatedAt,
				this.FinalizedAt,
				this.TotalPaid,
				this.Method,
				this.Interest,
				this.Fine);
		}
	}
}
