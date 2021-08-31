using System;
using Fate.Core;

namespace Dorc.RoleplayingSystems.Fate.Core
{
	public class RoleplayingSystem : Base.RoleplayingSystem
	{
		public RoleplayingSystem() : base("fateCore")
		{
			CharacterType = typeof(Character);
			CharacterSheetType = typeof(CharacterSheet);
			Name = "FATE Core";
		}

		public override Base.Character CreateDefaultCharacter()
		{
			if (CreateCharacter() is not Character character)
				throw new InvalidOperationException("Character is of invalid type.");
			character.AddDefaultSkills();
			character.AddDefaultStress();
			return character;
		}
	}
}
