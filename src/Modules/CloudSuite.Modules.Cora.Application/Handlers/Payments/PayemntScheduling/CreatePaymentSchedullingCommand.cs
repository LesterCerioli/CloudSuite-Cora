using CloudSuite.Modules.Cora.Application.Handlers.Payments.PayemntScheduling.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSchedullingEntity = CloudSuite.Modules.Cora.Domain.Models.Payments.PaymentScheduling;

namespace CloudSuite.Modules.Cora.Application.Handlers.Payments.PayemntScheduling
{
	public class CreatePaymentSchedullingCommand : IRequest<CreatePaymentSchedullingResponse>
	{
        public Guid Id { get; private set; }

        public string? DigitableLine { get; set; }


        //Data de agendamento de Pagamento
        public DateTime? ScheduleAt { get; set; }

        public string? PaymentStatus { get; set; }

        public string? Code { get; set; }

        //Valor do pagamento agendado
        public decimal? Amount { get; set; }

        //Data de criação de agendamento de pagamento
        public DateTime? CreatedAt { get; set; }

        public CreatePaymentSchedullingCommand()
        {
            Id = Guid.NewGuid();
        }

        public PaymentSchedullingEntity GetEntity()
        {
            return new PaymentSchedullingEntity(
                this.DigitableLine,
                this.PaymentStatus,
                this.Code,
                this.CreatedAt,
                this.ScheduleAt,
                this.Amount);
        }
    }
}
