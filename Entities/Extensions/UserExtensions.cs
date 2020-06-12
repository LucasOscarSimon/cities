using System.Collections.Generic;
using System.Linq;
using Entities.Models;

namespace Entities.Extensions
{
    public static class UserExtensions
    {
        public static bool IsObjectNull(this IUser user)
        {
            return user is null;
        }

        public static bool IsEmptyObject(this IUser user)
        {
            return user.Id.Equals(0);
        }

        public static void Map(this User dbUser, User user)
        {
            dbUser.UserName = user.UserName;
            dbUser.IsActive = user.IsActive;
            dbUser.PasswordHash = user.PasswordHash;
            dbUser.PasswordSalt = user.PasswordSalt;
            dbUser.Role = user.Role;
            dbUser.Citizen = user.Citizen;
            dbUser.IsActive = user.IsActive;
        }

        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> citizens)
        {
            return (IEnumerable<User>)citizens?.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            if (user == null) return null;

            user.PasswordHash = null;
            user.PasswordSalt = null;
            return user;
        }
    }
}