using CloudSuite.Modules.Common.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Models.Payments
{
	public class Boleto : Entity, IAggregateRoot
	{
		public Boleto(string? amountTotal, string? status, 
			DateTimeOffset? createdAt, DateTimeOffset? finalizedAt, 
			decimal? totalPaid, Method method, decimal? interest, 
			decimal? fine, string code)
		{
			AmountTotal = amountTotal;
			Status = status;
			CreatedAt = DateTimeOffset.Now;
			FinalizedAt = DateTimeOffset.Now;
			TotalPaid = totalPaid;
			Method = method;
			Interest = interest;
			Fine = fine;
			Code = code;
		}
		public Boleto() { }
		
		public string? AmountTotal { get; private set; }

        public string? Status { get; private set; }

        public string? Code { get; private set; }

        public DateTimeOffset? CreatedAt { get; private set; }

        public DateTimeOffset? FinalizedAt { get; private set; }

        public decimal? TotalPaid { get; private set; }

        public Method Method { get; private set; }

		//Valor total em centavos dos juros pagos.
		//Total value in cents of interest paid.
		public decimal? Interest { get; private set; }

		//Total value in cents of the fine paid.
		//Total value in cents of the fine paid.
		public decimal? Fine { get; private set; }
    }
}
