using CloudSuite.Modules.Cora.Application.Handlers.Payments.PayemntScheduling;
using CloudSuite.Modules.Cora.Application.ViewModels.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Services.Contracts
{
	public interface IPaymentSchedullingAppService
	{
		Task<PaymentSchedulingViewModel> GetByScheduleAt(string scheduleAt);

		Task<PaymentSchedulingViewModel> GetByAmount(string amount);

		Task<PaymentSchedulingViewModel> GetByCode(string code);

        Task Save(CreatePaymentSchedullingCommand commandCreate);
    }
}
