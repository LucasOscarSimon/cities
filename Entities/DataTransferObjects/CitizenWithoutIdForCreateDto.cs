﻿using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CitizenWithoutIdForCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Document { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? CityId { get; set; }
    }
}