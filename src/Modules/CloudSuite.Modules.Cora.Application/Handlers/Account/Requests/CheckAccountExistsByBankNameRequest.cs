using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account.Requests
{
	public class CheckAccountExistsByBankNameRequest : IRequest<CheckAccountExistsByBankNameResponse>
	{
		public Guid Id {  get; private set; }
		public string? BankName { get; set; }

        public CheckAccountExistsByBankNameRequest(string? bankName)
        {
            Id = Guid.NewGuid();
            BankName = bankName;
        }
    }
}
