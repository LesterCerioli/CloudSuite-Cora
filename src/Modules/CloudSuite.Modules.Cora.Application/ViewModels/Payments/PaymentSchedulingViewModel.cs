using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.ViewModels.Payments
{
	public class PaymentSchedulingViewModel
	{
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("DigitableLine")]
        public string? DigitableLine { get; set; }

        [DisplayName("ScheduleAt")]
        //Data de agendamento de Pagamento
        public DateTime? ScheduleAt { get; set; }

        [DisplayName("PaymentStatus")]
        public string? PaymentStatus { get; set; }

        [DisplayName("Code")]
        public string? Code { get; set; }

        [DisplayName("Amount")]
        //Valor do pagamento agendado
        public decimal? Amount { get; set; }

        [DisplayName("CreatedAt")]
        //Data de criação de agendamento de pagamento
        public DateTime? CreatedAt { get; set; }
    }
}
