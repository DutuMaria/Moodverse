using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moodverse.DAL.Entities;

namespace Moodverse.DAL.EntitiesConfiguration
{
    public class AmbienceConfiguration : IEntityTypeConfiguration<Ambience>
    {
        public void Configure(EntityTypeBuilder<Ambience> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Sound)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.AmbienceName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
