using CloudSuite.Modules.Cora.Application.Handlers.Account.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Cora.Application.Validation.Account
{
    public class CheckAccountExistsByBankNameRequestValidation : AbstractValidator<CheckAccountExistsByBankNameRequest>
    {
        public CheckAccountExistsByBankNameRequestValidation()
        {
            RuleFor(c => c.BankName)
            .NotEmpty()
            .WithMessage("Nome oficial da Cora é obrigatório.");
        }
    }
}
