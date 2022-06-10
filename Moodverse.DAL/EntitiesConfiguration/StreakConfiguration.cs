using System;
using Moodverse.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodverse.DAL.EntitiesConfiguration
{
    public class StreakConfiguration : IEntityTypeConfiguration<Streak>
    {
        public void Configure(EntityTypeBuilder<Streak> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.NumberOfDays)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.LastDate)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
