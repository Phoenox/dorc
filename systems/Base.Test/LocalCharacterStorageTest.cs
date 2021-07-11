using Blazored.LocalStorage;
using Dorc.RoleplayingSystems.Base;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Base.Test
{
	public class LocalCharacterStorageTest
	{
		[Fact]
		public void ItAddsACharacter()
		{
			var character = new Character();
			var storageService = new Mock<ISyncLocalStorageService>();
			var characterStorage = new LocalCharacterStorage(storageService.Object, null);
			characterStorage.Update(character);
			storageService.Verify(mock => mock.SetItem("characters/" + character.Uuid, character));
			storageService.Verify(mock => mock.SetItem("characters", new List<string> { character.Uuid }));
		}

		[Fact]
		public void ItReturnsCharacter()
		{
			var system = new RoleplayingSystem("test");
			var character = new Character
			{
				Uuid = "12345",
				System = system
			};

			var storageService = new Mock<ISyncLocalStorageService>();
			storageService.Setup(mock => mock.GetItem<Character>("characters/12345")).Returns(character);

			var systemRepository = new Mock<IRoleplayingSystemRepository>();
			systemRepository.Setup(mock => mock.Get("test")).Returns(system);

			var characterStorage = new LocalCharacterStorage(storageService.Object, systemRepository.Object);
			var storedCharacter = characterStorage.Get("12345");
			Assert.NotNull(storedCharacter);
			Assert.Equal("12345", storedCharacter.Uuid);
			Assert.Equal(system, storedCharacter.System);
		}

		[Fact]
		public void ItThrowsExceptionIfCharacterDoesNotExist()
		{
			var storageService = new Mock<ISyncLocalStorageService>();
			var characterStorage = new LocalCharacterStorage(storageService.Object, null);
			Assert.Throws<KeyNotFoundException>(() => characterStorage.Get("12345"));
		}

		[Fact]
		public void ItThrowsExceptionIfSystemDoesNotExist()
		{
			var character = new Character
			{
				Uuid = "12345",
				SystemId = "test"
			};

			var storageService = new Mock<ISyncLocalStorageService>();
			storageService.Setup(mock => mock.GetItem<Character>("characters/12345")).Returns(character);

			var systemRepository = new Mock<IRoleplayingSystemRepository>();

			var characterStorage = new LocalCharacterStorage(storageService.Object, systemRepository.Object);
			Assert.Throws<KeyNotFoundException>(() => characterStorage.Get("12345"));
		}
	}
}
