using CloudSuite.Modules.Cora.Domain.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts.Payments
{
	public interface IBoletoRepository
	{
		Task<Boleto> GetByAmountTotal(string amountTotal);

		Task<Boleto> GetByCode(string code);

		Task<Boleto> GetByTotalPaid(decimal totalPaid);

		Task<IEnumerable<Boleto>> GetList();

		Task Add(Boleto boleto);

		void Update(Boleto boleto);

		void Remove(Boleto boleto);
	}
}
