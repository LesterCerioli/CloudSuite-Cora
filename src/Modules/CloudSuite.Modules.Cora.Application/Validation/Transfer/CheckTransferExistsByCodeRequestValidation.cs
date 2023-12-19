using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Transfer
{
    public class CheckTransferExistsByCodeRequestValidation : AbstractValidator<CheckTransferExistsByCodeRequest>
    {
        public CheckTransferExistsByCodeRequestValidation()
        {
            RuleFor(c => c.Code)
                .NotEmpty()
                .WithMessage("Campo Obrigatório.")
                .NotNull()
                .WithMessage("Campo Obrigatório.");
        }
    }
}
