﻿using HotelBookingApp.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelBookingApp.Business.DTO;

public class UserModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }

    public ICollection<int>? OrderIds { get; set; }

}