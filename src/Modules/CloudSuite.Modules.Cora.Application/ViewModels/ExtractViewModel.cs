using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.ViewModels
{
	public class ExtractViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[DisplayName("Data Inicio")]
		public DateTimeOffset StartDate { get; set; }

		
		[DisplayName("Data Fim")]
		[Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
		public DateTimeOffset EndDate { get; set; }

		
		[DisplayName("Valor de Entrada")]
		[Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
		public decimal? EntryAmount { get; set; }

		[DisplayName("Valor de Credito Total")]
		public decimal AggregationsCreditTotal { get; set; }

		[DisplayName("Valor de Debito Total")]
		public decimal AggregationsDebitTotal { get; set; }
				
		
	}
}
