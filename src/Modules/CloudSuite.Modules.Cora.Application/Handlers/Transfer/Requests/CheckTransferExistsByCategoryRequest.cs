using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer.Requests
{
    public class CheckTransferExistsByCategoryRequest : IRequest<CheckTransferExistsByCategoryResponse>
    {
        public Guid Id {  get; private set; }
        public string Category {  get; set; }

        public CheckTransferExistsByCategoryRequest(string category)
        {
            Id = Guid.NewGuid();
            Category = category;
        }
    }
}
