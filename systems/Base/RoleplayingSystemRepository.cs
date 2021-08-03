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
			var systemsInGroup = GetSystemsInGroup(group);
			systemsInGroup.ForEach(system => system.Group = group);
		}

		public RoleplayingSystem Get(string id)
		{
			return systems[id];
		}

		public List<RoleplayingSystem> GetAll()
		{
			return systems.Values.ToList();
		}

		public void Delete(RoleplayingSystem system)
		{
			systems.Remove(system.Id);
			if (system.Group is not null && HasGroupNoSystem(system.Group))
				groups.Remove(system.Group.Id);
		}

		private bool HasGroupNoSystem(RoleplayingSystemGroup group)
		{
			return GetSystemsInGroup(group).Count == 0;
		}

		private List<RoleplayingSystem> GetSystemsInGroup(RoleplayingSystemGroup group)
		{
			return systems.Select(pair => pair.Value).Where(system => system.Group?.Id == group.Id).ToList();
		}
	}
}
