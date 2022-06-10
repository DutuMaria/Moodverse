using Moodverse.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodverse.DAL.EntitiesConfiguration
{
    public class BackgroundConfiguration : IEntityTypeConfiguration<Background>
    {
        public void Configure(EntityTypeBuilder<Background> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Image)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.BackgroundName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            
        }
    }
}
