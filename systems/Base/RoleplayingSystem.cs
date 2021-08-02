using Microsoft.AspNetCore.Components;
using System;

namespace Dorc.RoleplayingSystems.Base
{
	public class RoleplayingSystem
	{
		public Type CharacterType { get; protected set; } = typeof(Character);
		public Type? CharacterSheetType { get; protected set; }
		public string Id { get; set; } = "";
		public string Name { get; set; } = "";
		public RoleplayingSystemGroup? Group { get; set; }

		public RoleplayingSystem(string id)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentOutOfRangeException("ID cannot be empty.");

			Id = id;
		}

		public Character CreateCharacter()
		{
			var characterObject = Activator.CreateInstance(CharacterType);
			if (characterObject is null)
				throw new InvalidOperationException("Created character is null.");

			var character = (Character)characterObject;
			character.System = this;
			return character;
		}

		public RenderFragment CreateCharacterSheet(Character character)
		{
			return (builder) =>
			{
				if (CharacterSheetType is not null)
				{
					builder.OpenComponent(0, CharacterSheetType);
					builder.AddAttribute(1, "Character", Convert.ChangeType(character, CharacterType));
					builder.CloseComponent();
				}
			};
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
