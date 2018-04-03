using System;
using System.Security.Claims;
using System.Security.Principal;

namespace VRP.Api.Extensions {
    public static class PrincipalExtensions {

        public static long GetId(this IPrincipal principal) {
            var result = principal?.Identity?.GetUserId();
            if (!result.HasValue) {
                throw new Exception("Invalid  principal user.");
            }
            return result.Value;
        }

        private static long? GetUserId(this IIdentity identity) {
            if (identity == null || !identity.IsAuthenticated) {
                return null;
            }
            var ci = identity as ClaimsIdentity;
            var found = ci?.FindFirst(x => ClaimTypes.NameIdentifier.Equals(x.Type));
            if (long.TryParse(found?.Value, out var result) && result != 0) {
                return result;
            }
            return null;
        }

    }
}
