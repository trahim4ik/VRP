using System;
using System.Collections.Generic;

namespace VRP.Core.Extensions {
	public static class EnumExtensions {


		public static Dictionary<int, string> ToDictionary(this Enum theEnum) {
			var enumDict = new Dictionary<int, string>();

			foreach (int enumValue in Enum.GetValues(theEnum.GetType())) {
				enumDict.Add(enumValue, enumValue.ToString());
			}

			return enumDict;
		}


	}
}
