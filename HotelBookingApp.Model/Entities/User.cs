using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingApp.Data.Entities;

public class User : IdentityUser<int>, IUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public int? HotelId { get; set; }    
    public Hotel? Hotel { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}