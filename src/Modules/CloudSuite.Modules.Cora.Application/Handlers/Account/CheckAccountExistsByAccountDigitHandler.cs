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
    public class CheckAccountExistsByAccountDigitHandler : IRequestHandler<CheckAccountExistsByAccountDigitRequest, CheckAccountExistsByAccountDigitResponse>
    {

        private IAccountRepository _repositorioAccount;
        private readonly ILogger<CheckAccountExistsByAccountDigitHandler> _logger;

        public CheckAccountExistsByAccountDigitHandler(IAccountRepository repositorioAccount, ILogger<CheckAccountExistsByAccountDigitHandler> logger)
        {
            _repositorioAccount = repositorioAccount;
            _logger = logger;
        }

        public async Task<CheckAccountExistsByAccountDigitResponse> Handle(CheckAccountExistsByAccountDigitRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
