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

                var roomTypes = new[]
                {
                    new RoomType { Id = 1, Name = "Single", Rooms = new List<Room>()},
                    new RoomType { Id = 2, Name = "Double", Rooms = new List<Room>()},
                    new RoomType { Id = 3, Name = "Suite", Rooms = new List<Room>()}
                };

                var rooms = new[]
                {
                    new Room { Name = "Room One", Description = "A single room.", Price = 100, Capacity = 1, IsBooked = false, HotelId = 1, RoomTypeId = 1 },
                    new Room { Name = "Room Two", Description = "A double room.", Price = 200, Capacity = 2, IsBooked = false, HotelId = 2, RoomTypeId = 2 },
                    new Room { Name = "Room Three", Description = "A single room.", Price = 100, Capacity = 1, IsBooked = false, HotelId = 1, RoomTypeId = 1 },
                    new Room { Name = "Room Four", Description = "A double room.", Price = 200, Capacity = 2, IsBooked = false, HotelId = 2, RoomTypeId = 3 }
                };
                var foods = new[]
                {
                    new Food { Name = "Breakfast", Description = "Eggs n bacon", Price = 10, ImageUrl = @"https://images.services.kitchenstories.io/gxInWDQniM21aQiVgvnXmDrMnvo=/3840x0/filters:quality(85)/images.kitchenstories.io/communityImages/f4604e05f6a9eaca99afddd69e849005_c02485d4-0841-4de6-b152-69deb38693f2.jpg"},
                    new Food { Name = "Lunch", Description = "Grilled Chicken", Price = 15, ImageUrl = @"https://www.eatingwell.com/thmb/zSh86Cx-fybgBu5-baxombw1OiA=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/diy-taco-lunch-box-54f8791776b64900b285fbfc22a4f0bc.jpg"},
                    new Food { Name = "Dinner", Description = "Steak", Price = 20, ImageUrl = @"https://randompicturegenerator.com/img/picture-generator/54e4d5454e51a514f1dc8460962e33791c3ad6e04e5074417d2d73dc9149c4_640.jpg"},
                    new Food { Name = "Snack", Description = "Chips", Price = 5, ImageUrl = @"https://randompicturegenerator.com/img/picture-generator/54e9d1454a57ab14f1dc8460962e33791c3ad6e04e507440752f72d6914ac3_640.jpg"},
                    new Food { Name = "Dessert", Description = "Ice Cream", Price = 8, ImageUrl = @"https://randompicturegenerator.com/img/picture-generator/54e1d4404353a814f1dc8460962e33791c3ad6e04e507440722d72d2954ec2_640.jpg"}
                };



                foreach (var roomType in roomTypes)
                {
                    roomType.Rooms.ToList().AddRange(rooms.Where(r => r.RoomTypeId == roomType.Id));
                }


                for (int i = 0; i < foods.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        foods[i].Hotels.Add(hotels[0]);
                    }
                    else
                    {
                        foods[i].Hotels.Add(hotels[1]);
                    }
                }

                foreach (var hotel in hotels)
                {
                    hotel.Foods.ToList().AddRange(foods.Where(f => f.Hotels.Contains(hotel)));
                }



                
                context.Foods.AddRange(foods);
                context.RoomTypes.AddRange(roomTypes);
                context.Rooms.AddRange(rooms);
                context.Users.AddRange(users);
                context.Hotels.AddRange(hotels);
                await context.SaveChangesAsync();
            }
        }
    }
}
