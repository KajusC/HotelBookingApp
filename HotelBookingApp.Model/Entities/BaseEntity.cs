using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Data.Entities;

public class BaseEntity
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
}