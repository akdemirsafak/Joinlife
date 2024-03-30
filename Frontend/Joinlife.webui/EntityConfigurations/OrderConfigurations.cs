using Joinlife.webui.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joinlife.webui.EntityConfigurations
{
    public sealed class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}