﻿
using CloudSuite.Infrastructure.Data.Cora.Context;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora
{
	public class AccountRepository : IAccountRepository
	{
		protected readonly CoraDbContext Db;
        protected readonly DbSet<Account> DbSet;

        public AccountRepository(CoraDbContext context) 
		{
			Db = context;
			DbSet = context.Accounts;
		}

		

		public async Task Add(Account account)
		{
            await Task.Run(() => {
                DbSet.Add(account);
                Db.SaveChanges();
            });

        }

		public async Task<Account> GetByAccountDigit(string accountDigit)
		{
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.AccountDigit == accountDigit);
		}

		public async Task<Account> GetByAccountNumber(string accountNumber)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.AccountNumber == accountNumber);
		}

		public async Task<Account> GetByAgency(string agency)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Agency == agency);
		}

		public async Task<Account> GetByBankCode(string bankCode)
		{
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.BankCode == bankCode);
        }

		public async Task<Account> GetByBankName(string bankName)
		{
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.BankName == bankName);
        }

		public async Task<IEnumerable<Account>> GetList()
		{
            return await DbSet.ToListAsync();
        }

		public void Remove(Account account)
		{
			DbSet.Remove(account);
		}

		public void Update(Account account)
		{
			DbSet.Update(account);
		}
	}
}
