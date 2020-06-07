using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CityWithoutIdForCreateDto
    {
        public string Name { get; set; }
        public ICollection<Citizen> Citizens { get; set; }
        public State State { get; set; }
    }
}