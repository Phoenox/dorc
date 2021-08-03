using Dorc.RoleplayingSystems.Base.Concepts;
using System.Collections.Generic;

namespace Dorc.RoleplayingSystems.Fate.Core
{
	public class Character : Base.Character
	{
		public string HighConcept { get; set; } = "";
		public string Dilemma { get; set; } = "";
		public List<string> Aspects { get; } = new();
		public List<Skill> Skills { get; } = new();
		public List<Stunt> Stunts { get; } = new();
		public List<Extra> Extras { get; } = new();
		public StressBar PhysicalStressBar { get; } = new StressBar(2);
		public StressBar MentalStressBar { get; } = new StressBar(2);

		public void AddDefaultSkills()
		{
			var defaultSkills = new List<string>
			{
				"Athletics",
				"Burglary",
				"Contacts",
				"Crafts",
				"Deceive",
				"Drive",
				"Empathy",
				"Fight",
				"Investigate",
				"Lore",
				"Notice",
				"Physique",
				"Provoke",
				"Rapport",
				"Resources",
				"Shoot",
				"Stealth",
				"Will",
			};

			defaultSkills.ForEach(skillName => Skills.Add(new Skill { Name = skillName }));
		}
	}
}
