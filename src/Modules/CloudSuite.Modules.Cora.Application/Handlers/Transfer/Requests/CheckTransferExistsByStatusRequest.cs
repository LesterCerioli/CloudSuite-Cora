using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests
{
    public class CheckTransferExistsByStatusRequest : IRequest<CheckTransferExistsByStatusResponse>
    {
        public Guid Id { get; private set; }
        public string Status {  get; set; }

        public CheckTransferExistsByStatusRequest(string status)
        {
            Id = Guid.NewGuid();
            Status = status;
        }
    }
}
