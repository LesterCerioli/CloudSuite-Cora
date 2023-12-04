using CloudSuite.Modules.Cora.Application.Handlers.Customer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Customer.Requests
{
	public class CheckCustomerExistsBySocialReasonRequest : IRequest<CheckCustomerExistsBySocialReasonResponse>
	{
		public Guid Id {  get; private set; }
		public string? SocialReasion {  get; set; }

        public CheckCustomerExistsBySocialReasonRequest(string? socialReasion)
        {
            Id = Guid.NewGuid();
            SocialReasion = socialReasion;
        }
    }
}
