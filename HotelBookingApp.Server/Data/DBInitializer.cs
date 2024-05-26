using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            await using var context = new HotelDataContext(
                serviceProvider.GetRequiredService<DbContextOptions<HotelDataContext>>());
            await context.Database.EnsureCreatedAsync();

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
                    FirstName = "Mono",
                    LastName = "Chrome",
                    UserName = "Admin",
                    Email = "Mon@a.c",
                    Password = "Password123!",

                    // Other properties can be set as needed
                },
                new User
                {
                    Id = 2,
                    FirstName = "User",
                    LastName = "Name",
                    UserName = "User",
                    Email = "UsN@usr.e",
                    Password = "Password123!",
                    // Other properties can be set as needed
                }
            };

            // Seed other data
            var hotels = new[]
            {
                new Hotel { Name = "Hotel One", Address = "789 Pine St", City = "Big City", Country = "USA", PhoneNumber = "1111111111", Email = "contact@hotelone.com", Website = "www.hotelone.com", Description = "A luxurious hotel.", ImageUrl = @"https://cdn.britannica.com/96/115096-050-5AFDAF5D/Bellagio-Hotel-Casino-Las-Vegas.jpg" },
                new Hotel { Name = "Hotel Two", Address = "123 Oak St", City = "Small Town", Country = "USA", PhoneNumber = "2222222222", Email = "contact@hoteltwo.com", Website = "www.hoteltwo.com", Description = "A cozy hotel.", ImageUrl = @"https://media.istockphoto.com/id/119926339/photo/resort-swimming-pool.jpg?s=612x612&w=0&k=20&c=9QtwJC2boq3GFHaeDsKytF4-CavYKQuy1jBD2IRfYKc=" }
            };

            var roomTypes = new[]
            {
                new RoomType { Id = 1, Name = "Single", Rooms = new List<Room>()},
                new RoomType { Id = 2, Name = "Double", Rooms = new List<Room>()},
                new RoomType { Id = 3, Name = "Suite", Rooms = new List<Room>()}
            };

            var rooms = new[]
            {
                new Room { Name = "Room One", Description = "A single room.", Price = 100, Capacity = 1, IsBooked = false, RoomTypeId = 1 },
                new Room { Name = "Room Two", Description = "A double room.", Price = 200, Capacity = 2, IsBooked = false, RoomTypeId = 2 },
                new Room { Name = "Room Three", Description = "A single room.", Price = 100, Capacity = 1, IsBooked = false, RoomTypeId = 1 },
                new Room { Name = "Room Four", Description = "A double room.", Price = 200, Capacity = 2, IsBooked = false,  RoomTypeId = 3 }
            };
            var foods = new[]
            {
                new Food { Name = "Breakfast", Description = "Eggs n bacon", Price = 10, ImageUrl = @"https://images.services.kitchenstories.io/gxInWDQniM21aQiVgvnXmDrMnvo=/3840x0/filters:quality(85)/images.kitchenstories.io/communityImages/f4604e05f6a9eaca99afddd69e849005_c02485d4-0841-4de6-b152-69deb38693f2.jpg"},
                new Food { Name = "Lunch", Description = "Grilled Chicken", Price = 15, ImageUrl = @"https://www.eatingwell.com/thmb/zSh86Cx-fybgBu5-baxombw1OiA=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/diy-taco-lunch-box-54f8791776b64900b285fbfc22a4f0bc.jpg"},
                new Food { Name = "Dinner", Description = "Steak", Price = 20, ImageUrl = @"https://randompicturegenerator.com/img/picture-generator/54e4d5454e51a514f1dc8460962e33791c3ad6e04e5074417d2d73dc9149c4_640.jpg"},
                new Food { Name = "Snack", Description = "Chips", Price = 5, ImageUrl = @"https://randompicturegenerator.com/img/picture-generator/54e9d1454a57ab14f1dc8460962e33791c3ad6e04e507440752f72d6914ac3_640.jpg"},
                new Food { Name = "Dessert", Description = "Ice Cream", Price = 8, ImageUrl = @"https://randompicturegenerator.com/img/picture-generator/54e1d4404353a814f1dc8460962e33791c3ad6e04e507440722d72d2954ec2_640.jpg"}
            };

            var foodHotels = new[]
            {
                new FoodHotel { FoodId = 1, HotelId = 1 },
                new FoodHotel { FoodId = 2, HotelId = 1 }
            };

            //add foodhotels to foods
            foreach (var food in foods)
            {
                food.FoodHotels.ToList().AddRange(foodHotels.Where(fh => fh.FoodId == food.Id));
            }
            //add foodhotels to hotels
            foreach (var hotel in hotels)
            {
                hotel.FoodHotels.ToList().AddRange(foodHotels.Where(fh => fh.HotelId == hotel.Id));
            }

            foreach (var roomType in roomTypes)
            {
                roomType.Rooms.ToList().AddRange(rooms.Where(r => r.RoomTypeId == roomType.Id));
            }

            var roomHotels = new[]
            {
                new RoomHotel { RoomId = 1, HotelId = 1 },
                new RoomHotel { RoomId = 2, HotelId = 1 },
                new RoomHotel { RoomId = 3, HotelId = 2 },
                new RoomHotel { RoomId = 4, HotelId = 2 }
            };

            //add roomhotels to rooms
            foreach (var room in rooms)
            {
                room.RoomHotels.ToList().AddRange(roomHotels.Where(rh => rh.RoomId == room.Id));
            }
            //add roomhotels to hotels
            foreach (var hotel in hotels)
            {
                hotel.RoomHotels.ToList().AddRange(roomHotels.Where(rh => rh.HotelId == hotel.Id));
            }

            context.RoomHotels.AddRange(roomHotels);
            context.FoodHotels.AddRange(foodHotels);
            context.Foods.AddRange(foods);
            context.RoomTypes.AddRange(roomTypes);
            context.Rooms.AddRange(rooms);
            context.Users.AddRange(users);
            context.Hotels.AddRange(hotels);
            await context.SaveChangesAsync();
        }
    }
}
