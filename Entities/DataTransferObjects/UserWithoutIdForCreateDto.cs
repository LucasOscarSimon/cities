﻿namespace Entities.DataTransferObjects
{
    public class UserWithoutIdForCreateDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}