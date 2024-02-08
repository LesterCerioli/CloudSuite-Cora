using CloudSuite.Infrastructure.Data.Cora.Context;
using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using CloudSuite.Modules.Cora.Domain.Models.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora.Payments
{
	public class CustomerRepository : ICustomerRepository
	{
        protected readonly CoraDbContext Db;
        protected readonly DbSet<Customer> DbSet;

        public CustomerRepository(CoraDbContext db, DbSet<Customer> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }

        public async Task Add(Customer customer)
		{
            await Task.Run(() =>
            {
                DbSet.Add(customer);
                Db.SaveChanges();
            });
        }

		public async Task<Customer> GetByCnpj(Cnpj cnpj)
		{
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Cnpj == cnpj);
        }

		public async Task<Customer> GetBySocialReason(string socialReason)
		{
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.SocialReason == socialReason);
        }

		public async Task<IEnumerable<Customer>> GetList()
		{
            return await DbSet.ToListAsync();
        }

		public void Renove(Customer customer)
		{
            DbSet.Remove(customer);
        }

		public void Update(Customer customer)
		{
            DbSet.Update(customer);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
