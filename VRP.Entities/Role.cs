using Microsoft.AspNetCore.Identity;
using VRP.Core.Interfaces;

namespace VRP.Entities {
    public class Role : IdentityRole<long>, IId<long>, IEntity {
        public string Description { get; set; }
    }
}
