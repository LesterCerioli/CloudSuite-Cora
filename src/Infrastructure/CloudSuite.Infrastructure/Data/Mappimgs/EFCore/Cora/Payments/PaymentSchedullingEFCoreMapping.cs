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
	public class PaymentSchedullingEFCoreMapping : IEntityTypeConfiguration<PaymentScheduling>
	{
		public void Configure(EntityTypeBuilder<PaymentScheduling> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Amount)
				.HasColumnName("amount")
				.HasColumnType("decimal")
				.IsRequired();

			builder.Property(x => x.DigitableLine)
				.HasColumnName("digitableline")
				.HasColumnType("varchar(50")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(x => x.ScheduleAt)
				.HasColumnName("scheduleat")
				.HasColumnType("datetime")
				.IsRequired();

			builder.Property(x => x.PaymentStatus)
				.HasColumnName("paymentstatus")
				.HasColumnType("varchar(40")
				.HasMaxLength(40)
				.IsRequired();

			builder.Property(x => x.Code)
				.HasColumnName("code")
				.HasColumnType("varchar(60")
				.HasMaxLength(60)
				.IsRequired();

			builder.Property(x => x.CreatedAt)
				.HasColumnName("createdat")
				.HasColumnType("datetime")
				.IsRequired();
		}
	}
}
