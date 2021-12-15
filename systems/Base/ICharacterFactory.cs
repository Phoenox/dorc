namespace Dorc.RoleplayingSystems.Base
{
	using Newtonsoft.Json.Linq;

	public interface ICharacterFactory
	{
		Character CreateCharacterFromJson(JObject json);
	}
}
