using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dorc.RoleplayingSystems.Fate
{
	public class StressBar
	{
		public string Name { get; set; }
		public List<StressBox> StressBoxes { get; } = new();

		[JsonConstructor]
		public StressBar(string name, int numberOfBoxes)
		{
			Name = name;
			for (var i = 1; i <= numberOfBoxes; i++)
			{
				StressBoxes.Add(new StressBox(i));
			}
		}

		public StressBar(StressBar oldBar, int numberOfBoxes)
		{
			Name = oldBar.Name;
			var commonBoxes = Math.Min(numberOfBoxes, oldBar.StressBoxes.Count);
			for (var i = 0; i < commonBoxes; i++)
			{
				StressBoxes.Add(new StressBox(oldBar.StressBoxes[i]));
			}

			var remainingBoxes = numberOfBoxes - commonBoxes;
			for (var i = 0; i < remainingBoxes; i++)
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

		[JsonConstructor]
		public StressBox(int value)
		{
			this.Value = value;
		}

		public StressBox(StressBox oldBox)
		{
			this.Value = oldBox.Value;
			this.IsChecked = oldBox.IsChecked;
		}
	}
}
