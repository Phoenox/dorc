using System;

namespace Dorc.RoleplayingSystems.Base
{
	public class RoleplayingSystem
	{
		public string Id { get; set; } = "";
		public string Name { get; set; } = "";
		public RoleplayingSystemGroup? Group { get; set; }
		public CharacterGenerator? CharacterGenerator { get; set; }
		public ICharacterSheetBuilder? CharacterSheetBuilder { get; set; }
		public ICharacterSerializer? CharacterSerializer { get; set; }

		public RoleplayingSystem(string id)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentOutOfRangeException("ID cannot be empty.");

			this.Id = id;
		}
	}

	public class RoleplayingSystemGroup
	{
		public string Id { get; set; }
		public string Name { get; set; } = "";

		public RoleplayingSystemGroup(string id)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentOutOfRangeException("ID cannot be empty.");

			this.Id = id;
		}
	}
}
