using CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extract.Request
{
	public class CheckExtractExistsByStartDateRequest : IRequest<CheckExtractExistsByStartDateResponse>
	{
		public Guid Id { get; private set; }
		public DateTimeOffset StartDate { get; set; }

        public CheckExtractExistsByStartDateRequest(DateTimeOffset startDate)
        {
            Id = Guid.NewGuid();
            StartDate = startDate;
        }
    }
}
