namespace Dorc.RoleplayingSystems.Base
{
	using Microsoft.Extensions.Logging;
	using Microsoft.JSInterop;
	using Newtonsoft.Json;
	using System;

	public class CharacterSerialization
	{
		public static async void ExportCharacter(Character character, IJSRuntime js, ILogger<Index> logger)
		{
			try
			{
				var characterJson = JsonConvert.SerializeObject(character, Formatting.Indented);
				var options = $"{{\"suggestedName\": \"{character?.Name}.char\", \"types\": [{{ \"description\": \"D'Orc characters\", \"accept\": {{\"dorc/character\": [\".char\"]}}}}]}}";
				await js.InvokeVoidAsync("saveAs", options,	characterJson);
			}
			catch (Exception exception)
			{
				logger.LogError($"Could not export character: {exception.Message}");
			}
		}
	}
}
