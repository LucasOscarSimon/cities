using Entities.Models;

namespace Entities.Extensions
{
    public static class CityExtensions
    {
        public static bool IsObjectNull(this ICity city)
        {
            return city == null;
        }

        public static bool IsEmptyObject(this ICity city)
        {
            return city.Id.Equals(0);
        }

        public static void Map(this City dbCity, City city)
        {
            dbCity.Name = city.Name;
            dbCity.State = city.State;
            dbCity.Citizens = city.Citizens;
            dbCity.StateId = city.StateId;
            dbCity.IsActive = city.IsActive;
        }
    }
}
