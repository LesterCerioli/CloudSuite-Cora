using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Transfer
{
    public class CheckTransferExistsByStatusRequestValidation : AbstractValidator<CheckTransferExistsByStatusRequest>
    {
        public CheckTransferExistsByStatusRequestValidation()
        {
            RuleFor(c => c.Status)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotEmpty()
                .WithMessage("O campo é obrigatório.");
        }
    }
}
