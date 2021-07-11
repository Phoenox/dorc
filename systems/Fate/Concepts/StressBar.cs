using System.Collections.Generic;

namespace Dorc.RoleplayingSystems.Fate
{
	public class StressBar
	{
		public List<StressBox> StressBoxes { get; } = new List<StressBox>();

		public StressBar(int numberOfBoxes)
		{
			for (var i = 1; i <= numberOfBoxes; i++)
			{
				StressBoxes.Add(new StressBox(i));
			}
		}
	}
	public class StressBox
	{
		public int Value { get; }
		public bool IsChecked { get; set; }

		public StressBox(int value)
		{
			this.Value = value;
		}
	}
}
