using VRP.Core.Interfaces;

namespace VRP.Dtos {
    public class RoleModel : IDto, IId<long> {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}
