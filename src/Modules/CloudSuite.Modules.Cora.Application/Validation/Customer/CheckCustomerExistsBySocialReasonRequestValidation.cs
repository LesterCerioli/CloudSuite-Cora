using CloudSuite.Modules.Cora.Application.Handlers.Customer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Customer
{
    public class CheckCustomerExistsBySocialReasonRequestValidation : AbstractValidator<CheckCustomerExistsBySocialReasonRequest>
    {
        public CheckCustomerExistsBySocialReasonRequestValidation()
        {
            RuleFor(a => a.SocialReasion)
                .NotEmpty()
                .WithMessage("O campo SocialReason é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo SocialReason deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo SocialReason deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo SocialReason não pode ser nulo.");
        }
    }
}
