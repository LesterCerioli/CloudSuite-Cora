﻿using CloudSuite.Modules.Cora.Domain.Models.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Cora.Payments
{
	public class PagamentoEFCoreMapping : IEntityTypeConfiguration<Pagamento>
	{
		public void Configure(EntityTypeBuilder<Pagamento> builder)
		{
			throw new NotImplementedException();
		}
	}
}