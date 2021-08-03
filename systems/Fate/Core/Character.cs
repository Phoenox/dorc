using Dorc.RoleplayingSystems.Base.Concepts;
using System.Collections.Generic;

namespace Dorc.RoleplayingSystems.Fate.Core
{
	public class Character : Base.Character
	{
		public string HighConcept { get; set; } = "";
		public string Dilemma { get; set; } = "";
		public List<string> Aspects { get; } = new();
		public List<Skill> Skills { get; } = new List<Skill>
		{
			new Skill{Name="Athletics"},
			new Skill{Name="Burglary"},
			new Skill{Name="Contacts"},
			new Skill{Name="Crafts"},
			new Skill{Name="Deceive"},
			new Skill{Name="Drive"},
			new Skill{Name="Empathy"},
			new Skill{Name="Fight"},
			new Skill{Name="Investigate"},
			new Skill{Name="Lore"},
			new Skill{Name="Notice"},
			new Skill{Name="Physique"},
			new Skill{Name="Provoke"},
			new Skill{Name="Rapport"},
			new Skill{Name="Resources"},
			new Skill{Name="Shoot"},
			new Skill{Name="Stealth"},
			new Skill{Name="Will"},
		};
		public List<Stunt> Stunts { get; } = new();
		public List<Extra> Extras { get; } = new();
		public StressBar PhysicalStressBar { get; } = new StressBar(2);
		public StressBar MentalStressBar { get; } = new StressBar(2);
	}
}
