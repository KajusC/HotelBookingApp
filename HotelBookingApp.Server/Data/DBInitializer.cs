using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Models;
using HotelBookingApp.Data.Data;

namespace HotelBookingApp.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new HotelDataContext(
                serviceProvider.GetRequiredService<DbContextOptions<HotelDataContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Users.Any())
                {
                    return; // DB has been seeded
                }


                // Create roles
                var roles = new[] { "User", "Admin" };

                // Create users
                var users = new[]
                {
                    new User
                    {
                        Id = 1,
                        UserName = "Admin",
                        Email = " ",
                        PasswordHash = "Password123!",

                        // Other properties can be set as needed
                    },
                    new User
                    {
                        Id = 2,
                        UserName = "User",
                        Email = " ",
                        PasswordHash = "Password123!",
                        // Other properties can be set as needed
                    }
                };

                // Seed other data
                var hotels = new[]
                {
                    new Hotel { Name = "Hotel One", Address = "789 Pine St", City = "Big City", Country = "USA", PhoneNumber = "1111111111", Email = "contact@hotelone.com", Website = "www.hotelone.com", Description = "A luxurious hotel.", ImageUrl = "image_url_one" },
                    new Hotel { Name = "Hotel Two", Address = "123 Oak St", City = "Small Town", Country = "USA", PhoneNumber = "2222222222", Email = "contact@hoteltwo.com", Website = "www.hoteltwo.com", Description = "A cozy hotel.", ImageUrl = "image_url_two" }
                };

                context.Users.AddRange(users);
                context.Hotels.AddRange(hotels);
                await context.SaveChangesAsync();
            }
        }
    }
}
