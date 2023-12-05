using CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extract.Request
{
	public class CheckExtractExistsByEndDateRequest : IRequest<CheckExtractExistsByEndDateResponse>
	{
		public Guid Id { get; private set; }
		public DateTimeOffset EndDate { get; set; }

        public CheckExtractExistsByEndDateRequest(DateTimeOffset endDate)
        {
            Id = Guid.NewGuid();
            EndDate = endDate;
        }
    }
}
