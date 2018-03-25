using System;
using Microsoft.AspNetCore.Identity;
using VRP.Core.Interfaces;

namespace VRP.Entities {
    public class User : IdentityUser<long>, IId<long>, IEntity {
        public bool IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => this.FirstName + " " + this.LastName;
    }
}
