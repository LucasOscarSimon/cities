using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CitizenWithoutIdDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
    }
}