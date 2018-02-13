using System;
using Microsoft.AspNetCore.Identity;

namespace VRP.Entities {
	public class Role : IdentityRole<long> {
		public string Description { get; set; }
	}
}
