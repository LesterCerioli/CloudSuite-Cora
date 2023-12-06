using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer
{
    public class CheckTransferExistsByStatusHandler : IRequestHandler<CheckTransferExistsByStatusRequest, CheckTransferExistsByStatusResponse>
    {

        private ITransferRepository _repositorioTransfer;
        private readonly ILogger<CheckTransferExistsByStatusHandler> _logger;

        public CheckTransferExistsByStatusHandler(ITransferRepository repositorioTransfer, ILogger<CheckTransferExistsByStatusHandler> logger)
        {
            _repositorioTransfer = repositorioTransfer;
            _logger = logger;
        }

        public async Task<CheckTransferExistsByStatusResponse> Handle(CheckTransferExistsByStatusRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferExistsByStatusRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferExistsByStatusRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var transfer = await _repositorioTransfer.GetByStatus(request.Status);
                    if (transfer != null)
                    {
                        return await Task.FromResult(new CheckTransferExistsByStatusResponse(request.Id, true ,validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferExistsByStatusResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }
            return await Task.FromResult(new CheckTransferExistsByStatusResponse(request.Id, false, validationResult));
        }
    }
}
