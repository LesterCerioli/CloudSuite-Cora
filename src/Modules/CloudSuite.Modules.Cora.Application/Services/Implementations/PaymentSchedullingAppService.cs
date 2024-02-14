using AutoMapper;
using CloudSuite.Modules.Cora.Application.Handlers.Payments.PayemntScheduling;
using CloudSuite.Modules.Cora.Application.Services.Contracts;
using CloudSuite.Modules.Cora.Application.ViewModels.Payments;
using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Services.Implementations
{
	public class PaymentSchedullingAppService : IPaymentSchedullingAppService
	{
		private readonly IPaymentSchedulingRepository _paymentSchedullingRepository;
		private readonly IMapper _mapper;
		private readonly IMediatorHandler _mediator;

		public PaymentSchedullingAppService(
			IPaymentSchedulingRepository paymentSchedulingRepository,
			IMapper mapper,
			IMediatorHandler mediator)
		{
			_paymentSchedullingRepository = paymentSchedulingRepository;
			_mapper = mapper;
			_mediator = mediator;

        }

        public async Task<PaymentSchedulingViewModel> GetByAmount(string amount)
		{
			return _mapper.Map<PaymentSchedulingViewModel>(await _paymentSchedullingRepository.GetByAmount(amount));
		}

		public async Task<PaymentSchedulingViewModel> GetByCode(string code)
		{
			return _mapper.Map<PaymentSchedulingViewModel>(await _paymentSchedullingRepository.GetByCode(code));
		}

		public async Task<PaymentSchedulingViewModel> GetByScheduleAt(string scheduleAt)
		{
			return _mapper.Map<PaymentSchedulingViewModel>(await _paymentSchedullingRepository.GetByScheduleAt(scheduleAt));
		}

		public async Task Save(CreatePaymentSchedullingCommand commandCreate)
		{
            await _paymentSchedullingRepository.Add(commandCreate.GetEntity());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
