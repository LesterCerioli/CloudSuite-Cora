using CloudSuite.Modules.Cora.Application.Handlers.Extract.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Extract
{
    public class CheckExtractExistsByEndDateRequestValidation : AbstractValidator<CheckExtractExistsByEndDateRequest>
    {
        public CheckExtractExistsByEndDateRequestValidation()
        {
            RuleFor(a => a.EndDate)
            .NotEmpty()
            .Must(date => date == default(DateTimeOffset))
            .WithMessage("O Formato da data está incorreto.");
        }
    }
}
