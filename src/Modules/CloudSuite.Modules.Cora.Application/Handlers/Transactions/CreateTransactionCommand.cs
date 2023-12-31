using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses;
using MediatR;
using TransactionEntity = CloudSuite.Modules.Cora.Domain.Models.Transaction;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions
{
    public class CreateTransactionCommand : IRequest<CreateTransactionResponse>
    {
        

        public Guid Id { get; private set; }
        
        public decimal? EntryAmount { get; private set; }

        public DateTimeOffset? EntryCreatedAt { get; private set; }

        public string? EntryTransactionDescription { get; private set; }

        public string? EntryTransactionCounterPartyName { get; private set; }

        public string? TransactiOnorder { get; private set; }

        public string? EntryTransactionCounterPartyIdentity { get; private set; }

        public CreateTransactionCommand()
        {
            Id = Guid.NewGuid();
        }

		public TransactionEntity GetEntity()
        {
            return new TransactionEntity(
                this.EntryAmount,
                this.EntryCreatedAt,
                this.EntryTransactionDescription,
                this.EntryTransactionCounterPartyName,
                this.TransactiOnorder,
                this.EntryTransactionCounterPartyIdentity);
        }

    }
}