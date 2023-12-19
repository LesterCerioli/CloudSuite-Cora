using CloudSuite.Modules.Cora.Application.Handlers.Extract.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extract.Request
{
	public class CheckExtractExistsByEntryAmountRequest : IRequest<CheckExtractExistsByEntryAmountResponse>
	{
		public Guid Id {  get; private set; }
		public decimal EntryAmount {  get; set; }

        public CheckExtractExistsByEntryAmountRequest(decimal entryAmount)
        {
            Id = Guid.NewGuid();
            EntryAmount = entryAmount;
        }
    }
}
