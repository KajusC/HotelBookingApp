using HotelBookingApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Model.Data;

public class HotelDataContext : DbContext
{

    public HotelDataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodCategory> FoodCategories { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .HasOne(r => r.RoomType)
            .WithMany(rt => rt.Rooms)
            .HasForeignKey(r => r.RoomTypeId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Room)
            .WithMany(r => r.Orders)
            .HasForeignKey(o => o.RoomId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Food)
            .WithMany(f => f.Orders)
            .HasForeignKey(o => o.FoodId);

        modelBuilder.Entity<Food>()
            .HasOne(f => f.FoodCategory)
            .WithMany(fc => fc.Foods)
            .HasForeignKey(f => f.FoodCategoryId);
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.Rooms)
            .WithOne(r => r.Hotel)
            .HasForeignKey(r => r.HotelId);
    }
}