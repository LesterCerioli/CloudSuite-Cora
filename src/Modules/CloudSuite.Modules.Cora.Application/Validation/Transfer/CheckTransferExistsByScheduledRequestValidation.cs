using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Transfer
{
    public class CheckTransferExistsByScheduledRequestValidation : AbstractValidator<CheckTransferExistsByScheduledRequest>
    {
        public CheckTransferExistsByScheduledRequestValidation()
        {
            RuleFor(c => c.ScheduledTime)
                .NotNull()
                .WithMessage("Campo obrigatório")
                .GreaterThanOrEqualTo(DateTimeOffset.Now)
                .WithMessage("A data deve ser em um momento presente ou futuro");
        }
    }
}
