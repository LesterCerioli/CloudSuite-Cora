using CloudSuite.Infrastructure.Data.Cora.Context;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora
{
	public class ExtractRepository : IExtractRepository
	{
		protected readonly CoraDbContext Db;
		protected readonly DbSet<Extract> DbSet;

		public ExtractRepository(CoraDbContext context)
		{
			Db = context;
			DbSet = context.Extracts;
		}

		public async Task Add(Extract extract)
		{
			await Task.Run(() =>
			{
				DbSet.Add(extract);
				Db.SaveChangesAsync();
			});
		}

		public async Task<Extract> GetByEndDate(DateTimeOffset endDate)
		{
			return await DbSet.FirstOrDefaultAsync(e => e.EndDate == endDate);
		}

		public async Task<Extract> GetByEntryAmount(decimal entryAmount)
		{
			return await DbSet.FirstOrDefaultAsync(e => e.EntryAmount == entryAmount);
		}

		public async Task<Extract> GetByStartDate(DateTimeOffset startDate)
		{
			return await DbSet.FirstOrDefaultAsync(e => e.StartDate == startDate);
		}

		public async Task<IEnumerable<Extract>> GetList()
		{
			return await DbSet.ToListAsync();
		}

		public void Remove(Extract extract)
		{
			DbSet.Remove(extract);
		}

		public void Update(Extract extract)
		{
			DbSet.Update(extract);
		}

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
