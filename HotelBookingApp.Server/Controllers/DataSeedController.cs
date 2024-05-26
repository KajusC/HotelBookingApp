using HotelBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace HotelBookingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSeedController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSeedController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Route("seed")]
        public async Task<IActionResult> Seed()
        {
            await DbInitializer.InitializeAsync(_serviceProvider);
            return Ok(new { message = "Database seeded successfully." });
        }
    }
}