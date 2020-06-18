using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class StateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CityDto> Cities { get; set; }
    }
}