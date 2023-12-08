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
    public class CheckExtractExistsByStartDateHandler : IRequestHandler<CheckExtractExistsByStartDateRequest, CheckExtractExistsByStartDateResponse>
    {

        private IExtractRepository _repositorioExtract;
        private readonly ILogger<CheckExtractExistsByEndDateHandler> _logger;

        public CheckExtractExistsByStartDateHandler(IExtractRepository repositorioExtract, ILogger<CheckExtractExistsByEndDateHandler> logger)
        {
            _repositorioExtract = repositorioExtract;
            _logger = logger;
        }

        public async Task<CheckExtractExistsByStartDateResponse> Handle(CheckExtractExistsByStartDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByStartDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckExtractExistsByStartDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var extract = await _repositorioExtract.GetByStartDate(request.StartDate);
                    if (extract != null)
                    {
                        return await Task.FromResult(new CheckExtractExistsByStartDateResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckExtractExistsByStartDateResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }
            return await Task.FromResult(new CheckExtractExistsByStartDateResponse(request.Id, false, validationResult));
        }
    } 
}
