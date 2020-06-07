using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Citizen> Citizens { get; set; }
        public string State { get; set; }
    }
}