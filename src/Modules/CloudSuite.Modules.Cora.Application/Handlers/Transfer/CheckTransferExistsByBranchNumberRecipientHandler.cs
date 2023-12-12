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
    public class CheckTransferExistsByBranchNumberRecipientHandler : IRequestHandler<CheckTransferExistsByBranchNumberRecipientRequest, CheckTransferExistsByBranchNumberRecipientResponse>
    {
        private ITransferRepository _repositorioTransfer;
        private readonly ILogger<CheckTransferExistsByBranchNumberRecipientHandler> _logger;

        public CheckTransferExistsByBranchNumberRecipientHandler(ITransferRepository repositorioTransfer, ILogger<CheckTransferExistsByBranchNumberRecipientHandler> logger)
        {
            _repositorioTransfer = repositorioTransfer;
            _logger = logger;
        }

        public async Task<CheckTransferExistsByBranchNumberRecipientResponse> Handle(CheckTransferExistsByBranchNumberRecipientRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferExistsByBranchNumberRecipientRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferExistsByBranchNumberRecipientRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var transfer = await _repositorioTransfer.GetByBranchNumberRecipient(request.BranchNumberRecipient);
                    if (transfer != null)
                    {
                        return await Task.FromResult(new CheckTransferExistsByBranchNumberRecipientResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferExistsByBranchNumberRecipientResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckTransferExistsByBranchNumberRecipientResponse(request.Id, false, validationResult));
        }
    }
}
