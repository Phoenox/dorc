using Dorc.Shared;

namespace Dorc.RoleplayingSystems.Base
{
	public interface IRoleplayingSystemRepository : IRepository<RoleplayingSystem>
	{
		public void UpdateSystemGroup(RoleplayingSystemGroup roleplayingSystemGroup);
	}
}
