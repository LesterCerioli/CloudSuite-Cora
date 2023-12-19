using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.TransferFilter
{
    public class CheckTransferFilterExistsByEndDateRequestValidation : AbstractValidator<CheckTransferFilterExistsByEndDateRequest>
    {
        public CheckTransferFilterExistsByEndDateRequestValidation()
        {
            RuleFor(a => a.EndDate)
            .NotEmpty()
            .Must(date => date == default(DateTimeOffset))
            .WithMessage("O Formato da data está incorreto.");
        }
    }
}
