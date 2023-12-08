using CloudSuite.Modules.Cora.Application.Handlers.Extract.Request;
using CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Extract;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extract
{
    public class CheckExtractExistsByEntryAmountHandler : IRequestHandler<CheckExtractExistsByEntryAmountRequest, CheckExtractExistsByEntryAmountResponse>
    {

        private IExtractRepository _repositorioExtract;
        private readonly ILogger<CheckExtractExistsByEndDateHandler> _logger;

        public CheckExtractExistsByEntryAmountHandler(IExtractRepository repositorioExtract, ILogger<CheckExtractExistsByEndDateHandler> logger)
        {
            _repositorioExtract = repositorioExtract;
            _logger = logger;
        }

        public async Task<CheckExtractExistsByEntryAmountResponse> Handle(CheckExtractExistsByEntryAmountRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByEntryAmountRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckExtractExistsByEntryAmountRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var extract = await _repositorioExtract.GetByEntryAmount(request.EntryAmount);
                    if (extract != null)
                    {
                        return await Task.FromResult(new CheckExtractExistsByEntryAmountResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckExtractExistsByEntryAmountResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }
            return await Task.FromResult(new CheckExtractExistsByEntryAmountResponse(request.Id, false, validationResult));
        }
    }
}