using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Transfer;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer
{
    public class CheckTransferExistsByBankCodeRecipientHandler : IRequestHandler<CheckTransferExistsByBankCodeRecipientRequest, CheckTransferExistsByBankCodeRecipientResponse>
    {

        private ITransferRepository _repositorioTransfer;
        private readonly ILogger<CheckTransferExistsByBankCodeRecipientHandler> _logger;

        public CheckTransferExistsByBankCodeRecipientHandler(ITransferRepository repositorioTransfer, ILogger<CheckTransferExistsByBankCodeRecipientHandler> logger)
        {
            _repositorioTransfer = repositorioTransfer;
            _logger = logger;
        }

        public async Task<CheckTransferExistsByBankCodeRecipientResponse> Handle(CheckTransferExistsByBankCodeRecipientRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferExistsByBankCodeRecipientRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferExistsByBankCodeRecipientRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var transfer = await _repositorioTransfer.GetByBankCodeRecipient(request.BankCodeRecipient);
                    if (transfer != null)
                    {
                        return await Task.FromResult(new CheckTransferExistsByBankCodeRecipientResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferExistsByBankCodeRecipientResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }
            return await Task.FromResult(new CheckTransferExistsByBankCodeRecipientResponse(request.Id, false, validationResult));
        }
    }
}
