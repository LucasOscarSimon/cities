using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.Extensions
{
    public static class CitizenExtensions
    {
        public static bool IsObjectNull(this ICitizen citizen)
        {
            return citizen == null;
        }

        public static bool IsEmptyObject(this ICitizen citizen)
        {
            return citizen.Id.Equals(0);
        }

        public static void Map(this Citizen dbCitizen, Citizen citizen)
        {
            dbCitizen.FullName = citizen.FullName;
            dbCitizen.City = citizen.City;
            dbCitizen.CityId = dbCitizen.CityId;
            dbCitizen.Address= citizen.Address;
            dbCitizen.IsActive = citizen.IsActive;
        }
    }
}
