using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class StateWithoutId
    {
        public string Name { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}