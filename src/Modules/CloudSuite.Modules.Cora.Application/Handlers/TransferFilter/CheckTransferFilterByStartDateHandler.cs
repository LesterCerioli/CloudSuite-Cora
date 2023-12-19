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
    public class CheckTransferFilterByStartDateHandler : IRequestHandler<CheckTransferFilterExistsByStartDateRequest, CheckTransferFilterExistsByStartDateResponse>
    {
        private ITransferFilterRepository _repositorioTransferFilter;
        private readonly ILogger<CheckTransferFilterByStartDateHandler> _logger;

        public async Task<CheckTransferFilterExistsByStartDateResponse> Handle(CheckTransferFilterExistsByStartDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferFilterExistsByStartDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferFilterExistsByStartDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var transferFilter = await _repositorioTransferFilter.GetByStartDate(request.StartDate);
                    if(transferFilter != null)
                    {
                        return await Task.FromResult(new CheckTransferFilterExistsByStartDateResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferFilterExistsByStartDateResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckTransferFilterExistsByStartDateResponse(request.Id, false, validationResult));
        }
    }
}
