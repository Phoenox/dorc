using System.Collections.Generic;

using Dorc.RoleplayingSystems.Fate;

namespace Dorc.RoleplayingSystems.CoreWarrior
{
	public class Character : Base.Character
	{
		public Fate.Core.Character Stats = new Fate.Core.Character();
		public List<Stunt> MechStunts = new();
		public Mech Mech = new Mech();
	}
}