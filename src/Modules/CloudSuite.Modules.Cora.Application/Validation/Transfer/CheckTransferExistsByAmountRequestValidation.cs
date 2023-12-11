using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Transfer
{
    public class CheckTransferExistsByAmountRequestValidation : AbstractValidator<CheckTransferExistsByAmountRequest>
    {
        public CheckTransferExistsByAmountRequestValidation()
        {
            RuleFor(c => decimal.Parse(c.Amount))
                .NotEmpty()
                .WithMessage("Campo obrigatório.")
                .GreaterThan(0)
                .WithMessage("O campo deve ser preenchido com uma quantidade em centavos e maior que zero.")
                .NotNull()
                .WithMessage("Campo obrigatório.");
        }
    }
}
