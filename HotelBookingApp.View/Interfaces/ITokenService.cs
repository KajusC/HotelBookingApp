﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Business.Interfaces
{
    public interface ITokenService
    {
        Task<bool> ValidateToken(string token);
    }
}