using System.Collections.Generic;
using Entities.Models;

namespace Entities.ExtendedModels
{
    public class CityExtended : ICity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Citizen> Citizens { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }
        public bool IsActive { get; set; }

        public CityExtended()
        {
            
        }

        public CityExtended(City city)
        {
            Id = city.Id;
            Name = city.Name;
            StateId = city.StateId;
            State = city.State;
            IsActive = city.IsActive;
        }
    }
}