using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Validation.Transaction
{
    public class CheckTransactionExistByCounterPartyNameRequestValidation : AbstractValidator<CheckTransactionExistByCounterPartyNameRequest>
    {
        public CheckTransactionExistByCounterPartyNameRequestValidation()
        {
            RuleFor(a => a.EntryTransactionCounterPartyName)
            .MinimumLength(3)
            .WithMessage("O nome da contraparte da transação deve ter pelo menos 3 caracteres.")
            .MaximumLength(60)
            .WithMessage("O nome da contraparte da transação deve ter no máximo 60 caracteres.");
        }
    }
}
