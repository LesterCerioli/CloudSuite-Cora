using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
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
    public class CheckTransferExistsByCategoryHandler : IRequestHandler<CheckTransferExistsByCategoryRequest, CheckTransferExistsByCategoryResponse>
    {
        private ITransferRepository _repositorioTransfer;
        private readonly ILogger<CheckTransferExistsByCategoryHandler> _logger;

        public CheckTransferExistsByCategoryHandler(ITransferRepository repositorioTransfer, ILogger<CheckTransferExistsByCategoryHandler> logger)
        {
            _repositorioTransfer = repositorioTransfer;
            _logger = logger;
        }

        public async Task<CheckTransferExistsByCategoryResponse> Handle(CheckTransferExistsByCategoryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferExistsByCategoruResquest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferExistsByCategoryRequestValidtion().Validate(request);

            if(validationResult.IsValid)
            {
                try
                {

                    var transfer = await _repositorioTransfer.GetByCategory(request.Category);
                    if(transfer != null)
                    {
                        return await Task.FromResult(new CheckTransferExistsByCategoryResponse(request.Id, true, validationResult));
                    }

                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferExistsByCategoryResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckTransferExistsByCategoryResponse(request.Id, false, validationResult));
        }
    }
}
