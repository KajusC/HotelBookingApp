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

        //many-to-many


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure keyless entity for IdentityUserLogin
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasNoKey();

            // Configure keyless entity for IdentityUserRole
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasNoKey();

            
            // Relationships

            modelBuilder.Entity<Food>()
                .HasMany(d => d.Hotels)
                .WithMany(f => f.Foods);
            modelBuilder.Entity<Food>()
                .HasMany(d => d.Orders)
                .WithMany(f => f.Foods);

            modelBuilder.Entity<Hotel>()
                .HasMany(d => d.Foods)
                .WithMany(f => f.Hotels);
            modelBuilder.Entity<Hotel>()
                .HasMany(d => d.Rooms)
                .WithMany(f => f.Hotels);

            modelBuilder.Entity<Order>()
                .HasMany(d => d.Foods)
                .WithMany(f => f.Orders);
            modelBuilder.Entity<Order>()
                .HasMany(d => d.Rooms)
                .WithMany(f => f.Orders);
            modelBuilder.Entity<Order>()
                .HasOne(d => d.User)
                .WithMany(f => f.Orders);
            modelBuilder.Entity<Order>()
                .HasOne(d => d.Hotel)
                .WithMany()
                .HasForeignKey(d => d.HotelId);

            modelBuilder.Entity<Room>()
                .HasOne(d => d.RoomType)
                .WithMany(f => f.Rooms);

            modelBuilder.Entity<Room>()
                .HasMany(d => d.Orders)
                .WithMany(f => f.Rooms);

            modelBuilder.Entity<Room>()
                .HasMany(d => d.Hotels)
                .WithMany(f => f.Rooms);


            modelBuilder.Entity<RoomType>()
                .HasMany(d => d.Rooms)
                .WithOne(f => f.RoomType);


        }
    }
}