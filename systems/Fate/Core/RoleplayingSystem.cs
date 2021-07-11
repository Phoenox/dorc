namespace Dorc.RoleplayingSystems.Fate.Core
{
	public class RoleplayingSystem : Base.RoleplayingSystem
	{
		public RoleplayingSystem() : base("fateCore")
		{
			this.Name = "FATE Core";
			this.CharacterGenerator = new CharacterGenerator(this);
			this.CharacterSheetBuilder = new CharacterSheetBuilder();
		}
	}
}
