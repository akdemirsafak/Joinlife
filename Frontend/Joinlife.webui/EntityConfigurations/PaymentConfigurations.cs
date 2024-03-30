using Joinlife.webui.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joinlife.webui.EntityConfigurations
{
    public sealed class PaymentConfigurations : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}