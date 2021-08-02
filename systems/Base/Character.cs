using System;
using Newtonsoft.Json;

namespace Dorc.RoleplayingSystems.Base
{
	public class Character
	{
		public string Uuid { get; set; }
		public string Name { get; set; } = "";
		public string Description { get; set; } = "";

		private RoleplayingSystem? system;
		[JsonIgnore]
		public RoleplayingSystem? System
		{
			get { return system; }
			set
			{
				system = value;
				if (system is not null)
					SystemId = system.Id;
			}
		}
		public string SystemId { get; set; } = "";

		public Character()
		{
			Uuid = Guid.NewGuid().ToString();
		}
	}
}
