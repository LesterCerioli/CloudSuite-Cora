using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.TransferFilter
{
    public class CheckTransferFilterExistsByPageRequestValidation : AbstractValidator<CheckTransferFilterExistsByPageRequest>
    {
        public CheckTransferFilterExistsByPageRequestValidation()
        {
            RuleFor(a => a.Page)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo é obrigatório.");
        }
    }
}
