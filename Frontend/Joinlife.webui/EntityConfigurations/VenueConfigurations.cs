using Joinlife.webui.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joinlife.webui.EntityConfigurations
{
    public sealed class VenueConfigurations : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(x => x.Line)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}