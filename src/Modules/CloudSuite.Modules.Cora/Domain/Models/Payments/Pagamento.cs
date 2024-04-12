using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Models.Payments
{
	public class Pagamento : Entity, IAggregateRoot
	{
        public string? PaymentNumber { get; private set; }

        public string? Amount { get; private set; }

        public PaymentHistory PaymentHistory { get; private set; }
    }
}
