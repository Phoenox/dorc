using Blazored.LocalStorage;
using Dorc.RoleplayingSystems.Base;

namespace Dorc.RoleplayingSystems.Fate.Core
{
	public class CharacterSerializer : ICharacterSerializer
	{
		private readonly ISyncLocalStorageService localStorage;

		public CharacterSerializer(ISyncLocalStorageService localStorage)
		{
			this.localStorage = localStorage;
		}

		public Base.Character Get(string key)
		{
			return localStorage.GetItem<Character>(key);
		}
	}
}
