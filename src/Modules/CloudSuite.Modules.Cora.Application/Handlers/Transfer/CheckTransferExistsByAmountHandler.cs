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
    public class CheckTransferExistsByAmountHandler : IRequestHandler<CheckTransferExistsByAmountRequest, CheckTransferExistsByAmountResponse>
    {
        private ITransferRepository _repositorioTransfer;
        private readonly ILogger<CheckTransferExistsByAmountHandler> _logger;

        public CheckTransferExistsByAmountHandler(ITransferRepository repositorioTransfer, ILogger<CheckTransferExistsByAmountHandler> logger)
        {
            _repositorioTransfer = repositorioTransfer;
            _logger = logger;
        }

        public async Task<CheckTransferExistsByAmountResponse> Handle(CheckTransferExistsByAmountRequest request, CancellationToken cancellationToken)
        {

            _logger.LogInformation($"CheckTransferExistsByAmountRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferExistsByAmountRequestValidation().Validate(request);

            if(validationResult.IsValid )
            {
                try
                {
                    var transfer = await _repositorioTransfer.GetByAmount(request.Amount);
                    if(transfer != null){
                        return await Task.FromResult(new CheckTransferExistsByAmountResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferExistsByAmountResponse(request.Id, "Não foi possíve processar a solicitação."));
                }
            
            }
            return await Task.FromResult(new CheckTransferExistsByAmountResponse(request.Id, false, validationResult));
        }
    }
}
