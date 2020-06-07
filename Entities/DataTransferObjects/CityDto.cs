using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Citizen> Citizens { get; set; }
        public State State { get; set; }
    }
}