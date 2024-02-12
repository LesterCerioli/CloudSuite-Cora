using NetDevPack.Domain;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Cora.Domain.Models.Payments
{
    public class PaymentScheduling : Entity, IAggregateRoot
    {
        public PaymentScheduling(string? digitableLine, DateTime? scheduleAt, string? paymentStatus, string? code, decimal? amount, DateTime? createdAt)
        {
            DigitableLine = digitableLine;
            ScheduleAt = DateTime.Now;
            PaymentStatus = paymentStatus;
            Code = code;
            Amount = amount;
            CreatedAt = DateTime.Now;
        }

        //Código de barras de Pagamento
        public string? DigitableLine {get; private set;}


        //Data de agendamento de Pagamento
        public DateTime? ScheduleAt {get; private set;}

        public string? PaymentStatus {get; private set;}

        public string? Code {get; private set;}

        //Valor do pagamento agendado
        public decimal? Amount {get; private set;}

        //Data de criação de agendamento de pagamento
        public DateTime? CreatedAt {get; private set;}
    }
}