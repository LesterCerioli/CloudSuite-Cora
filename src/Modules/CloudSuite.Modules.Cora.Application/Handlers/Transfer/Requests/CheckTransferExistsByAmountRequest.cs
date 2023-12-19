using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests
{
    public class CheckTransferExistsByAmountRequest : IRequest<CheckTransferExistsByAmountResponse>
    {
        public Guid Id {  get; private set; }
        public string Amount {  get; set; }

        public CheckTransferExistsByAmountRequest(string amount)
        {
            Id = Guid.NewGuid();
            Amount = amount;
        }
    }
}
