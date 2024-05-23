using HotelBookingApp.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Data
{
    public class HotelDataContext : DbContext
    {
        public HotelDataContext(DbContextOptions<HotelDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure keyless entity for IdentityUserLogin
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasNoKey();

            // Configure keyless entity for IdentityUserRole
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasNoKey();

            
            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Rooms)
                .WithMany(r => r.Orders);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Foods)
                .WithMany(f => f.Orders);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Hotel)
                .WithMany(h => h.Orders)
                .HasForeignKey(o => o.HotelId);

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Foods)
                .WithMany(o => o.Hotels);
        }
    }
}