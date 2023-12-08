using CloudSuite.Modules.Cora.Application.Handlers.Extract;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato;
using FluentValidation;

namespace CloudSuite.Modules.Cora.Application.Validation.Extract
{
    public class CreateExtractCommandValidation : AbstractValidator<CreateExtractCommand>
    {
        public CreateExtractCommandValidation() 
        {
            var command = new CreateExtractCommand();

            RuleFor(a => a.StartDate)
            .NotEmpty()
            .Must(date => date == default(DateTimeOffset))
            .WithMessage("O Formato da data está incorreto.")
            .Must(date => date <= DateTime.Now)
            .WithMessage("A data não pode ser superior à data atual.");

            RuleFor(a => a.StartBalance)
            .Must(balance => balance >= 0)
            .WithMessage("O saldo em centavos da conta na data da primeira movimentação precisa ser maior ou igual a 0.")
            .Must(balance => balance is int)
            .WithMessage("Balance deve ser um número inteiro.");

            RuleFor(a => a.EndDate)
            .NotEmpty()
            .Must(date => date == default(DateTimeOffset))
            .WithMessage("O Formato da data está incorreto.")
            .Must(date => date >= command.StartDate)
            .WithMessage("A data não pode ser anterior à data de inicio.")
            .Must(date => date <= DateTime.Now)
            .WithMessage("A data de término não pode ser superior à data atual.");

            RuleFor(a => a.EndBalance)
            .Must(balance => balance >= 0)
            .WithMessage("O saldo em centavos da conta na data da primeira movimentação precisa ser maior ou igual a 0.")
            .Must(balance => balance is int)
            .WithMessage("Balance deve ser um número inteiro.");

            RuleFor(a => a.EntryAmount)
                .NotNull()
                .WithMessage("Campo obrigatório");


            RuleFor(a => a.AggregationsCreditTotal)
            .Must(aggregationsCreditTotal => aggregationsCreditTotal >= 0)
            .WithMessage("A Soma dos valores listados que entraram na conta, como operação de crédito. precisa ser maior que 0");

            RuleFor(a => a.AggregationsDebitTotal)
            .Must(aggregationsDebitTotal => aggregationsDebitTotal >= 0)
            .WithMessage("Soma dos valores listados que saíram na conta, como operação de débito precisa ser maior que 0");

            RuleFor(a => a.HeaderBusinessName)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("Numero minimo de caracteres no nome da contra parte não foi alcançado.")
            .MaximumLength(60)
            .WithMessage("Numero maximo de caracteres no nome da contra parte excedido.");

            RuleFor(a => a.HeaderBusinessDocument)
            .NotEmpty()
            .WithMessage("O documento de identificação é obrigatório.")
            .Matches(@"^\d+$")
            .WithMessage("O documento de identificação deve conter apenas números. Letras e símbolos não são permitidos.");

        }
    }
   }
