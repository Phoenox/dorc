using System.Collections.Generic;

namespace Dorc.RoleplayingSystems.Fate
{
	public class StressBar
	{
		public string Name { get; set; }
		public List<StressBox> StressBoxes { get; } = new List<StressBox>();

		public StressBar(string name, int numberOfBoxes)
		{
			Name = name;
			for (var i = 1; i <= numberOfBoxes; i++)
			{
				StressBoxes.Add(new StressBox(i));
			}
		}

		public void AddBox()
		{
			var currentMaximum = StressBoxes.Count;
			StressBoxes.Add(new StressBox(currentMaximum + 1));
		}

		public void RemoveBox()
		{
			StressBoxes.RemoveAt(StressBoxes.Count - 1);
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
