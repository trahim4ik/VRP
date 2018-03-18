
using System.Collections.Generic;

namespace VRP.Core.Constants {
    public static class Roles {
        public static string Administrator = "Administrator";
        public static string User = "User";

        public static IEnumerable<string> AllRoles = new List<string> { Administrator, User };
    }
}
