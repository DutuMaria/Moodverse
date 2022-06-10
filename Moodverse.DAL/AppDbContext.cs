using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moodverse.DAL.Entities;
using Moodverse.DAL.EntitiesConfiguration;

namespace Moodverse.DAL
{
    public class AppDbContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<Ambience> Ambiences { get; set; }
        public DbSet<DailyQuote> DailyQuotes { get; set; }
        public DbSet<Streak> Streaks { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoListTask> ToDoListTasks { get; set; }
        //public DbSet<Timer> Timers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BackgroundConfiguration());
            modelBuilder.ApplyConfiguration(new AmbienceConfiguration());
            modelBuilder.ApplyConfiguration(new DailyQuoteConfiguration());
            modelBuilder.ApplyConfiguration(new StreakConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoListConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoListTaskConfiguration());
            //modelBuilder.ApplyConfiguration(new TimerConfiguration());
        }
    }
}
