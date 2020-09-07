using Microsoft.EntityFrameworkCore;

using System;

using WHTracker.Data.Models;

namespace WHTracker.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Killmails> Killmails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Killmails>()
                .HasKey(c => c.KiilmailID);
                
        }

    }
}
