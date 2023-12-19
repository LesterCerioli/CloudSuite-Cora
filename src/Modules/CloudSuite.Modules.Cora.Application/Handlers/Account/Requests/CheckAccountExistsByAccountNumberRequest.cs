using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account.Requests
{
	public class CheckAccountExistsByAccountNumberRequest : IRequest<CheckAccountExistsByAccountNumberResponse>
    {
		public Guid Id { get; private set; }

        public string AccountNumber { get; private set; }


		public CheckAccountExistsByAccountNumberRequest(string accountNumber)
		{
            Id = Guid.NewGuid();
            AccountNumber = accountNumber;
		}
    }
}
