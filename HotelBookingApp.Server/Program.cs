using HotelBookingApp.Business;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Business.Services;
using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Interfaces.ManyToMany;
using HotelBookingApp.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelBookingApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var Configuration = builder.Configuration;

            builder.Services.AddCors();

            builder.Services.AddDbContext<HotelDataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("HotelConnection"), b => b.MigrationsAssembly("HotelBookingApp.Server")));
            builder.Services.AddDbContext<UserDataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("UserConnection"), b => b.MigrationsAssembly("HotelBookingApp.Server")));

            builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<UserDataContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure HTTPS
                options.Cookie.SameSite = SameSiteMode.Strict; // CSRF protection
                options.LoginPath = "/user/login";
                options.LogoutPath = "/user/logout";
                options.AccessDeniedPath = "/user/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // Extract the token from the cookie
                        context.Token = context.Request.Cookies["authToken"];
                        return Task.CompletedTask;
                    }
                };
            });

            builder.Services.AddScoped<ITokenService, TokenService>(provider => new TokenService(Configuration["Jwt:Key"], Configuration["Jwt:Issuer"], Configuration["Jwt:Audience"]));


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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }

    }
}