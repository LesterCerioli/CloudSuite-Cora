using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses;
using MediatR;


namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions.Requests
{
    public class CheckTransactionExistsByCounterPartyNameRequest : IRequest<CheckTransactionExistsByCounterPartyNameResponse>
    {
        public Guid Id { get; private set; }

        public string? EntryTransactionCounterPartyName { get; private set; }

        public CheckTransactionExistsByCounterPartyNameRequest(string counterPartyName)
        {

            Id = Guid.NewGuid();
            EntryTransactionCounterPartyName = counterPartyName;

        }
    }
}
