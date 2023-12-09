using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using CloudSuite.Modules.Cora.Domain.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora.Payments
{
	public class CustomerRepository : ICustomerRepository
	{
		public Task Add(Customer customer)
		{
			throw new NotImplementedException();
		}

		public Task<Customer> GetByCnpj(Cnpj cnpj)
		{
			throw new NotImplementedException();
		}

		public Task<Customer> GetBySocialReason(string socialReason)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Customer>> GetList()
		{
			throw new NotImplementedException();
		}

		public void Renove(Customer customer)
		{
			throw new NotImplementedException();
		}

		public void Update(Customer customer)
		{
			throw new NotImplementedException();
		}
	}
}
