using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class AuthenticatedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        public Citizen Citizen { get; set; }
    }
}