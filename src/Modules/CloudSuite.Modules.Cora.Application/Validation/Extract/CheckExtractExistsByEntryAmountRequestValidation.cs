using CloudSuite.Modules.Cora.Application.Handlers.Extract.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Extract
{
    public class CheckExtractExistsByEntryAmountRequestValidation : AbstractValidator<CheckExtractExistsByEntryAmountRequest>
    {
        public CheckExtractExistsByEntryAmountRequestValidation()
        {

            RuleFor(a => a.EntryAmount)
                .NotNull()
                .WithMessage("Campo obrigatório");
        }
    }
}
