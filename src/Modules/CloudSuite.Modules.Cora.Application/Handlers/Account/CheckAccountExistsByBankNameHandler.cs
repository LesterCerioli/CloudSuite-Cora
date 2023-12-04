using CloudSuite.Modules.Cora.Application.Handlers.Account.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using CloudSuite.Modules.Cora.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account
{
    public class CheckAccountExistsByBankNameHandler : IRequestHandler<CheckAccountExistsByBankNameRequest, CheckAccountExistsByBankNameResponse>
    {

        private IAccountRepository _repositorioAccount;
        private readonly ILogger<CheckAccountExistsByBankNameHandler> _logger;

        public CheckAccountExistsByBankNameHandler(IAccountRepository repositorioAccount, ILogger<CheckAccountExistsByBankNameHandler> logger)
        {
            _repositorioAccount = repositorioAccount;
            _logger = logger;
        }

        public async Task<CheckAccountExistsByBankNameResponse> Handle(CheckAccountExistsByBankNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPacienteExistsByCpfRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckAccountExistsByBankNameRequestValition().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var account = await _repositorioAccount.GetByBankName(request.BankName);
                    if (account != null)
                        return await Task.FromResult(new CheckAccountExistsByBankNameResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckAccountExistsByBankNameResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckAccountExistsByBankNameResponse(request.Id, false, validationResult));
        }
    }
}
