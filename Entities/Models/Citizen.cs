using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Citizen
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
    }
}
