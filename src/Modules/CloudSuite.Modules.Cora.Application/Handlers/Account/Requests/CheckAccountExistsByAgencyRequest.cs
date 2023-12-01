using CloudSuite.Modules.Cora.Application.Handlers.Account.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Account.Requests
{
	public class CheckAccountExistsByAgencyRequest : IRequest<CheckAccountExistsByAgencyResponse>
	{
		public Guid Id { get; private set; }
		public string? Agency {  get; set; }

        public CheckAccountExistsByAgencyRequest(string? agency)
        {
            Id = Guid.NewGuid();
            Agency = agency;
        }
    }
}
