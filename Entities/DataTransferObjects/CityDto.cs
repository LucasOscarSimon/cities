﻿using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CitizenDto> Citizens { get; set; }
        public StateDto State { get; set; }
    }
}