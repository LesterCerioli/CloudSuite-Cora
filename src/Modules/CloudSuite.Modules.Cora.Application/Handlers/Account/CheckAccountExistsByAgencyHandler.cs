using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Account.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account
{
    public class CheckAccountExistsByAgencyHandler : IRequestHandler<CheckAccountExistsByAgencyRequest, CheckAccountExistsByAgencyResponse>
    {
        private IAccountRepository _repositorioAccount;
        private readonly ILogger<CheckAccountExistsByAgencyHandler> _logger;

        public CheckAccountExistsByAgencyHandler(IAccountRepository repositorioAccount, ILogger<CheckAccountExistsByAgencyHandler> logger)
        {
            _repositorioAccount = repositorioAccount;
            _logger = logger;
        }

        public async Task<CheckAccountExistsByAgencyResponse> Handle(CheckAccountExistsByAgencyRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckAccountExistsByAgencyRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckAccountExistsByAgencyRequestValition().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var account = await _repositorioAccount.GetByAgency(request.Agency);
                    if (account != null)
                        return await Task.FromResult(new CheckAccountExistsByAgencyResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckAccountExistsByAgencyResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckAccountExistsByAgencyResponse(request.Id, false, validationResult));
        }
    }
}
