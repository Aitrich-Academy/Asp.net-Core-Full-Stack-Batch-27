using Microsoft.EntityFrameworkCore;
using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Data
{
    public class PawConnectDbContext : DbContext
    {
        public PawConnectDbContext(DbContextOptions<PawConnectDbContext> options)
            : base(options)
        {
        }

        // -------------------------
        //       DB SETS
        // -------------------------

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; } = null!;
        public DbSet<FavoritePet> FavoritePets { get; set; } = null!;
        public DbSet<PetCareService> PetCareServices { get; set; } = null!;
        public DbSet<Shelter> Shelters { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<SurrenderRequest> SurrenderRequests { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UNIQUE: A user can favorite a pet only once
            modelBuilder.Entity<FavoritePet>()
                .HasIndex(f => new { f.UserId, f.PetId })
                .IsUnique();

            // RELATIONS: User → Pets
            modelBuilder.Entity<User>()
                .HasMany(u => u.Pets)
                .WithOne(p => p.Owner)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            // RELATIONS: User → AdoptionRequests
            modelBuilder.Entity<User>()
                .HasMany(u => u.AdoptionRequests)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // RELATIONS: Pet → AdoptionRequests
            modelBuilder.Entity<Pet>()
                .HasMany(p => p.AdoptionRequests)
                .WithOne(a => a.Pet)
                .HasForeignKey(a => a.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            // RELATION: Shelter → Services
            modelBuilder.Entity<Shelter>()
                .HasMany(s => s.Services)
                .WithOne(sv => sv.Shelter)
                .HasForeignKey(sv => sv.ShelterId)
                .OnDelete(DeleteBehavior.NoAction);

            // RELATION: FavoritePet → Pet
            modelBuilder.Entity<FavoritePet>()
                .HasOne(f => f.Pet)
                .WithMany(p => p.FavoritedBy)
                .HasForeignKey(f => f.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            // RELATION: Notification → User
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
