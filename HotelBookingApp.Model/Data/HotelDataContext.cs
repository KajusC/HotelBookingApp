using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Entities.ManyToMany;
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

        //many to many relationship
        public DbSet<FoodOrder> FoodOrders{ get; set; }
        public DbSet<FoodHotel> FoodHotels { get; set; }
        public DbSet<RoomOrder> RoomOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();

            #region ManyToMany
            modelBuilder.Entity<FoodOrder>()
                .HasKey(fo => new { fo.FoodId, fo.OrderId });
            modelBuilder.Entity<FoodHotel>()
                .HasKey(fh => new { fh.FoodId, fh.HotelId });
            modelBuilder.Entity<RoomOrder>()
                .HasKey(ro => new { ro.RoomId, ro.OrderId });

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
                .WithMany(h => h.FoodHotels)
                .HasForeignKey(fh => fh.HotelId);

            modelBuilder.Entity<RoomOrder>()
                .HasOne(ro => ro.Room)
                .WithMany(r => r.RoomOrders)
                .HasForeignKey(ro => ro.RoomId);
            modelBuilder.Entity<RoomOrder>()
                .HasOne(ro => ro.Order)
                .WithMany(o => o.RoomOrders)
                .HasForeignKey(ro => ro.OrderId);
            #endregion
            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Orders)
                .WithOne(o => o.Hotel)
                .HasForeignKey(o => o.HotelId);



            base.OnModelCreating(modelBuilder);
        }

    }
}