using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests
{
    public class CheckTransferExistsByBranchNumberRecipientRequest : IRequest<CheckTransferExistsByBranchNumberRecipientResponse>
    {
        public Guid Id {  get; private set; }
        public string BranchNumberRecipient {  get; set; }

        public CheckTransferExistsByBranchNumberRecipientRequest(string branchNumberRecipient)
        {
            Id = Guid.NewGuid(;
            BranchNumberRecipient = branchNumberRecipient;
        }
    }
