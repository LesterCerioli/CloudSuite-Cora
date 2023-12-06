using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Responses;
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
    public class CheckTransferFilterExistsByEndDateHandler : IRequestHandler<CheckTransferFilterExistsByEndDateRequest, CheckTransferFilterExistsByEndDateResponse>
    {

        private ITransferFilterRepository _repositorioTransferFilter;
        private readonly ILogger<CheckTransferFilterExistsByEndDateHandler> _logger;


        public async Task<CheckTransferFilterExistsByEndDateResponse> Handle(CheckTransferFilterExistsByEndDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferFilterExistsByEndDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferFilterExistsByEndDateReuqestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var paciente = await _repositorioTransferFilter.GetByEndDate(request.EndDate);
                    if (paciente != null)
                        return await Task.FromResult(new CheckTransferFilterExistsByEndDateResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferFilterExistsByEndDateResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckTransferFilterExistsByEndDateResponse(request.Id, false, validationResult));
        }
    }
}
