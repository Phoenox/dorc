namespace Dorc.RoleplayingSystems.Base
{
	using Blazored.LocalStorage.Serialization;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;

	public class CharacterFactory : ICharacterFactory
	{
		private readonly IJsonSerializer jsonSerializer;
		private readonly IRoleplayingSystemRepository roleplayingSystemRepository;

		public CharacterFactory(IJsonSerializer jsonSerializer, IRoleplayingSystemRepository roleplayingSystemRepository)
		{
			this.roleplayingSystemRepository = roleplayingSystemRepository;
			this.jsonSerializer = jsonSerializer;
		}

		public Character CreateCharacterFromJson(JObject json)
		{
			var systemId = json["SystemId"]?.ToString();
			if (string.IsNullOrEmpty(systemId))
				throw new ArgumentException($"Invalid system ID '{systemId}'");

			var system = roleplayingSystemRepository.Get(systemId);
			if (system is null)
				throw new KeyNotFoundException($"Cannot find a system with ID '{systemId}'.");

			var deserializeMethod = typeof(IJsonSerializer).GetMethod(nameof(IJsonSerializer.Deserialize));
			var genericDeserializeMethod = deserializeMethod?.MakeGenericMethod(system.CharacterType);
			var parameters = new object[] { json.ToString() };
			if (genericDeserializeMethod?.Invoke(jsonSerializer, parameters) is not Character character)
				throw new InvalidOperationException("Could not deserialize character");

			character.System = system;
			return character;
		}
	}
}
