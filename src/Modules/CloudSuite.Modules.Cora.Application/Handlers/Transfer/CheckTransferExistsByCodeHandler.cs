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
    public class CheckTransferExistsByCodeHandler : IRequestHandler<CheckTransferExistsByCodeRequest, CheckTransferExistsByCodeResponse>
    {

        private ITransferRepository _repositorioTransfer;
        private readonly ILogger<CheckTransferExistsByCodeHandler> _logger;

        public CheckTransferExistsByCodeHandler(ITransferRepository repositorioTransfer, ILogger<CheckTransferExistsByCodeHandler> logger)
        {
            _repositorioTransfer = repositorioTransfer;
            _logger = logger;
        }

        public async Task<CheckTransferExistsByCodeResponse> Handle(CheckTransferExistsByCodeRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferExistsByCodeRequest: {JsonSerializer.Serialize(request)}");
            var validaitonResult = new CheckTransferExistsByCodeRequestValidation().Validate(request);

            if (validaitonResult.IsValid)
            {
                try
                {
                    var transfer = await _repositorioTransfer.GetByCode(request.Code);

                    if(transfer != null)
                    {
                        return await Task.FromResult(new CheckTransferExistsByCodeResponse(request.Id, true, validaitonResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferExistsByCodeResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckTransferExistsByCodeResponse(request.Id, false, validaitonResult));
        }
    }
}
