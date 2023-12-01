using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using CloudSuite.Modules.Cora.Domain.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora.Payments
{
	public class BoletoRepository : IBoletoRepository
	{
		public Task Add(Boleto boleto)
		{
			throw new NotImplementedException();
		}

		public Task<Boleto> GetByAmountTotal(string amountTotal)
		{
			throw new NotImplementedException();
		}

		public Task<Boleto> GetByCode(string code)
		{
			throw new NotImplementedException();
		}

		public Task<Boleto> GetByTotalPaid(decimal totalPaid)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Boleto>> GetList()
		{
			throw new NotImplementedException();
		}

		public void Remove(Boleto boleto)
		{
			throw new NotImplementedException();
		}

		public void Update(Boleto boleto)
		{
			throw new NotImplementedException();
		}
	}
}
