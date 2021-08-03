using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dorc.RoleplayingSystems.Base
{
	public class LocalCharacterStorage : ICharacterRepository
	{
		private const string CharacterIndexKey = "characters";
		private const string CharacterKeyPrefix = "characters/";

		private readonly ISyncLocalStorageService localStorage;
		private readonly IRoleplayingSystemRepository systemRepository;

		public LocalCharacterStorage(ISyncLocalStorageService localStorage, IRoleplayingSystemRepository systemRepository)
		{
			this.localStorage = localStorage;
			this.systemRepository = systemRepository;
		}

		public void Update(Character character)
		{
			localStorage.SetItem(CharacterKeyPrefix + character.Uuid, character);

			var uuids = localStorage.GetItem<List<string>>(CharacterIndexKey) ?? new List<string>();
			if (!uuids.Contains(character.Uuid))
			{
				uuids.Add(character.Uuid);
				localStorage.SetItem(CharacterIndexKey, uuids);
			}
		}

		public List<Character> GetAll()
		{
			var uuids = localStorage.GetItem<List<string>>(CharacterIndexKey) ?? new List<string>();
			return uuids.Select(uuid => Get(uuid)).ToList();
		}

		public Character Get(string id)
		{
			var character = localStorage.GetItem<Character>(CharacterKeyPrefix + id);
			if (character is null)
				throw new KeyNotFoundException($"Cannot find a character with ID '{id}'.");
			if (character.SystemId != "")
			{
				var system = systemRepository.Get(character.SystemId);
				if (system is null)
					throw new KeyNotFoundException($"Cannot find a system with ID '{character.SystemId}'.");

				var getItemMethod = typeof(ISyncLocalStorageService).GetMethod(nameof(ISyncLocalStorageService.GetItem));
				var genericGetMethod = getItemMethod?.MakeGenericMethod(system.CharacterType);
				var parameters = new object[] { CharacterKeyPrefix + id };
				character = genericGetMethod?.Invoke(localStorage, parameters) as Character;
				if (character is null)
					throw new InvalidOperationException($"Could not fetch character with ID '{id}'.");

				character.System = system;
			}
			return character;
		}

		public void Delete(Character character)
		{
			localStorage.RemoveItem(CharacterKeyPrefix + character.Uuid);

			var uuids = localStorage.GetItem<List<string>>(CharacterIndexKey) ?? new List<string>();
			uuids.Remove(character.Uuid);
			localStorage.SetItem(CharacterIndexKey, uuids);
		}
	}
}
