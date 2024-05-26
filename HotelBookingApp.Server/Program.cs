using System.Text;
using HotelBookingApp.Business;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Business.Services;
using HotelBookingApp.Data;
using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Interfaces.ManyToMany;
using HotelBookingApp.Data.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Add this using directive

namespace HotelBookingApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            // Add services to the container.
            builder.Services.AddDbContext<HotelDataContext>(options =>
                options.UseInMemoryDatabase("HotelBookingContext"));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IFoodRepository, FoodRepository>();
            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            builder.Services.AddScoped<IFoodHotelRepository, FoodHotelRepository>();
            builder.Services.AddScoped<IFoodOrderRepository, FoodOrderRepository>();
            builder.Services.AddScoped<IRoomOrderRepository, RoomOrderRepository>();
            builder.Services.AddScoped<IRoomHotelRepository, RoomHotelRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IFoodService, FoodService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            builder.Services.AddLogging();
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();



            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("https://localhost:5173", "http://localhost:5188", "https://localhost:7103")
                .AllowCredentials());


            app.UseDefaultFiles();
            app.UseStaticFiles();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();



        }

    }
}