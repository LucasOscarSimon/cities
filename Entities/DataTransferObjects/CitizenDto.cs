using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CitizenDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
