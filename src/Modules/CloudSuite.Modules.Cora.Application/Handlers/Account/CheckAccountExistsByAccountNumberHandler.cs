using CloudSuite.Modules.Cora.Application.Handlers.Account.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using CloudSuite.Modules.Cora.Application.Validation.Account;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account
{
    public class CheckAccountExistsByAccountNumberHandler : IRequestHandler<CheckAccountExistsByAccountNumberRequest, CheckAccountExistsByAccountNumberResponse>
    {

        private IAccountRepository _accountRepository;
        private readonly ILogger<CheckAccountExistsByAccountNumberHandler> _logger;

        public CheckAccountExistsByAccountNumberHandler(IAccountRepository accountRepository, ILogger<CheckAccountExistsByAccountNumberHandler> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public async Task<CheckAccountExistsByAccountNumberResponse> Handle(CheckAccountExistsByAccountNumberRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExistsAccountByAccountNumberRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckAccountExistsByAccountNumberRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var accountNumber = await _accountRepository.GetByAccountNumber(request.AccountNumber);


                    if (accountNumber != null)
                    {
                        return await Task.FromResult(new CheckAccountExistsByAccountNumberResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckAccountExistsByAccountNumberResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckAccountExistsByAccountNumberResponse(request.Id, false, validationResult));
        }
    }
}
