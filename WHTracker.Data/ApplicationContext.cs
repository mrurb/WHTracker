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
                .HasOne(c => c.corporation)
                .WithMany(g => g.DailyAggregateCorporations)
                .HasForeignKey(s => s.CorporationID);

            builder.Entity<Corporation>()
                .HasKey(k => k.CorporationId);
            builder.Entity<Corporation>()
                .Property(k => k.CorporationId)
                .ValueGeneratedNever();

            builder.Entity<Alliance>()
                .HasKey(k => k.AllianceId);
            builder.Entity<Alliance>()
                .Property(k => k.AllianceId)
                .ValueGeneratedNever();

        }

    }
}
