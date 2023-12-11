using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Transfer
{
    public class CheckTransferExistsByBranchNumberRecipientRequestValidation : AbstractValidator<CheckTransferExistsByBranchNumberRecipientRequest>
    {
        public CheckTransferExistsByBranchNumberRecipientRequestValidation()
        {
            RuleFor(c => c.BranchNumberRecipient)
               .NotEmpty()
               .WithMessage("Número da agência de destino é obrigatório.")
               .MinimumLength(6)
               .WithMessage("O número da agência de destino deve tyer 6 caracteres.")
               .MaximumLength(6)
               .WithMessage("O número da agência de destino ter 6 caracteres.");
        }
    }
}
