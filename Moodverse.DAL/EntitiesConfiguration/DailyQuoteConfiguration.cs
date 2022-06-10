using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moodverse.DAL.Entities;

namespace Moodverse.DAL.EntitiesConfiguration
{
    public class DailyQuoteConfiguration : IEntityTypeConfiguration<DailyQuote>
    {
        public void Configure(EntityTypeBuilder<DailyQuote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Author)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Message)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();


        }
    }
}
