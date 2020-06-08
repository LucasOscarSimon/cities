using System;
using System.Collections.Generic;
using System.Linq;
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

        public static IEnumerable<Citizen> WithoutPasswords(this IEnumerable<Citizen> citizens)
        {
            return (IEnumerable<Citizen>) citizens?.Select(x => x.WithoutPassword());
        }

        public static Citizen WithoutPassword(this Citizen citizen)
        {
            if (citizen == null) return null;

            citizen.PasswordHash = null;
            citizen.PasswordSalt = null;
            return citizen;
        }

        public static void Map(this Citizen dbCitizen, Citizen citizen)
        {
            dbCitizen.FullName = citizen.FullName;
            //dbCitizen.City = citizen.City;
            dbCitizen.CityId = citizen.CityId;
            dbCitizen.Address= citizen.Address;
            dbCitizen.IsActive = citizen.IsActive;
            dbCitizen.Role = citizen.Role;
            dbCitizen.Email = citizen.Email;
        }
    }
}
