using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Transfer
{
    public class CheckTransferExistsByCategoryRequestValidation : AbstractValidator<CheckTransferExistsByCategoryRequest>
    {
        public CheckTransferExistsByCategoryRequestValidation()
        {
            RuleFor(c => c.Category)
                .NotEmpty()
                .WithMessage("Campo obrigatório.")
                .NotNull()
                .WithMessage("Campo obrigatório.");


        }
    }
}
