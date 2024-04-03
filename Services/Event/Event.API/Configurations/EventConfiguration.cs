using Event.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Event.API.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Eventy>
    {
        public void Configure(EntityTypeBuilder<Eventy> builder)
        {
            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(32);

            builder.Property(x => x.Description)
                .HasMaxLength(255);
            builder.Property(x => x.VenueId)
                .IsRequired();
        }
    }
}