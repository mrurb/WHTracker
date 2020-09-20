using Microsoft.EntityFrameworkCore;

using System;

using WHTracker.Data.Models;
#nullable disable
namespace WHTracker.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Killmails> Killmails { get; set; }
        public DbSet<DailyAggregateCorporation> DailyAggregateCorporations { get; set; }
        public DbSet<DailyAggregateAlliance> DailyAggregateAlliances { get; set; }
        public DbSet<MonthlyAggregateCorporation> MonthlyAggregateCorporations { get; set; }
        public DbSet<MonthlyAggregateAlliance> MonthlyAggregateAlliances { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Alliance> Alliances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Killmails>()
                .HasKey(c => c.KiilmailId);
            builder.Entity<Killmails>()
                .Property(k => k.KiilmailId)
                .ValueGeneratedNever();

            builder.Entity<DailyAggregateAlliance>()
                .HasKey(k => k.DailyAggregateAllianceID);

            builder.Entity<DailyAggregateAlliance>()
                .HasOne(c => c.Alliance)
                .WithMany(g => g.DailyAggregateAlliances)
                .HasForeignKey(s => s.AllianceId);

            builder.Entity<DailyAggregateCorporation>()
                .HasKey(k => k.DailyAggregateCorporationId);
            builder.Entity<DailyAggregateCorporation>()
                .HasOne(c => c.Corporation)
                .WithMany(g => g.DailyAggregateCorporations)
                .HasForeignKey(s => s.CorporationID);

            builder.Entity<MonthlyAggregateAlliance>()
                .HasKey(k => k.MonthlyAggregateAllianceID);

            builder.Entity<MonthlyAggregateAlliance>()
                .HasOne(c => c.Alliance)
                .WithMany(g => g.MonthlyAggregateAlliances)
                .HasForeignKey(s => s.AllianceId);

            builder.Entity<MonthlyAggregateCorporation>()
                .HasKey(k => k.MonthlyAggregateCorporationId);
            builder.Entity<MonthlyAggregateCorporation>()
                .HasOne(c => c.Corporation)
                .WithMany(g => g.MonthlyAggregateCorporations)
                .HasForeignKey(s => s.CorporationID);

            builder.Entity<Corporation>()
                .HasKey(k => k.Id);
            builder.Entity<Corporation>()
                .Property(k => k.Id)
                .ValueGeneratedNever();

            builder.Entity<Alliance>()
                .HasKey(k => k.Id);
            builder.Entity<Alliance>()
                .Property(k => k.Id)
                .ValueGeneratedNever();

        }

    }
}
