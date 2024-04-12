using CloudSuite.Modules.Cora.Domain.Models.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Cora.Payments
{
	public class BoletiEFCoreMapping : IEntityTypeConfiguration<Boleto>
	{
		public void Configure(EntityTypeBuilder<Boleto> builder)
		{
			builder.HasKey(w => w.Id);

			builder.Property(w => w.AmountTotal)
				.HasColumnName("amount_total")
				.HasColumnType("varchar(40)")
				.HasMaxLength(40)
				.IsRequired();

			builder.Property(w => w.Status)
				.HasColumnName("status")
				.HasColumnType("vachar(20)")
				.HasMaxLength(20)
				.IsRequired();

			builder.Property(w => w.Code)
				.HasColumnName("code")
				.HasColumnType("int")
				.IsRequired();

			builder.Property(w => w.CreatedAt)
				.HasColumnName("created_at")
				.HasColumnType("datetime")
				.IsRequired();

			builder.Property(w => w.TotalPaid)
				.HasColumnName("total_paid")
				.HasColumnType("decimal")
				.IsRequired();
		}
	}
}
