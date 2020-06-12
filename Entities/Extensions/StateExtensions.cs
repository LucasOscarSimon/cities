using Entities.Models;

namespace Entities.Extensions
{
    public static class StateExtensions
    {
        public static bool IsObjectNull(this IState state)
        {
            return state is null;
        }

        public static bool IsEmptyObject(this IState state)
        {
            return state.Id.Equals(0);
        }

        public static void Map(this State dbState, State state)
        {
            dbState.Name = state.Name;
            dbState.Cities = state.Cities;
            dbState.IsActive = state.IsActive;
        }
    }
}