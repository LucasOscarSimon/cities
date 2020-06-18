using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CityWithoutId
    {
        public string Name { get; set; }
        public ICollection<CitizenDto> Citizens { get; set; }
        public State State { get; set; }
    }
}