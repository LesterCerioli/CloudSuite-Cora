using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Responses;
using CloudSuite.Modules.Cora.Application.Validation.TransferFilter;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.TransferFilter
{
    public class CheckTransferFilterExistsByPageHandler : IRequestHandler<CheckTransferFilterExistsByPageRequest, CheckTransferFilterExistsByPageResponse>
    {

        private ITransferFilterRepository _repositorioTransferFilter;
        private readonly ILogger<CheckTransferFilterExistsByPageHandler> _logger;

        public async Task<CheckTransferFilterExistsByPageResponse> Handle(CheckTransferFilterExistsByPageRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferFilterExistsByPageRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferFilterExistsByPageRequestValidation().Validate(request);

            if(validationResult.IsValid )
            {
                try
                {
                    var trasnferFilter = await _repositorioTransferFilter.GetByPage(request.Page);
                    if (trasnferFilter != null)
                    {
                        return await Task.FromResult(new CheckTransferFilterExistsByPageResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferFilterExistsByPageResponse(request.Id, "Não foi possível processar a solicitação."));
                }

            }

            return await Task.FromResult(new CheckTransferFilterExistsByPageResponse(request.Id, false, validationResult));
        }
    }
}
