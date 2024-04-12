using CloudSuite.Infrastructure.Data.Cora.Context;
using CloudSuite.Modules.Cora.Domain.Contracts.Payments;
using CloudSuite.Modules.Cora.Domain.Models.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora.Payments
{
	public class PaymentSchedullingRepository : IPaymentSchedulingRepository
	{
		protected readonly CoraDbContext Db;
		protected readonly DbSet<PaymentScheduling> DbSet;


		public PaymentSchedullingRepository(CoraDbContext context)
		{
			Db = context;
			DbSet = context.PaymentSchedullings;
		}



		public async Task Add(PaymentScheduling paymentScheduling)
		{
			await Task.Run(() =>
			{
				DbSet.Add(paymentScheduling);
				Db.SaveChangesAsync();
			});
		}

		public async Task<PaymentScheduling> GetByAmount(string amount)
		{
			if (!decimal.TryParse(amount, out decimal amountValue))
			{
				// Handle invalid input or return null
				return null;
			}

			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Amount == amountValue);
		}

		public async Task<PaymentScheduling> GetByCode(string code)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Code == code);
		}

		public async Task<PaymentScheduling> GetByDigitableLine(string digitableLine)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.DigitableLine == digitableLine);
		}

		public async Task<PaymentScheduling> GetByScheduleAt(string scheduleAt)
		{
			if (!DateTime.TryParse(scheduleAt, out DateTime scheduleAtValue))
			{
				// Handle invalid input or return null
				return null;
			}

			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.ScheduleAt == scheduleAtValue);
		}

		public void Remove(PaymentScheduling paymentScheduling)
		{
			DbSet.Remove(paymentScheduling);
		}

		public void Update(PaymentScheduling paymentScheduling)
		{
			DbSet.Update(paymentScheduling);
		}
	}
}
