using DubRep.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DubRep.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set relationships between entities

            modelBuilder.Entity<VoiceActor>()
                .HasMany(v => v.Roles)             // VoiceActor has many Roles
                .WithOne(r => r.VoiceActor)                 // Role has one VoiceActor
                .HasForeignKey(r => r.VoiceActorID)         // Foreign key is VoiceActorID in Role
                .IsRequired();                     // Can't have Role without VoiceActor

            modelBuilder.Entity<Series>()
                .HasMany(s => s.Cast)             // Series has many Roles (in Cast)
                .WithOne(r => r.Series)                 // Role has one Series
                .HasForeignKey(r => r.SeriesID)         // Foreign key is SeriesID in Role
                .IsRequired();                    // Can't have Role without Series
        }

        public DbSet<VoiceActor> VoiceActors { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
