using CloudSuite.Modules.Cora.Application.Handlers.Account.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Account
{
    public class CheckAccountExistsByAgencyRequestValidation : AbstractValidator<CheckAccountExistsByAgencyRequest>
    {
        public CheckAccountExistsByAgencyRequestValidation()
        {
            RuleFor(c => c.Agency)
             .NotEmpty()
             .WithMessage("Número da agência é obrigatório.")
             .Equal("0001")
             .WithMessage("Número da agência deve ser 0001.");
        }
    }
}
