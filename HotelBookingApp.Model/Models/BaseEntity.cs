using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Model.Models;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}