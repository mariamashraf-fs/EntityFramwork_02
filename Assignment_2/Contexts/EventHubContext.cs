using Assignment_2.Configurations;
using Assignment_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Contexts
{
    public class EventHubContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-15UIE3F\\SQLEXPRESS;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                entity.Property(p => p.Biography)
                      .HasMaxLength(500);

                entity.Property(p => p.Website)
                      .HasMaxLength(300);

                entity.Property(p => p.Logo)
                      .HasMaxLength(300);

                entity.HasOne(p => p.Organizer)
                      .WithOne(o => o.OrganizerProfile)
                      .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                      .IsRequired();
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventHubContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
