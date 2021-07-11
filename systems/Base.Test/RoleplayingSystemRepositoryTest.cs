using Xunit;
using Dorc.RoleplayingSystems.Base;

namespace Base.Test
{
	public class RoleplayingSystemRepositoryTest
	{
		private readonly RoleplayingSystemGroup testGroup;
		private readonly RoleplayingSystem testSystem;

		public RoleplayingSystemRepositoryTest()
		{
			testGroup = new RoleplayingSystemGroup("test")
			{
				Name = "TestGroup"
			};

			testSystem = new RoleplayingSystem("test")
			{
				Name = "TestSystem",
				Group = testGroup
			};
		}

		[Fact]
		public void ItAddsRoleplayingSystems()
		{
			var repo = new RoleplayingSystemRepository();
			repo.Update(testSystem);

			var storedSystem = repo.Get("test");
			Assert.Equal(testSystem, storedSystem);
		}

		[Fact]
		public void ItUpdatesGroups()
		{
			// Having multiple groups with the same ID will remove duplicates
			// and only use the latest one

			var otherGroupWithSameId = new RoleplayingSystemGroup("test")
			{
				Name = "AnotherGroup"
			};

			var testSystemWithOtherGroup = new RoleplayingSystem("otherSystem")
			{
				Name = "Another system",
				Group = otherGroupWithSameId
			};

			var repo = new RoleplayingSystemRepository();
			repo.Update(testSystem);
			repo.Update(testSystemWithOtherGroup);

			Assert.Equal(otherGroupWithSameId, testSystem.Group);
			Assert.Equal(otherGroupWithSameId, testSystemWithOtherGroup.Group);
		}
	}
}
