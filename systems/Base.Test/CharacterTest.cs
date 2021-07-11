using Xunit;
using Dorc.RoleplayingSystems.Base;

namespace Base.Test
{
	public class CharacterTest
	{
		[Fact]
		public void ItGeneratesUniqueUuidsForEachCharacter()
		{
			var character1 = new Character();
			var character2 = new Character();
			Assert.NotEqual(character1.Uuid, character2.Uuid);
		}

		[Fact]
		public void ItSetsTheSystemIdWhenSettingTheSystem()
		{
			var system = new RoleplayingSystem("testSystem");
			var character = new Character
			{
				System = system
			};
			Assert.Equal(system.Id, character.SystemId);
		}
	}
}
