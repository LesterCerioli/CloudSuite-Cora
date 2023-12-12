using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Transfer;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer
{
    public class CheckTransferExistsByAccountNumberHandler : IRequestHandler<CheckTransferExistsByAccountNumberRequest, CheckTransferExistsByAccountNumberResponse>
    {

        private IAccountRepository _repositorioAccount;
        private readonly ILogger<CheckTransferExistsByAccountNumberHandler> _logger;

        public CheckTransferExistsByAccountNumberHandler(IAccountRepository repositorioTranfer, ILogger<CheckTransferExistsByAccountNumberHandler> logger)
        {
            _repositorioAccount = repositorioTranfer;
            _logger = logger;
        }

        public async Task<CheckTransferExistsByAccountNumberResponse> Handle(CheckTransferExistsByAccountNumberRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckTransferExistsByAccountNumberRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckTransferExistsByAccountNumberRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try{
                    var transfer = _repositorioAccount.GetByAccountNumber(request.AccountNumber);

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
