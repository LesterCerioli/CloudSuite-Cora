using CloudSuite.Modules.Cora.Application.Handlers.Extract.Request;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Extract
{
    public class CheckExtractExistsByDateRequestValidation : AbstractValidator<CheckExtractExistsByDateRequest>
    {
        public CheckExtractExistsByDateRequestValidation()
        {
            var request = new CheckExtractExistsByDateRequest();

            RuleFor(a => a.StartDate)
           .NotEmpty()
           .Must(date => date == default(DateTimeOffset))
           .WithMessage("O Formato da data está incorreto.")
           .Must(date => date <= DateTime.Now)
           .WithMessage("A data não pode ser superior à data atual.");

            RuleFor(a => a.EndDate)
            .NotEmpty()
            .Must(date => date == default(DateTimeOffset))
            .WithMessage("O Formato da data está incorreto.")
            .Must(date => date >= request.StartDate)
            .WithMessage("A data não pode ser anterior à data de inicio.")
            .Must(date => date <= DateTime.Now)
            .WithMessage("A data de término não pode ser superior à data atual.");
        }
    }
}
