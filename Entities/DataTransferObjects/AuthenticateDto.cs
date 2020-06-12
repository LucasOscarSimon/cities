using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class AuthenticateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}