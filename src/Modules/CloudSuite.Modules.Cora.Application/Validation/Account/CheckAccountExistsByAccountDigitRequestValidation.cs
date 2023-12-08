using CloudSuite.Modules.Cora.Application.Handlers.Account.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Account
{
    public class CheckAccountExistsByAccountDigitRequestValidation : AbstractValidator<CheckAccountExistsByAccountDigitRequest>
    {
        public CheckAccountExistsByAccountDigitRequestValidation()
        {
            RuleFor(c => c.Digit)
            .NotEmpty()
            .WithMessage("Número do dígito da conta é obrigatório.");
        }
    }
}
