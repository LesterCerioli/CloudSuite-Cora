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
    public class CheckTransferExistsByScheduledHandler : IRequestHandler<CheckTransferExistsByScheduledRequest, CheckTransferExistsByScheduledResponse>
    {

        private ITransferRepository _repositorioTransfer;
        private readonly ILogger<CheckTransferExistsByScheduledHandler> _logger;

        public CheckTransferExistsByScheduledHandler(ITransferRepository repositorioTransfer, ILogger<CheckTransferExistsByScheduledHandler> logger)
        {
            _repositorioTransfer = repositorioTransfer;
            _logger = logger;
        }

        public async Task<CheckTransferExistsByScheduledResponse> Handle(CheckTransferExistsByScheduledRequest request, CancellationToken cancellationToken)
        {

            _logger.LogInformation($"CheckTransferExistsByScheduledRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferExistsByScheduledRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var transfer = await _repositorioTransfer.GetByScheduled(request.ScheduledTime);
                    if(transfer != null)
                    {
                        return await Task.FromResult(new CheckTransferExistsByScheduledResponse(request.Id, true, validationResult));
                    }

                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferExistsByScheduledResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckTransferExistsByScheduledResponse(request.Id, false, validationResult));
        }
    }
}
