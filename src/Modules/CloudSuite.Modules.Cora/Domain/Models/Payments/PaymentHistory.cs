using CloudSuite.Modules.Common.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Models.Payments
{
	public class PaymentHistory : Entity, IAggregateRoot
	{

		public IReadOnlyList<Pagamento> Pagamentos => _pagamentos;
		private List<Pagamento> _pagamentos;
		
		public PaymentHistory(
			string statusPayment,
			DateTime startDateQuery,
			DateTime endDateQuery) 
		{
			StatusPayment = statusPayment;
			StartDateQuery = DateTime.Now;
			EndDateQuery = DateTime.Now;
		}
		
		public string? StatusPayment { get; private set; }

		public DateTime? StartDateQuery { get; private set; }

        public DateTime? EndDateQuery { get; private set; }

        public Pagination Pagination { get; private set; }

        public Pagamento Pagamento { get; private set; }


		

	}
}
