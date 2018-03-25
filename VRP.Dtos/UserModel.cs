using System;
using VRP.Core.Interfaces;

namespace VRP.Dtos {
    public class UserModel : IDto, IId<long> {
        public long Id { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
