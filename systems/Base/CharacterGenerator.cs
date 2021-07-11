namespace Dorc.RoleplayingSystems.Base
{
	public abstract class CharacterGenerator
	{
		protected readonly RoleplayingSystem system;

		public CharacterGenerator(RoleplayingSystem system)
		{
			this.system = system;
		}

		public abstract Character CreateDefaultCharacter();
	}
}
