using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.TransferFilter
{
    public class CheckTransferFilterExistsByStartDateRequestValidation : AbstractValidator<CheckTransferFilterExistsByStartDateRequest>
    {
        public CheckTransferFilterExistsByStartDateRequestValidation()
        {
            RuleFor(a => a.StartDate)
           .NotEmpty()
           .Must(date => date == default(DateTimeOffset))
           .WithMessage("O Formato da data está incorreto.")
           .Must(date => date <= DateTime.Now)
           .WithMessage("A data não pode ser superior à data atual.");
        }
    }
}
