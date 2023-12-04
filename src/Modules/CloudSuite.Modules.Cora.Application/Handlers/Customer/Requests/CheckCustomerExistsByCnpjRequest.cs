using CloudSuite.Modules.Cora.Application.Handlers.Customer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Customer.Requests
{
	public class CheckCustomerExistsByCnpjRequest : IRequest<CheckCustomerExistsByCnpjResponse>
	{
		public Guid Id { get; private set; }
		public string? Cnpj {  get; set; }

        public CheckCustomerExistsByCnpjRequest(string? cnpj)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
        }
    }
}
