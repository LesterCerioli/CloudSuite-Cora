using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using ExtractEntity = CloudSuite.Modules.Cora.Domain.Models.Extract;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extract
{
    public class CreateExtractCommand : IRequest<CreateExtractResponse>
    {

        public Guid Id { get; private set; }

		public DateTimeOffset StartDate { get; set; }

		public decimal? StartBalance { get; set; }

		public DateTimeOffset? EndDate { get; set; }

		public decimal? EndBalance { get; set; }

		
		public decimal? AggregationsCreditTotal { get; set; }

		public decimal? AggregationsDebitTotal { get; set; }

		public decimal? EntryAmount { get; set; }

		public string? HeaderBusinessName { get; set; }

		public string? HeaderBusinessDocument { get; set; }

		public CreateExtractCommand()
		{
			Id = Guid.NewGuid();
		}



		public ExtractEntity GetEntity()
        {
            return new ExtractEntity(
                this.EntryAmount,
				this.EndBalance,
				this.EndDate,
				this.StartBalance,
				this.StartDate,
				this.HeaderBusinessDocument,
				this.HeaderBusinessName,
				this.AggregationsCreditTotal,
				this.AggregationsDebitTotal);
        }

    }
}


