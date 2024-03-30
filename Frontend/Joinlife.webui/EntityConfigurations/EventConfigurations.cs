using Joinlife.webui.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joinlife.webui.EntityConfigurations
{
    public sealed class EventConfigurations : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);

            builder.Property(x => x.Description)
                .HasMaxLength(256);
        }
    }
}