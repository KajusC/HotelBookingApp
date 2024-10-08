﻿using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Business.DTO;

public class RoomDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Capacity { get; set; }
    public bool IsBooked { get; set; }
    public int RoomTypeId { get; set; }
    
    public ICollection<int> RoomHotelIds { get; set; } = new List<int>();
    public ICollection<int> RoomOrderIds { get; set; } = new List<int>();
}