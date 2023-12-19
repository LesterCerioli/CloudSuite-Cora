using CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.TransferFilter.Requests
{
	public class CheckTransferFilterExistsByEndDateRequest : IRequest<CheckTransferFilterExistsByEndDateResponse>
	{
		public Guid Id {  get; private set; }
		public DateTime EndDate {  get; set; }

        public CheckTransferFilterExistsByEndDateRequest(DateTime endDate)
        {
            Id = Guid.NewGuid();
            EndDate = endDate;
        }
    }
}
