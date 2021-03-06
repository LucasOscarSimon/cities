﻿namespace Entities.DataTransferObjects
{
    public class CitizenDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Document { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public CityDto City { get; set; }
    }
}
