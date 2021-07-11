using Microsoft.AspNetCore.Components;

namespace Dorc.RoleplayingSystems.Base
{
	public interface ICharacterSheetBuilder
	{
		public RenderFragment CreateCharacterSheet(Character character);
	}
}
