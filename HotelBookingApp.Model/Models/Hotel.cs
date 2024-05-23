﻿namespace HotelBookingApp.Data.Models;

public class Hotel : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Food> Foods { get; set; } = new List<Food>();
}