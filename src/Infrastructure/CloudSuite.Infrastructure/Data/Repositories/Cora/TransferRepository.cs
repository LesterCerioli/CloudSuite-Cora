using CloudSuite.Infrastructure.Data.Cora.Context;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora
{
	public class TransferRepository : ITransferRepository
	{
		protected readonly CoraDbContext Db;
		protected readonly DbSet<Transfer> DbSet;

		public TransferRepository(CoraDbContext context)
		{
			Db = context;
			DbSet = context.Transfers;
		}

		public async Task Add(Transfer transfer)
		{
			await Task.Run(() =>
			{
				DbSet.Add(transfer);
				Db.SaveChangesAsync();
			});
		}

		public async Task<Transfer> GetByAmount(string amount)
		{
			return await DbSet.FirstOrDefaultAsync(k => k.Amoumt == amount);
		}

		public async Task<Transfer> GetByBankCodeRecipient(string bankCode)
		{
			return await DbSet.FirstOrDefaultAsync(k => k.BankCodeRecipient == bankCode);
		}

		public async Task<Transfer> GetByBranchNumberRecipient(string branchNumber)
		{
			return await DbSet.FirstOrDefaultAsync(k => k.BranchNumberRecipient == branchNumber);
		}

		public async Task<Transfer> GetByCategory(string category)
		{
			return await DbSet.FirstOrDefaultAsync(k => k.Category == category);
		}

		public async Task<Transfer> GetByCode(string code)
		{
			return await DbSet.FirstOrDefaultAsync(k => k.Code == code);
		}

		public async Task<Transfer> GetByScheduled(DateTimeOffset scheduled)
		{
			return await DbSet.FirstOrDefaultAsync(k => k.Scheduled == scheduled);
		}

		public async Task<Transfer> GetByStatus(string status)
		{
			return await DbSet.FirstOrDefaultAsync(k => k.Status == status);
		}

		public async Task<IEnumerable<Transfer>> GetList()
		{
			return await DbSet.ToListAsync();
			
		}

		public void Remove(Transfer transfer)
		{
			Db.Remove(transfer);
		}

		public void Update(Transfer transfer)
		{
			Db.Update(transfer);
		}

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
