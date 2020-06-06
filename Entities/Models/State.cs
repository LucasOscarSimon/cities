using System.Collections.Generic;

namespace Entities.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}