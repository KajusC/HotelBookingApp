using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Data.Models;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}