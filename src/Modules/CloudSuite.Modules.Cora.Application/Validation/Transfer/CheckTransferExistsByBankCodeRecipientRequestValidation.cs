using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Transfer
{
    public class CheckTransferExistsByBankCodeRecipientRequestValidation : AbstractValidator<CheckTransferExistsByBankCodeRecipientRequest>
    {
        public CheckTransferExistsByBankCodeRecipientRequestValidation()
        {
            RuleFor(c => c.BankCodeRecipient)
                .NotEmpty()
                .WithMessage("O código do banco é obrigatório.")
                .MinimumLength(3)
                .WithMessage("O código do banco deve ter no mínimo três digitos e é obrigatório.")
                .MaximumLength(3)
                .WithMessage("O código do banco deve ter no máximo três digitos e é obrigatório.");
        }
    }
}
