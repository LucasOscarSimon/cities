namespace Entities.DataTransferObjects
{
    public class UserWithoutIdForCreateDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int Document { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AddCitizenDetails { get; set; }
    }
}