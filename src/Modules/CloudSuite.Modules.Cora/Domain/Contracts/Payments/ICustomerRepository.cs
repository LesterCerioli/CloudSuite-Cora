using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Domain.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts.Payments
{
	public interface ICustomerRepository
	{
		Task<Customer> GetByCnpj(Cnpj cnpj);

		Task<Customer> GetBySocialReason(string socialReason);

		Task<IEnumerable<Customer>> GetList();

		Task Add(Customer customer);

		void Update(Customer customer);

		void Renove(Customer customer);
	}
}
