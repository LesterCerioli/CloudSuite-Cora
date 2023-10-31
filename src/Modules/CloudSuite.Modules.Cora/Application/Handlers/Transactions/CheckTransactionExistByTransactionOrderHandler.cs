using CloudSuite.Modules.Cora.Application.Handlers.Extract;
using CloudSuite.Modules.Cora.Application.Handlers.Extract.Request;
using CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses;
using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Extract;
using CloudSuite.Modules.Cora.Application.Validation.Transaction;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions
{
    public class CheckTransactionExistByTransactionOrderHandler : IRequestHandler<CheckTransactionExistByTransactionOrderRequest, CheckTransactionExistByTransactionOrderResponse>
    {
        private TransactionRepository _transactionRepository;
        private readonly ILogger<CheckTransactionExistByTransactionOrderHandler> _logger;

        public CheckTransactionExistByTransactionOrderHandler(TransactionRepository transactionRepository, ILogger<CheckTransactionExistByTransactionOrderHandler> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<CheckTransactionExistByTransactionOrderResponse> Handle(CheckTransactionExistByTransactionOrderRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransactionExistByTransactionOrderRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransactionExistByTransactionOrderRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var transactionOrderExist = await _transactionRepository.GetByTransactionOrder(request.TransactiOnorder);


                    if (transactionOrderExist != null)
                    {
                        return await Task.FromResult(new CheckTransactionExistByTransactionOrderResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransactionExistByTransactionOrderResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckTransactionExistByTransactionOrderResponse(request.Id, false, validationResult));
        }
    }
}
