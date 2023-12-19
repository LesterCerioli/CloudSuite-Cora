using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Requests
{
	public class CheckTransferFilterExistsByPageRequest : IRequest<CheckTransferFilterExistsByPageResponse>
	{
		public Guid Id {  get; private set; }
		public string Page {  get; set; }

        public CheckTransferFilterExistsByPageRequest(string page)
        {
            Id = Guid.NewGuid();
            Page = page;
        }
    }
}
