using CloudSuite.Modules.Cora.Application.Handlers.Transfer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transfer
{
	public class CreateTransferCommand : IRequest<CreateTransferResponse>
	{
		public Guid Id {  get; private set; }
	}
}
