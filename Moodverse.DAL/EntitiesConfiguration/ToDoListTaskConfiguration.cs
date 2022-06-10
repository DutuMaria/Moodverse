using System;
using Moodverse.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodverse.DAL.EntitiesConfiguration
{
    public class ToDoListTaskConfiguration : IEntityTypeConfiguration<ToDoListTask>
    {
        public void Configure(EntityTypeBuilder<ToDoListTask> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Done)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(p => p.ToDoList)
                .WithMany(p => p.ToDoListTasks)
                .HasForeignKey(p => p.ToDoListId);
        }
    }
}
