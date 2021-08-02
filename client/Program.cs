using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor.Services;
using Dorc.RoleplayingSystems.Base;
using Blazored.LocalStorage;
using Blazored.LocalStorage.Serialization;
using Newtonsoft.Json;

namespace Dorc.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddMudServices();
			builder.Services.AddBlazoredLocalStorage();
			builder.Services.Replace(ServiceDescriptor.Scoped<IJsonSerializer, NewtonSoftJsonSerializer>());
			builder.Services.AddScoped<ICharacterRepository, LocalCharacterStorage>();
			builder.Services.AddScoped<IRoleplayingSystemRepository, RoleplayingSystemRepository>();

			var host = builder.Build();

			var localStorage = host.Services.GetRequiredService<ISyncLocalStorageService>();
			var systemStorage = host.Services.GetRequiredService<IRoleplayingSystemRepository>();
			InitializeDefaultSystems(systemStorage, localStorage);
			
			await host.RunAsync();
		}
		private static void InitializeDefaultSystems(IRoleplayingSystemRepository storage, ISyncLocalStorageService localStorage)
		{
			var fateSystems = new RoleplayingSystemGroup("fate")
			{
				Name = "FATE",
			};
			var fateCore = new RoleplayingSystems.Fate.Core.RoleplayingSystem
			{
				Group = fateSystems,
			};
			storage.Update(fateCore);
		}
	}
	public class NewtonSoftJsonSerializer : IJsonSerializer
	{
		public T Deserialize<T>(string text) => JsonConvert.DeserializeObject<T>(text);
		public string Serialize<T>(T obj) => JsonConvert.SerializeObject(obj);
	}
}
