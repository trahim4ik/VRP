using System;

namespace VRP.Core.Interfaces {
    public interface IExpirable {
        DateTime InsertDate { get; set; }
        DateTime? DeleteDate { get; set; }
    }
}
