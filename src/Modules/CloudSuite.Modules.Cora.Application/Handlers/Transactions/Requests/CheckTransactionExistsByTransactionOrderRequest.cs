using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses;
using MediatR;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions.Requests
{
    public class CheckTransactionExistsByTransactionOrderRequest : IRequest<CheckTransactionExistsByTransactionOrderResponse>
    {
        public Guid Id { get; private set; }

        public string? TransactiOnorder { get; private set; }

        public CheckTransactionExistsByTransactionOrderRequest(string transactionOrder)
        {
            
            Id = Guid.NewGuid();
            TransactiOnorder = transactionOrder;

        }
    }

}
