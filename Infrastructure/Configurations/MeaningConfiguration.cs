using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Configurations
{
    internal class MeaningConfiguration : IEntityTypeConfiguration<Meaning>
    {
        public void Configure(EntityTypeBuilder<Meaning> builder)
        {
            builder.ToTable("Meanings");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Type)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.Definition)
                .IsRequired()
                .HasMaxLength(1024);

            builder.Property(s => s.Example)
                .IsRequired()
                .HasMaxLength(1024);

            builder.Property(s => s.Phonetics)
                .IsRequired()
                .HasMaxLength(180);

            builder.Property(s => s.PhoneticsAudio)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
