using System;
using CoreWarrior;

namespace Dorc.RoleplayingSystems.CoreWarrior
{
	public class RoleplayingSystem : Base.RoleplayingSystem
	{
		public RoleplayingSystem() : base("coreWarrior")
		{
			CharacterType = typeof(Character);
			CharacterSheetType = typeof(CharacterSheet);
			Name = "CoreWarrior";
		}

		public override Base.Character CreateDefaultCharacter()
		{
			if (CreateCharacter() is not Character character)
				throw new InvalidOperationException("Character is of invalid type.");
			character.Core.AddDefaultSkills();
			character.Core.AddDefaultStress();
			return character;
		}

		public static MechClass MechClassByTonnage(int tonnage)
		{
			switch (tonnage)
			{
				case < 20:
					return MechClass.Other;
				case <= 35:
					return MechClass.Light;
				case <= 55:
					return MechClass.Medium;
				case <= 75:
					return MechClass.Heavy;
				case <= 100:
					return MechClass.Assault;
				default:
					return MechClass.Other;
			}
		}
	}
}
