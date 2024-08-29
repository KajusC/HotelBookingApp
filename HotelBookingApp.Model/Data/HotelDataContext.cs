using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Entities.ManyToMany;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingApp.Data.Data
{
    public class HotelDataContext : DbContext
    {
        public HotelDataContext(DbContextOptions<HotelDataContext> options) : base(options) { }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        // Many-to-many relationships
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<FoodHotel> FoodHotels { get; set; }
        public DbSet<RoomOrder> RoomOrders { get; set; }
        public DbSet<RoomHotel> RoomHotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define many-to-many relationships
            modelBuilder.Entity<FoodOrder>()
                .HasKey(fo => new { fo.Id, fo.FoodId, fo.OrderId });
            modelBuilder.Entity<FoodOrder>()
                .Property(fo => fo.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RoomOrder>()
                .HasKey(ro => new { ro.Id, ro.RoomId, ro.OrderId });
            modelBuilder.Entity<RoomOrder>()
                .Property(ro => ro.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FoodHotel>()
                .HasKey(fh => new { fh.Id, fh.FoodId, fh.HotelId });
            modelBuilder.Entity<FoodHotel>()
                .Property(fh => fh.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RoomHotel>()
                .HasKey(rh => new { rh.Id, rh.RoomId, rh.HotelId });
            modelBuilder.Entity<RoomHotel>()
                .Property(rh => rh.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FoodOrder>()
                .HasOne(fo => fo.Food)
                .WithMany(f => f.FoodOrders)
                .HasForeignKey(fo => fo.FoodId);

            modelBuilder.Entity<FoodOrder>()
                .HasOne(fo => fo.Order)
                .WithMany(o => o.FoodOrders)
                .HasForeignKey(fo => fo.OrderId);

            modelBuilder.Entity<FoodHotel>()
                .HasOne(fh => fh.Food)
                .WithMany(f => f.FoodHotels)
                .HasForeignKey(fh => fh.FoodId);

            modelBuilder.Entity<FoodHotel>()
                .HasOne(fh => fh.Hotel)
                .WithMany(h => h.HotelFoods)
                .HasForeignKey(fh => fh.HotelId);

            modelBuilder.Entity<RoomHotel>()
                .HasOne(rh => rh.Room)
                .WithMany(r => r.RoomHotels)
                .HasForeignKey(rh => rh.RoomId);

            modelBuilder.Entity<RoomHotel>()
                .HasOne(rh => rh.Hotel)
                .WithMany(h => h.HotelRooms)
                .HasForeignKey(rh => rh.HotelId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId);

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Orders)
                .WithOne(o => o.Hotel)
                .HasForeignKey(o => o.HotelId);
        }
    }
}
