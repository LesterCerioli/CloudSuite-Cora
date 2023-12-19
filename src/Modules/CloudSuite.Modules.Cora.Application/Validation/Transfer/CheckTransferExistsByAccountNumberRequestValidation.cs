using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Transfer
{
    public class CheckTransferExistsByAccountNumberRequestValidation : AbstractValidator<CheckTransferExistsByAccountNumberRequest>
    {
        public CheckTransferExistsByAccountNumberRequestValidation()
        {
            RuleFor(c => c.AccountNumber)
                .NotEmpty()
                .WithMessage("Número da conta é obrigatório.")
                .MinimumLength(6)
                .WithMessage("a conta deve ter 6 caracteres.")
                .MaximumLength(6)
                .WithMessage("a conta deve ter 6 caracteres.");
        }
    }
}
