using System.Collections.Generic;
using System.Linq;

namespace Dorc.RoleplayingSystems.Base
{
	public class RoleplayingSystemRepository : IRoleplayingSystemRepository
	{
		private readonly Dictionary<string,RoleplayingSystem> systems = new();
		private readonly Dictionary<string,RoleplayingSystemGroup> groups = new();

		public void Update(RoleplayingSystem system)
		{
			systems[system.Id] = system;
			if (system.Group is not null)
				UpdateSystemGroup(system.Group);
		}

		public void UpdateSystemGroup(RoleplayingSystemGroup group)
		{
			groups[group.Id] = group;
			ReassignSystemsToGroup(group);
		}

		private void ReassignSystemsToGroup(RoleplayingSystemGroup group)
		{
			var systemsWithGroup = systems.Select(pair => pair.Value).Where(system => system.Group?.Id == group.Id).ToList();
			systemsWithGroup.ForEach(system => system.Group = group);
		}

		public RoleplayingSystem Get(string id)
		{
			return systems[id];
		}

		public List<RoleplayingSystem> GetAll()
		{
			return systems.Values.ToList();
		}
	}
}
