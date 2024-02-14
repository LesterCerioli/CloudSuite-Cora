using CloudSuite.Infrastructure.Data.Cora.Context;
using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using CloudSuite.Modules.Cora.Domain.Models.Payments;
using Microsoft.EntityFrameworkCore;


namespace CloudSuite.Infrastructure.Data.Repositories.Cora.Payments
{
	public class BoletoRepository : IBoletoRepository
	{
        protected readonly CoraDbContext Db;
        protected readonly DbSet<Boleto> DbSet;

        public BoletoRepository(CoraDbContext db, DbSet<Boleto> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }

        public async Task Add(Boleto boleto)
		{
            await Task.Run(() => {
                DbSet.Add(boleto);
                Db.SaveChanges();
            });
        }

		public async Task<Boleto> GetByAmountTotal(string amountTotal)
		{
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.AmountTotal == amountTotal);
        }

		public async Task<Boleto> GetByCode(string code)
		{
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Code == code);
        }

		public async Task<Boleto> GetByTotalPaid(decimal totalPaid)
		{
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.TotalPaid == totalPaid);
        }

		public async Task<IEnumerable<Boleto>> GetList()
		{
            return await DbSet.ToListAsync();
        }

		public void Remove(Boleto boleto)
		{
            DbSet.Remove(boleto);
        }

		public void Update(Boleto boleto)
		{
            DbSet.Update(boleto);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
