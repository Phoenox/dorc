namespace Dorc.RoleplayingSystems.Fate.Core
{
	public class CharacterGenerator : Base.CharacterGenerator
	{
		public CharacterGenerator(RoleplayingSystem system) : base(system) { }

		public override Base.Character CreateDefaultCharacter()
		{
			return new Character { System = system };
		}
	}
}
