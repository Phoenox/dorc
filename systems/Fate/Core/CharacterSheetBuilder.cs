using Dorc.RoleplayingSystems.Base;
using Microsoft.AspNetCore.Components;
using Fate.Core;

namespace Dorc.RoleplayingSystems.Fate.Core
{
	internal class CharacterSheetBuilder : ICharacterSheetBuilder
	{
		public RenderFragment CreateCharacterSheet(Base.Character character)
		{
			return (builder) =>
			{
				builder.OpenComponent(0, typeof(CharacterSheet));
				builder.AddAttribute(1, "Character", character as Character);
				builder.CloseComponent();
			};
		}
	}
}