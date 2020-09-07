using Microsoft.EntityFrameworkCore;

using System;

using WHTracker.Data.Models;

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
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Alliance> Alliances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Killmails>()
                .HasKey(c => c.KiilmailID);

            builder.Entity<DailyAggregateAlliance>()
                .HasKey(k => k.DailyAggregateAllianceID);

            builder.Entity<DailyAggregateAlliance>()
                .HasOne(c => c.Alliance)
                .WithMany(g => g.dailyAggregateAlliances)
                .HasForeignKey(s => s.AllianceID);

            builder.Entity<DailyAggregateCorporation>()
                .HasKey(k => k.DailyAggregateCorporationID);
            builder.Entity<DailyAggregateCorporation>()
                .HasOne(c => c.Corporation)
                .WithMany(g => g.dailyAggregateCorporations)
                .HasForeignKey(s => s.CorporationID);

            builder.Entity<Corporation>()
                .HasKey(k => k.CorporationID);
            builder.Entity<Alliance>()
                .HasKey(k => k.AllianceID);

        }

    }
}
