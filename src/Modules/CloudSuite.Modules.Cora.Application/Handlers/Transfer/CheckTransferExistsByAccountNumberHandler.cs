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
    public class CheckTransferExistsByAccountNumberHandler : IRequestHandler<CheckTransferExistsByAccountNumberRequest, CheckTransferExistsByAccountNumberResponse>
    {

        private ITransferRepository _repositorioTranfer;
        private readonly ILogger<CheckTransferExistsByAccountNumberHandler> _logger;

        public CheckTransferExistsByAccountNumberHandler(ITransferRepository repositorioTranfer, ILogger<CheckTransferExistsByAccountNumberHandler> logger)
        {
            _repositorioTranfer = repositorioTranfer;
            _logger = logger;
        }

        public async Task<CheckTransferExistsByAccountNumberResponse> Handle(CheckTransferExistsByAccountNumberRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferExistsByAccountNumberRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferExistsByAccountNumberResponseValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try{
                    var transfer = _repositorioTranfer.GetByAccountNumber(request.AccountNumber);

                    if (transfer != null)
                    {
                        return await Task.FromResult(new CheckTransferExistsByAccountNumberResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckTransferExistsByAccountNumberResponse(request.Id, "Mão foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckTransferExistsByAccountNumberResponse(request.Id, false, validationResult));
        }
    }
}
