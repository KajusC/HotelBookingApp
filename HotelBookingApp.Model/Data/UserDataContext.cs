using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Entities.ManyToMany;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Data
{
    public class UserDataContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<User> Users { get; set; }

        public UserDataContext(DbContextOptions<UserDataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<int>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

            modelBuilder.Ignore<Food>();
            modelBuilder.Ignore<Hotel>();
            modelBuilder.Ignore<Order>();
            modelBuilder.Ignore<Room>();
            modelBuilder.Ignore<RoomType>();
            modelBuilder.Ignore<FoodHotel>();
            modelBuilder.Ignore<FoodOrder>();
            modelBuilder.Ignore<RoomHotel>();
            modelBuilder.Ignore<RoomOrder>();
        }
    }
}