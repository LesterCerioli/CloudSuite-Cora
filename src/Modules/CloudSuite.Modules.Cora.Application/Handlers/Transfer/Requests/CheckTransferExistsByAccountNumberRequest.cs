using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests
{
    public class CheckTransferExistsByAccountNumberRequest : IRequest<CheckTransferExistsByAccountNumberResponse>
    {
        public Guid Id {  get; private set; }
        public string AccountNumber {  get; set; }

        public CheckTransferExistsByAccountNumberRequest(string accountNumber)
        {
            Id = Guid.NewGuid();
            AccountNumber = accountNumber;
        }
    }
}
