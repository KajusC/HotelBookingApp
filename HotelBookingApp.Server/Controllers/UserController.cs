using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userManager.Users.ToListAsync();

        var userDtos = users.Select(user => new
        {
            user.Id,
            user.UserName,
            user.FirstName,
            user.LastName,
            user.Email,
        });

        return Ok(userDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user == null)
        {
            return NotFound();
        }

        var userDto = new
        {
            user.Id,
            user.UserName,
            user.FirstName,
            user.LastName,
            user.Email,
        };

        return Ok(userDto);
    }
}