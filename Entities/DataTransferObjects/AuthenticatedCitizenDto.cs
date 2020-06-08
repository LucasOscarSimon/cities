namespace Entities.DataTransferObjects
{
    public class AuthenticatedCitizenDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}