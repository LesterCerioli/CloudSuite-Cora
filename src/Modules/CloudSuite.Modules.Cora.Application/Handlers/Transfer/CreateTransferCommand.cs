using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using CloudSuite.Modules.Cora.Domain.Models;
using MediatR;
using TransferEntity = CloudSuite.Modules.Cora.Domain.Models.Transfer;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer
{
	public class CreateTransferCommand : IRequest<CreateTransferResponse>
	{
		public Guid Id {  get; private set; }


        //Account
        public string? AgencyAccount { get; private set; }

        public string? AccountNumberAccount { get; private set; }

        public string? AccountDigitAccount { get; private set; }

        public string? BankNameAccount { get; private set; }

        public string? BankCodeAccount { get; private set; }


        //Transfer

        public string? Amount { get; set; }

        public string? Description { get; set; }

        public string? Code { get; set; }

        public string? Category { get; set; }

        public DateTimeOffset? CreationDate { get; set; }

        //Codigo de banco de Destinatario - DDD - D para Digito
        public string? BankCodeRecipient { get; set; }

        public string? BranchNumberRecipient { get; set; }

        public string? AccountNumberRecipient { get; set; }

        //Data de Agendamento da Transferência- Scheduling Date
        public DateTimeOffset Scheduled { get; set; }

        public string? AccountType { get; set; }

        public string? Status { get;  set; }


        public CreateTransferCommand()
        {
            Id = Guid.NewGuid();
        }

        public TransferEntity GetEntity()
        {
            return new TransferEntity(
                new Account(AgencyAccount, AccountNumberAccount, AccountDigitAccount, BankNameAccount, BankNameAccount),
                Amount,
                Description,
                Code,
                Category,
                CreationDate,
                BankCodeRecipient,
                BranchNumberRecipient,
                AccountNumberRecipient,
                Scheduled,
                AccountType,
                Status
                );
        }

    }
}
