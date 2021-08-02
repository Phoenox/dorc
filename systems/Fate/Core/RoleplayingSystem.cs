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
	}
}
