﻿namespace Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public Citizen Citizen { get; set; }
    }
}