using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Requests
{
	public class CheckTransferFilterExistsByStartDateRequest : IRequest<CheckTransferFilterExistsByStartDateResponse>
    {
		public Guid Id {  get; private set; }
		public DateTime StartDate { get; set; }

        public CheckTransferFilterExistsByStartDateRequest(DateTime startDate)
        {
            Id = Guid.NewGuid();
            StartDate = startDate;
        }
    }
}
