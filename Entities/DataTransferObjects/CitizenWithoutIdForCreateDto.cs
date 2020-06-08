﻿using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CitizenWithoutIdForCreateDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? CityId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}