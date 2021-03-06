﻿using System.Collections.Generic;

namespace Entities.Models
{
    public class City : ICity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Citizen> Citizens { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }
        public bool IsActive { get; set; }
    }
}