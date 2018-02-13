using System;
using Microsoft.AspNetCore.Identity;

namespace VRP.Entities {
	public class User : IdentityUser<long> {
		public bool IsEnabled { get; set; }
		public DateTime CreatedDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Name => this.FirstName + " " + this.LastName;
	}
}
