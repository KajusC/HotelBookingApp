using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business.DTO;

public class CustomerModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }

    public ICollection<int>? OrderIds { get; set; }

}