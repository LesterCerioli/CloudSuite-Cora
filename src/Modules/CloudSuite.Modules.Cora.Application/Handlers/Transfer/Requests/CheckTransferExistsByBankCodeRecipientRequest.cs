using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests
{
    public class CheckTransferExistsByBankCodeRecipientRequest : IRequest<CheckTransferExistsByBankCodeRecipientResponse>
    {
        public Guid Id { get; private set; }
        public string BankCodeRecipient { get; set; }

        public CheckTransferExistsByBankCodeRecipientRequest(string bankCodeRecipient)
        {
            Id = Guid.NewGuid();
            BankCodeRecipient = bankCodeRecipient;
        }
    }
}
