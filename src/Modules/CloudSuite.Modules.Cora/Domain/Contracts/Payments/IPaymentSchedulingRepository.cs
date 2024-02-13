using CloudSuite.Modules.Cora.Domain.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts.Payments
{
	public interface IPaymentSchedulingRepository
	{
		Task<PaymentScheduling> GetByDigitableLine(string digitableLine);

		Task<PaymentScheduling> GetByScheduleAt(string scheduleAt);

		Task<PaymentScheduling> GetByAmount(string amount);

		Task<PaymentScheduling> GetByCode(string code);

		Task Add(PaymentScheduling paymentScheduling);

		void Update(PaymentScheduling paymentScheduling);

		void Remove(PaymentScheduling paymentScheduling);

    }
}
