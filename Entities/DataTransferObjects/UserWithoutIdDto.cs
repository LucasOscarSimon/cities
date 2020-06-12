namespace Entities.DataTransferObjects
{
    public class UserWithoutIdDto
    {
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}