using System;
using System.Collections.Generic;

namespace Dorc.RoleplayingSystems.CoreWarrior
{
	public class Equipment
	{
		public string Description { get; set; } = "";
		public int Slots { get; set; } = 0;
        public int HeatGeneration { get; set; } = 0;
        public int Damage { get; set; } = 0;
	}

}