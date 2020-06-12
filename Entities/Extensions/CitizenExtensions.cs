using Entities.Models;

namespace Entities.Extensions
{
    public static class CitizenExtensions
    {
        public static bool IsObjectNull(this ICitizen citizen)
        {
            return citizen is null;
        }

        public static bool IsEmptyObject(this ICitizen citizen)
        {
            return citizen.Id.Equals(0);
        }

        public static void Map(this Citizen dbCitizen, Citizen citizen)
        {
            dbCitizen.FirstName = citizen.FirstName;
            dbCitizen.LastName = citizen.LastName;
            dbCitizen.Document = citizen.Document;
            dbCitizen.Address= citizen.Address;
            dbCitizen.CityId = citizen.CityId;
            dbCitizen.IsActive = citizen.IsActive;
        }
    }
}
