using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests
{
    public class CheckTransferExistsByScheduledRequest : IRequest<CheckTransferExistsByScheduledResponse>
    {
        public Guid Id {  get; private set; }
        public DateTimeOffset ScheduledTime {  get; set; }

        public CheckTransferExistsByScheduledRequest(DateTimeOffset scheduledTime)
        {
            Id = Guid.NewGuid();
            ScheduledTime = scheduledTime;
        }
    }
}
